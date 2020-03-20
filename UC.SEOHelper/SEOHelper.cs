using System;
using System.Web;
using System.Web.UI;
using UC.Core;

namespace UC.SEOHelper
{
    public static class SeoHelper
    {
        public static string GetDepartmentUrl(int departmentId)
        {
            string url = "";

            if (SettingManager.GetSettingValue("Common.Domen") == "DOMIS.RU")
            {
                switch (departmentId)
                {
                    case 267:
                        url = string.Format("{0}mebel-edelform.aspx", GetStoreHTTPLocation(false));
                        break;
                    case 318:
                        url = string.Format("{0}mebel-aqualife.aspx", GetStoreHTTPLocation(false));
                        break;
                    case 268:
                        url = string.Format("{0}dushevie-kabini-edelform.aspx", GetStoreHTTPLocation(false));
                        break;
                    case 305:
                        url = string.Format("{0}dushevie-kabini-luxus.aspx", GetStoreHTTPLocation(false));
                        break;
                    default:
                        url = string.Format("{0}Departments.aspx?DepID={1}", GetStoreHTTPLocation(false), departmentId);
                        break;
                }
            }

            if (SettingManager.GetSettingValue("Common.Domen") == "MIRTOS.RU")
            {
                switch (departmentId)
                {
                    case 1:
                        url = string.Format("{0}kupit-kondicioner.aspx", GetStoreHTTPLocation(false));
                        break;
                    case 9:
                        url = string.Format("{0}mobilnyj-kondicioner.aspx", GetStoreHTTPLocation(false));
                        break;
                    case 15:
                        url = string.Format("{0}okonnyj-kondicioner.aspx", GetStoreHTTPLocation(false));
                        break;
                    default:
                        url = string.Format("{0}Departments.aspx?DepID={1}", GetStoreHTTPLocation(false), departmentId);
                        break;
                }
            }

            return url;
        }

        public static string GetUrl(string url, int pageId)
        {
            string res = "";

            res = string.Format(url + "p={0}", pageId);

            if (SettingManager.GetSettingValue("Common.Domen") == "DOMIS.RU")
            {
                if (url.Contains("mebel-edelform") || url.Contains("Departments.aspx?DepID=267"))
                {
                    res = pageId == 1
                              ? "~/mebel-edelform.aspx"
                              : string.Format("~/Departments.aspx?DepID=267&p={0}", pageId);
                }

                if (url.Contains("mebel-aqualife") || url.Contains("Departments.aspx?DepID=318"))
                {
                    res = pageId == 1
                              ? "~/mebel-aqualife.aspx"
                              : string.Format("~/Departments.aspx?DepID=318&p={0}", pageId);
                }

                if (url.Contains("dushevie-kabini-edelform") || url.Contains("Departments.aspx?DepID=268"))
                {
                    res = pageId == 1
                              ? "~/dushevie-kabini-edelform.aspx"
                              : string.Format("~/Departments.aspx?DepID=268&p={0}", pageId);
                }

                if (url.Contains("dushevie-kabini-luxus") || url.Contains("Departments.aspx?DepID=305"))
                {
                    res = pageId == 1
                              ? "~/dushevie-kabini-luxus.aspx"
                              : string.Format("~/Departments.aspx?DepID=305&p={0}", pageId);
                }
            }

            if (SettingManager.GetSettingValue("Common.Domen") == "MIRTOS.RU")
            {
                if (url.Contains("kupit-kondicioner") || url.Contains("Departments.aspx?DepID=1"))
                {
                    res = pageId == 1
                              ? "~/kupit-kondicioner.aspx"
                              : string.Format("~/Departments.aspx?DepID=1&p={0}", pageId);
                }

                if (url.Contains("mobilnyj-kondicioner") || url.Contains("Departments.aspx?DepID=9"))
                {
                    res = pageId == 1
                              ? "~/mobilnyj-kondicioner.aspx"
                              : string.Format("~/Departments.aspx?DepID=9&p={0}", pageId);
                }

                if (url.Contains("okonnyj-kondicioner") || url.Contains("Departments.aspx?DepID=15"))
                {
                    res = pageId == 1
                              ? "~/okonnyj-kondicioner.aspx"
                              : string.Format("~/Departments.aspx?DepID=15&p={0}", pageId);
                }
            }

            return res;
        }

        public static string GetDepartmentUrl(int departmentId, int page)
        {
            string url = "";

            url = GetDepartmentUrl(departmentId) + string.Format("{0}/", page);

            return url;
        }

        public static string GetStoreHTTPLocation(bool UseSSL)
        {
            string s = "http://" + ServerVariables("HTTP_HOST") + HttpContext.Current.Request.ApplicationPath;
            if (!s.EndsWith("/"))
                s += "/";

            if (UseSSL)
            {
                s = s.Replace("http:/", "https:/");
                s = s.Replace("www.www", "www");
            }
            return s;
        }

        public static string ServerVariables(string Name)
        {
            string tmpS = String.Empty;
            try
            {
                if (HttpContext.Current.Request.ServerVariables[Name] != null)
                {

                    tmpS = HttpContext.Current.Request.ServerVariables[Name].ToString();

                }
            }
            catch
            {
                tmpS = String.Empty;
            }
            return tmpS;
        }

        public static void CheckUrl()
        {
            //HttpContext context = HttpContext.Current;

            //context.Response.Status = "301 Moved Permanently";
            //context.Response.AddHeader("Location", "http://www.domis.ru/");

            HttpContext context = HttpContext.Current;

            string host = context.Request.Url.Host;

            string requestedUrl = context.Request.Url.OriginalString;

            bool redirect = false;

            //if (host.ToLower() == "localhost")
            //{
            //    if (String.IsNullOrEmpty(context.Request.Url.PathAndQuery))
            //    {
            //        context.RewritePath("~/default.aspx");
            //    }
            //}

            if (host.ToLower() != "localhost")
            {
                //if (String.IsNullOrEmpty(context.Request.Url.PathAndQuery))
                //{
                //    context.RewritePath("~/default.aspx");
                //}

                //if (requestedUrl.ToLower().Contains("default.aspx"))
                //{
                //    requestedUrl = requestedUrl.Replace(context.Request.Url.PathAndQuery, "");

                //    context.Response.Status = "301 Moved Permanently";
                //    context.Response.AddHeader("Location", requestedUrl);
                //}

                if (!host.ToLower().Contains("www"))
                {
                    requestedUrl = requestedUrl.Replace(host, "www." + host.ToLower());

                    redirect = true;
                }
            }

            if (redirect)
            {
                context.Response.Status = "301 Moved Permanently";
                context.Response.AddHeader("Location", requestedUrl);
            }

            //if (context.Request.RawUrl.Contains("mobilnyj-kondicioner/"))
            //{
            //    if (context.Request.RawUrl == "/DOMIS/mobilnyj-kondicioner/" ||
            //        context.Request.RawUrl == "/mobilnyj-kondicioner/")
            //    {
            //        context.RewritePath("~/Departments.aspx?DepID=9");
            //    }
            //    else
            //    {
            //        string newPath = "~" + context.Request.RawUrl.Replace("mobilnyj-kondicioner/", "");
            //        context.RewritePath(newPath);
            //    }
            //}

            //if (context.Request.RawUrl == "/DOMIS/Departments.aspx?DepID=9" || context.Request.RawUrl == "/Departments.aspx?DepID=9")
            //{
            //    context.RewritePath("~/Departments.aspx?DepID=9");
            //}
        }

        public static string GetAbsoluteUrl(string url)
        {
            HttpContext context = HttpContext.Current;

            string scheme = context.Request.Url.Scheme;
            string host = context.Request.Url.Host;
            string port = context.Request.Url.Port != 80 ? ":" + context.Request.Url.Port.ToString() : "";

            string res = scheme + "://" + host + port + url;

            return res;
        }
    }
}
