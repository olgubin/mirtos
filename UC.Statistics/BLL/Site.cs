using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using UC.DAL;

namespace UC.BLL.Statistics
{
    public class Site : BaseStatistics
    {
        private int _siteID = 0;
        public int SiteID
        {
            get { return _siteID; }
            set { _siteID = value; }
        }

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Site(int siteID, string name)
        {
            this.SiteID = siteID;
            this.Name = name;
        }

        /***********************************
        * Статические методы
        ************************************/

        /// <summary>
        /// Поиск и получение идентификатора сайта с которого пришел посетитель
        /// </summary>
        public static int GetSiteID(string host)
        {
            int ret = -1;
            List<Site> sites = GetSites();
            foreach (Site item in sites)
            {
                if (host.ToLower() == item.Name)
                {
                    ret = item.SiteID;
                    break;
                }
            }
            if (ret == -1) { ret = InsertSite(host.ToLower()); }
            return ret;
        }

        /// <summary>
        /// Добавление сайта с которого пришел посетитель
        /// </summary>
        public static int InsertSite(string host)
        {
            SiteDetails record = new SiteDetails(0, host);
            int ret = StatisticsProvider.Instance.InsertSite(record);
            BizObject.PurgeCacheItems("statistics_site");
            return ret;
        }



        /// <summary>
        /// Возвращает коллекцию сайтов с которых приходили посетители
        /// </summary>
        public static List<Site> GetSites()
        {
            List<Site> sites = null;
            string key = "Statistics_Sites";

            if (BaseStatistics.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                sites = (List<Site>)BizObject.Cache[key];
            }
            else
            {
                List<SiteDetails> recordset = StatisticsProvider.Instance.GetSites();
                sites = GetSiteListFromSiteDetailsList(recordset);
                BaseStatistics.CacheData(key, sites);
            }
            return sites;
        }

        /// <summary>
        /// Возвращает объект Site заполненный данными из SiteDetails
        /// </summary>
        private static Site GetSiteFromSiteDetails(SiteDetails record)
        {
            if (record == null)
                return null;
            else
            {
                return new Site(record.SiteID, record.Name);
            }
        }

        /// <summary>
        /// Возвращает список объектов Site заполненный данными из списка объектов SiteDetails
        /// </summary>
        private static List<Site> GetSiteListFromSiteDetailsList(List<SiteDetails> recordset)
        {
            List<Site> sites = new List<Site>();
            foreach (SiteDetails record in recordset)
                sites.Add(GetSiteFromSiteDetails(record));
            return sites;
        }
    }
}
