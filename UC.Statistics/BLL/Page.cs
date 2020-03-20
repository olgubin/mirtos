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
    public class Page : BaseStatistics
    {
        private int _pageID = 0;
        public int PageID
        {
            get { return _pageID; }
            set { _pageID = value; }
        }

        private string _pageURL = "";
        public string PageURL
        {
            get { return _pageURL; }
            set { _pageURL = value; }
        }

        public Page(int pageID, string pageURL)
        {
            this.PageID = pageID;
            this.PageURL = pageURL;
        }

        /***********************************
        * Статические методы
        ************************************/

        /// <summary>
        /// Получение идентификатора страницы
        /// </summary>
        public static int GetPageID(string pageURL)
        {
            int ret = -1;
            List<Page> pages = GetPages();
            foreach (Page item in pages)
            {
                if (item.PageURL == pageURL)
                {
                    ret = item.PageID;
                    break;
                }
            }
            if (ret == -1) { ret = InsertPage(pageURL); }
            return ret;
        }

        /// <summary>
        /// Добавление посещаемой страницы
        /// </summary>
        public static int InsertPage(string pageURL)
        {
            PageDetails record = new PageDetails(0, pageURL);
            int ret = StatisticsProvider.Instance.InsertPage(record);
            BizObject.PurgeCacheItems("statistics_page");
            return ret;
        }

        /// <summary>
        /// Возвращает коллекцию посещаемых страниц сайта
        /// </summary>
        public static List<Page> GetPages()
        {
            List<Page> pages = null;
            string key = "Statistics_Pages";

            if (BaseStatistics.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                pages = (List<Page>)BizObject.Cache[key];
            }
            else
            {
                List<PageDetails> recordset = StatisticsProvider.Instance.GetPages();
                pages = GetPageListFromPageDetailsList(recordset);
                BaseStatistics.CacheData(key, pages);
            }
            return pages;
        }

        /// <summary>
        /// Возвращает объект Page заполненный данными из PageDetails
        /// </summary>
        private static Page GetPageFromPageDetails(PageDetails record)
        {
            if (record == null)
                return null;
            else
            {
                return new Page(record.PageID, record.PageURL);
            }
        }

        /// <summary>
        /// Возвращает список объектов Page заполненный данными из списка объектов PageDetails
        /// </summary>
        private static List<Page> GetPageListFromPageDetailsList(List<PageDetails> recordset)
        {
            List<Page> pages = new List<Page>();
            foreach (PageDetails record in recordset)
                pages.Add(GetPageFromPageDetails(record));
            return pages;
        }
    }
}
