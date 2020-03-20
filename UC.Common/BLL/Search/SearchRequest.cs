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

namespace UC.BLL.Search
{
    public class SearchRequest : BaseSearch
    {
        private int _searchID = 0;
        public int SearchID
        {
            get { return _searchID; }
            set { _searchID = value; }
        }

        private DateTime _searchDate = DateTime.Now;
        public DateTime SearchDate
        {
            get { return _searchDate; }
            set { _searchDate = value; }
        }

        private string _request = "";
        public string Request
        {
            get { return _request; }
            set { _request = value; }
        }

        private int _result = 0;
        public int Result
        {
            get { return _result; }
            set { _result = value; }
        }

        private string _pageFrom = "";
        public string PageFrom
        {
            get { return _pageFrom; }
            set { _pageFrom = value; }
        }

        private string _pageRequest = "";
        public string PageRequest
        {
            get { return _pageRequest; }
            set { _pageRequest = value; }
        }

        private string _searchBy;
        public string SearchBy
        {
            get { return _searchBy; }
            set { _searchBy = value; }
        }

        private string _searchByIP;
        public string SearchByIP
        {
            get { return _searchByIP; }
            set { _searchByIP = value; }
        }

        public SearchRequest(int searchID, DateTime searchDate, string request,
          int result, string pageFrom, string pageRequest, string searchBy,
          string searchByIP)
        {
            this.SearchID = searchID;
            this.SearchDate = searchDate;
            this.Request = request;
            this.Result = result;
            this.PageFrom = pageFrom;
            this.PageRequest = pageRequest;
            this.SearchBy = searchBy;
            this.SearchByIP = searchByIP;
        }

        /***********************************
        * Static methods
        ************************************/

        /// <summary>
        /// Возвращает коллекцию всех поисковых запросов
        /// </summary>
        public static List<SearchRequest> GetSearchRequests(string sortExpression, int startRowIndex, int maximumRows)
        {
            if (sortExpression == null)
                sortExpression = "";

            List<SearchRequest> requests = null;
            string key = "Search_Requests_" + sortExpression + "_" + startRowIndex.ToString() + "_" + maximumRows.ToString();

            if (BaseSearch.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                requests = (List<SearchRequest>)BizObject.Cache[key];
            }
            else
            {
                List<SearchRequestDetails> recordset = SiteProvider.Search.GetSearchRequests(
                   sortExpression, GetPageIndex(startRowIndex, maximumRows), maximumRows);
                requests = GetSearchRequestListFromSearchRequestDetailsList(recordset);
                BaseSearch.CacheData(key, requests);
            }
            return requests;
        }

        /// <summary>
        /// Возвращает общее количество запросов
        /// </summary>
        public static int GetRequestCount()
        {
            int requestCount = 0;
            string key = "Search_RequestCount";

            if (BaseSearch.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                requestCount = (int)BizObject.Cache[key];
            }
            else
            {
                requestCount = SiteProvider.Search.GetRequestCount();
                BaseSearch.CacheData(key, requestCount);
            }
            return requestCount;
        }

        /// <summary>
        /// Добавляет новый запрос
        /// </summary>
        public static int InsertSearchRequest(string searchRequest, int result)
        {
            searchRequest = BizObject.ConvertNullToEmptyString(searchRequest);

            string urlReferrer = "";

            if (HttpContext.Current.Request.UrlReferrer != null)
            {
                urlReferrer = HttpUtility.UrlDecode(HttpContext.Current.Request.UrlReferrer.OriginalString, System.Text.Encoding.Default);
            }
            else
            {
                urlReferrer = "";
            }

            SearchRequestDetails record = new SearchRequestDetails(0, DateTime.Now, searchRequest,
               result, urlReferrer, "", BizObject.CurrentUserName, BizObject.CurrentUserIP);

            int ret = SiteProvider.Search.InsertRequest(record);

            BizObject.PurgeCacheItems("search_request");
            return ret;
        }

        /// <summary>
        /// Вовзвращает объект SearchRequest заполненный данными из SearchRequestDetails
        /// </summary>
        private static SearchRequest GetSearchRequestFromSearchRequestDetails(SearchRequestDetails record)
        {
            if (record == null)
                return null;
            else
            {
                return new SearchRequest(record.SearchID, record.SearchDate, record.SearchRequest,
                   record.Result, record.PageFrom, record.PageRequest, record.SearchBy,
                   record.SearchByIP);
            }
        }

        /// <summary>
        /// Возвращает список объектов SearchRequest заполненного из списка объектов SearchRequestDetails
        /// </summary>
        private static List<SearchRequest> GetSearchRequestListFromSearchRequestDetailsList(List<SearchRequestDetails> recordset)
        {
            List<SearchRequest> searchrequests = new List<SearchRequest>();
            foreach (SearchRequestDetails record in recordset)
                searchrequests.Add(GetSearchRequestFromSearchRequestDetails(record));
            return searchrequests;
        }
    }
}