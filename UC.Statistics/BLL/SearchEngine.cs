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
using System.Text.RegularExpressions;
using UC.DAL;

namespace UC.BLL.Statistics
{
    public class SearchEngine : BaseStatistics
    {
        private int _searchEngineID = 0;
        public int SearchEngineID
        {
            get { return _searchEngineID; }
            set { _searchEngineID = value; }
        }

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _searchMask = "";
        public string SearchMask
        {
            get { return _searchMask; }
            set { _searchMask = value; }
        }

        private string _keywordMask = "";
        public string KeywordMask
        {
            get { return _keywordMask; }
            set { _keywordMask = value; }
        }

        public SearchEngine(int searchEngineID, string name, string searchMask, string keywordMask)
        {
            this.SearchEngineID = searchEngineID;
            this.Name = name;
            this.SearchMask = searchMask;
            this.KeywordMask = keywordMask;
        }

        /***********************************
        * Статические методы
        ************************************/

        /// <summary>
        /// Поиск и получение поисковика по ссылке с которой перешел посетитель
        /// </summary>
        public static SearchEngine GetSearchEngineByURL(string refferalURL)
        {
            SearchEngine searchEngine = null;
            List<SearchEngine> searchEngines = GetSearchEngines();

            foreach (SearchEngine item in searchEngines)
            {
                Regex mask = new Regex(item.SearchMask.Replace("%", "(.*?)"), RegexOptions.Compiled | RegexOptions.IgnoreCase);
                if (mask.IsMatch(refferalURL))
                {
                    searchEngine = item;
                    break;
                }
            }
            return searchEngine;
        }

        /// <summary>
        /// Возвращает коллекцию поиковиков
        /// </summary>
        public static List<SearchEngine> GetSearchEngines()
        {
            List<SearchEngine> searchEngines = null;
            string key = "Statistics_SearchEngines";

            if (BaseStatistics.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                searchEngines = (List<SearchEngine>)BizObject.Cache[key];
            }
            else
            {
                List<SearchEngineDetails> recordset = StatisticsProvider.Instance.GetSearchEngines();
                searchEngines = GetSearchEngineListFromSearchEngineDetailsList(recordset);
                BaseStatistics.CacheData(key, searchEngines);
            }
            return searchEngines;
        }

        /// <summary>
        /// Возвращает объект SearchEngine заполненный данными из SearchEngineDetails
        /// </summary>
        private static SearchEngine GetSearchEngineFromSearchEngineDetails(SearchEngineDetails record)
        {
            if (record == null)
                return null;
            else
            {
                return new SearchEngine(record.SearchEngineID, record.Name, record.SearchMask, record.KeywordMask);
            }
        }

        /// <summary>
        /// Возвращает список объектов SearchEngine заполненный данными из списка объектов SearchEngineDetails
        /// </summary>
        private static List<SearchEngine> GetSearchEngineListFromSearchEngineDetailsList(List<SearchEngineDetails> recordset)
        {
            List<SearchEngine> searchEngines = new List<SearchEngine>();
            foreach (SearchEngineDetails record in recordset)
                searchEngines.Add(GetSearchEngineFromSearchEngineDetails(record));
            return searchEngines;
        }
    }
}
