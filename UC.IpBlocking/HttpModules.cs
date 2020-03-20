using System;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using System.Web;
using UC.IpBlocking.BLL;

namespace UC.HttpModules
{
    /// <summary>
    /// Блокировка запросов с IP
    /// </summary>
    public class IpBlockingModule : IHttpModule
    {
        void IHttpModule.Dispose()
        {
        }

        void IHttpModule.Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        /// <summary>
        /// Checks the requesting IP address in the collection
        /// and block the response if it's on the list.
        /// </summary>
        private void context_BeginRequest(object sender, EventArgs e)
        {
            string ip = HttpContext.Current.Request.UserHostAddress;
            //if (_IpAdresses.Contains(ip))
            if (BlockIpManager.CheckBlockIp(ip))
            {
                HttpContext.Current.Response.StatusCode = 503;
                HttpContext.Current.Response.End();
            }
        }

        //private static StringCollection _IpAdresses = FillBlockedIps();

        /// <summary>
        /// Retrieves the IP addresses from the web.config
        /// and adds them to a StringCollection.
        /// </summary>
        /// <returns>A StringCollection of IP addresses.</returns>
        //private static StringCollection FillBlockedIps()
        //{
        //    //StringCollection col = new StringCollection();
        //    //string raw = Globals.Settings.Statistics.BlockIP; //ConfigurationManager.AppSettings.Get("blockip");
        //    //raw = raw.Replace(",", ";");
        //    //raw = raw.Replace(" ", ";");

        //    //foreach (string ip in raw.Split(';'))
        //    //{
        //    //    col.Add(ip.Trim());
        //    //}

        //    //return col;

        //    StringCollection col = new StringCollection();

        //    if (HttpContext.Current.Cache["blockip"] != null)
        //    {
        //        col = (StringCollection)HttpContext.Current.Cache["blockip"];
        //    }
        //    else
        //    {
        //        string raw = Globals.Settings.Statistics.BlockIP; //ConfigurationManager.AppSettings.Get("blockip");
        //        raw = raw.Replace(",", ";");
        //        raw = raw.Replace(" ", ";");

        //        foreach (string ip in raw.Split(';'))
        //        {
        //            col.Add(ip.Trim());
        //        }

        //        HttpContext.Current.Cache.Insert("blockip", col);
        //    }

        //    return col;


        //}

    }
}
