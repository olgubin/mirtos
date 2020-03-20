using System.IO;
using System.Net;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Configuration;
using System.Configuration;
using System.Threading;

namespace effetto.Sape
{
    public class SapeFactory
    {
        private static SapeFactory factory = null;
        private static DateTime lastChange;
        private static List<SapeHost> hosts;
        private static Object synhroObject;
        private static List<String> dispensers;
        private static HttpServerUtility server;
        private static String basePath;
        private static Timer workerTimer;
        private static SapeConfigSection config;


        public static SapeFactory Factory
        {
            get
            {
                if (factory == null) factory = new SapeFactory();
                return factory;
            }
        }
        public SapeUser GetUser(string userId)
        {
            SapeUser u = new SapeUser();
            u.Id = userId;
            return u;
        }
        public SapeUser GetUser()
        {
            SapeUser u = new SapeUser();
            u.Id = config.UserId;
            return u;
        }
        private string GetConnectionString()
        {
            if (ConfigurationManager.ConnectionStrings[config.ConnectionStringName] != null)
                return ConfigurationManager.ConnectionStrings[config.ConnectionStringName].ConnectionString;
            return null;
        }
        private void SaveBase()
        {
            IFormatter formatter = new BinaryFormatter();            
            lock (synhroObject)
            {
                if (config.CacheInSQL.Value)
                {
                    MemoryStream stream = new MemoryStream();
                    formatter.Serialize(stream, hosts);
                    stream.Close();
                    DC dc = new DC(GetConnectionString());
                    SapeStore store;
                    var stores = from s in dc.SapeStores where s.Id == new Guid(config.SystemId) select s;
                    if (stores.Count() > 0)
                        store = stores.First();
                    else
                    {
                        store = new SapeStore()
                        {
                            Id = new Guid(config.SystemId)
                        };
                        dc.SapeStores.InsertOnSubmit(store);
                    }
                    store.Data = stream.GetBuffer();
                    dc.SubmitChanges();
                }
                else
                {
                    Stream stream = null;
                    try
                    {
                        stream = new FileStream(basePath, FileMode.Create, FileAccess.Write, FileShare.None);
                        formatter.Serialize(stream, hosts);
                        stream.Flush();
                    }
                    catch
                    {
                    }
                    finally
                    {
                        if (stream != null) stream.Close();
                    }
                }
            }
        }
        private void LoadBase()
        {
            IFormatter formatter = new BinaryFormatter();
            lock (synhroObject)
            {
                if (config.CacheInSQL.Value)
                {
                    DC dc = new DC(GetConnectionString());
                    var stores = from s in dc.SapeStores where s.Id == new Guid(config.SystemId) select s;
                    if (stores.Count() > 0)
                    {
                        MemoryStream stream = new MemoryStream(stores.First().Data.ToArray());
                        hosts = (List<SapeHost>)formatter.Deserialize(stream);
                        stream.Close();
                    }
                    else
                    {
                        hosts = new List<SapeHost>();
                    }

                }
                else
                {
                    Stream stream = null;
                    try
                    {

                        stream = new FileStream(basePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                        hosts = (List<SapeHost>)formatter.Deserialize(stream);
                        stream.Flush();
                        
                    }
                    catch
                    {
                        //?
                    }
                    finally
                    {
                        if (stream != null) stream.Close();                            
                    }
                }
            }
        }
        private static void UpdaterThread(Object stateInfo)
        {            
            double cacheMinutes =(double) config.CacheTimeout;
            double expireMinutes =(double) config.CacheTimeout;
            lock (synhroObject)
            {
                int i=0;
                while (i < hosts.Count)
                {
                    if (hosts[i].LastAccess.AddMinutes(expireMinutes) < DateTime.Now)
                    {
                        hosts.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
                for (i = 0; i < hosts.Count; i++)
                {
                    if (hosts[i].LastSync.AddMinutes(cacheMinutes) < DateTime.Now)
                    {
                        try
                        {
                            hosts[i] = factory.RequestHostFromDispenser(factory.GetUser(hosts[i].OwnerId), hosts[i].Name);
                        }
                        catch
                        {

                        }
                    }
                }
                factory.SaveBase();
            }
        }
        public SapeHost GetHost(SapeUser user)
        {
            string host="";
            if (!String.IsNullOrEmpty(config.Host))
                host = config.Host.ToLower();
            else
                host = HttpContext.Current.Request.Url.Host.ToLower();
            return this.GetHost(user, host);
        }
        public SapeHost GetHost(SapeUser user, string host)
        {            
            SapeHost result = null;
            foreach (SapeHost h in hosts)
                if (h.IsThisHost(host)) result = h;
            if (result == null)
            {
                SapeHost requestedHost = RequestHostFromDispenser(user, host);
                if (requestedHost != null)
                {
                    lock (synhroObject)
                    {
                        foreach (SapeHost h in hosts)
                            if (h.IsThisHost(host)) result = h;
                        if (result == null)
                        {
                            hosts.Add(requestedHost);
                            result = requestedHost;
                            SaveBase();
                        }
                    }
                }
            }
            if (result!=null)
                result.LastAccess = DateTime.Now;
            return result;
        }
        private string GetRandomDispenser()
        {
            Random rand = new Random();
            int index = rand.Next(0, dispensers.Count - 1);            
            return dispensers[index];
        }
        private SapeHost RequestHostFromDispenser(SapeUser user, string hostname)
        {
            hostname = hostname.Trim().ToLower();
            XDocument docLinks = null;
            XDocument docContext = null;
            SapeHost result = new SapeHost();
            result.Name = hostname.ToLower();
            result.OwnerId = user.Id;
            double cacheMinutes = (double)config.CacheTimeout;
            try
            {
                string linksUrl="http://" + GetRandomDispenser() + "/code.php?user=" + user.Id + "&host=" + hostname + "&as_xml=true&charset=UTF-8";
                string contextUrl="http://" + GetRandomDispenser() + "/code_context.php?user=" + user.Id + "&host=" + hostname + "&as_xml=true&charset=UTF-8";
                docLinks = config.RussianNormalizer.Value ? RussianNormalizer.GetFixedXML(linksUrl) : XDocument.Load(linksUrl);              
                docContext = config.RussianNormalizer.Value ? RussianNormalizer.GetFixedXML(contextUrl) : XDocument.Load(contextUrl);
            }
            catch
            {
                result.LastSync = DateTime.Now.AddMinutes(1 - cacheMinutes);
                return result; 
            }
            XElement host = docLinks.Root;
            XElement hostContext = docContext.Root;
            IEnumerable<XElement> pages = from l in host.Elements("page") where l.Attribute("uri").Value != "*" select l;
            IEnumerable<XElement> pagesContext = from l in hostContext.Elements("page") where l.Attribute("uri").Value != "*" select l;
            
            result.LastSync = DateTime.Now;
            result.LastAccess = DateTime.Now;
            result.Delimiter = host.Attribute("delimiter").Value;
            result.CheckCode = (from l in host.Elements("page") where l.Attribute("uri").Value == "*" select l).First().Value;
            result.ContextCheckCode = (from l in hostContext.Elements("page") where l.Attribute("uri").Value == "*" select l).First().Value;
            foreach (XElement pageElement in pages)
            {
                SapePage page = result.GetPage(new SapeUrl(pageElement.Attribute("uri").Value), false, false, false, false, config.RussianNormalizer.Value);
                if (page == null)
                {
                    page = new SapePage();
                    page.Url = new SapeUrl(pageElement.Attribute("uri").Value);
                    page.Host = result;
                    result.Pages.Add(page);
                }
                foreach (XElement linkElement in pageElement.Elements("link"))
                {
                    SapeLink link = new SapeLink()
                    {
                        RawLink = linkElement.Value
                    };
                    if (!page.Links.Contains(link))
                        page.Links.Add(link);
                }
            }
            foreach (XElement pageElement in pagesContext)
            {
                SapePage page = result.GetPage(new SapeUrl(pageElement.Attribute("uri").Value), false, false, false, false, config.RussianNormalizer.Value);
                if (page == null)
                {
                    page = new SapePage();
                    page.Url = new SapeUrl(pageElement.Attribute("uri").Value);
                    page.Host = result;
                    result.Pages.Add(page);
                }
                foreach (XElement linkElement in pageElement.Elements("link"))
                {
                    SapeContextLink link = new SapeContextLink()
                    {
                        RawLink = linkElement.Value
                    };
                    if (!page.Links.Contains(link))
                        page.Links.Add(link);
                }
            }
            return result;
        }
        private SapeFactory()
        {
            server = HttpContext.Current.Server;
            config = (SapeConfigSection)System.Configuration.ConfigurationManager.GetSection("effetto.Sape/SapeConfig");
            basePath = server.MapPath("~/App_Data/") + "sape.bin";
            synhroObject = new Object();
            lastChange = DateTime.MaxValue;
            dispensers = new List<String>();
            dispensers.Add("dispenser-01.sape.ru");
            dispensers.Add("dispenser-02.sape.ru");
            hosts = new List<SapeHost>();
            LoadBase();
            TimerCallback timerDelegate = new TimerCallback(UpdaterThread);
            workerTimer = new Timer(timerDelegate, null, new TimeSpan(0, 0, 10), new TimeSpan(0, 1, 0));
        }
    }
}