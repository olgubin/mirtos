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

namespace UC.DAL
{
    public abstract class SearchProvider : DataAccess
    {
        static private SearchProvider _instance = null;
        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>
        static public SearchProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (SearchProvider)Activator.CreateInstance(
                       Type.GetType(Globals.Settings.Search.ProviderType));
                return _instance;
            }
        }

        public SearchProvider()
        {
            this.ConnectionString = Globals.Settings.Search.ConnectionString;
            this.EnableCaching = Globals.Settings.Search.EnableCaching;
            this.CacheDuration = Globals.Settings.Search.CacheDuration;
        }

        // методы для работы с запросами
        public abstract int GetRequestCount();
        public abstract List<SearchRequestDetails> GetSearchRequests(string sortExpression, int pageIndex, int pageSize);
        public abstract int InsertRequest(SearchRequestDetails request);

        /// <summary>
        /// Возвращает новый объект SearchRequestDetails заполненный данными с датаридера
        /// </summary>
        protected virtual SearchRequestDetails GetRequestFromReader(IDataReader reader)
        {
            return new SearchRequestDetails(
               (int)reader["SearchID"],
               (DateTime)reader["SearchDate"],
               reader["SearchRequest"].ToString(),
               (int)reader["Result"],
               reader["PageFrom"].ToString(),
               reader["PageRequest"].ToString(),
               reader["SearchBy"].ToString(),
               reader["SearchByIP"].ToString());
        }

        /// <summary>
        /// Возвращает коллекцию объектов SearchRequestDetails заполненную данными с датаридера
        /// </summary>
        protected virtual List<SearchRequestDetails> GetRequestCollectionFromReader(IDataReader reader)
        {
            List<SearchRequestDetails> requests = new List<SearchRequestDetails>();
            while (reader.Read())
                requests.Add(GetRequestFromReader(reader));
            return requests;
        }

        /// <summary>
        /// Возвращает выражение сортировки для поисковых запросов
        /// </summary>
        protected virtual string EnsureValidRequestsSortExpression(string sortExpression)
        {
            if (string.IsNullOrEmpty(sortExpression))
                return "sh_searchrequests.searchdate desc";

            string sortExpr = sortExpression.ToLower();
            if (!sortExpr.Equals("searchrequest") && !sortExpr.Equals("searchrequest asc") && !sortExpr.Equals("searchrequest desc") &&
               !sortExpr.Equals("result") && !sortExpr.Equals("result asc") && !sortExpr.Equals("result desc") &&
               !sortExpr.Equals("pagefrom") && !sortExpr.Equals("pagefrom asc") && !sortExpr.Equals("pagefrom desc") &&
               !sortExpr.Equals("pagerequest") && !sortExpr.Equals("pagerequest asc") && !sortExpr.Equals("pagerequest desc") &&
               !sortExpr.Equals("searchby") && !sortExpr.Equals("searchby asc") && !sortExpr.Equals("searchby desc") &&
               !sortExpr.Equals("searchbyip") && !sortExpr.Equals("searchbyip asc") && !sortExpr.Equals("searchbyip desc") &&
               !sortExpr.Equals("searchdate") && !sortExpr.Equals("searchdate asc") && !sortExpr.Equals("searchdate desc"))
            {
                sortExpr = "searchdate asc";
            }
            if (!sortExpr.StartsWith("sh_searchrequests"))
                sortExpr = "sh_searchrequests." + sortExpr;
            if (!sortExpr.StartsWith("sh_searchrequests.searchdate"))
                sortExpr += ", sh_searchrequests.searchdate desc";
            return sortExpr;
        }
    }
}
