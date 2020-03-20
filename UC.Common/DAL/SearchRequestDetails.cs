using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace UC.DAL
{
    public class SearchRequestDetails
    {
        public SearchRequestDetails() { }

        public SearchRequestDetails(int searchID, DateTime searchDate, string searchRequest,
          int result, string pageFrom, string pageRequest, string searchBy,
          string searchByIP)
        {
            this.SearchID = searchID;
            this.SearchDate = searchDate;
            this.SearchRequest = searchRequest;
            this.Result = result;
            this.PageFrom = pageFrom;
            this.PageRequest = pageRequest;
            this.SearchBy = searchBy;
            this.SearchByIP = searchByIP;
        }

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

        private string _searchRequest = "";
        public string SearchRequest
        {
            get { return _searchRequest; }
            set { _searchRequest = value; }
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

        private string _searchBy = "";
        public string SearchBy
        {
            get { return _searchBy; }
            set { _searchBy = value; }
        }

        private string _searchByIP = "";
        public string SearchByIP
        {
            get { return _searchByIP; }
            set { _searchByIP = value; }
        }
    }
}