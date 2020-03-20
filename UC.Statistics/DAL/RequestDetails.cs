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
    public class RequestDetails
    {
        private int _requestID = 0;
        public int RequestID
        {
            get { return _requestID; }
            set { _requestID = value; }
        }

        private int _sessionID = 0;
        public int SessionID
        {
            get { return _sessionID; }
            set { _sessionID = value; }
        }

        private DateTime _requestDate = DateTime.Now;
        public DateTime RequestDate
        {
            get { return _requestDate; }
            set { _requestDate = value; }
        }

        private int _pageID = 0;
        public int PageID
        {
            get { return _pageID; }
            set { _pageID = value; }
        }

        private string _queryString = "";
        public string QueryString
        {
            get { return _queryString; }
            set { _queryString = value; }
        }

        private bool _isPostBack = false;
        public bool IsPostBack
        {
            get { return _isPostBack; }
            set { _isPostBack = value; }
        }

        private bool _isAuthenticate = false;
        public bool IsAuthenticate
        {
            get { return _isAuthenticate; }
            set { _isAuthenticate = value; }
        }

        public RequestDetails() { }

        public RequestDetails(int requestID, int sessionID, DateTime requestDate, int pageID, string queryString,
            bool isPostBack, bool isAuthenticate)
        {
            this.RequestID = requestID;
            this.SessionID = sessionID;
            this.RequestDate = requestDate;
            this.PageID = pageID;
            this.QueryString = queryString;
            this.IsPostBack = isPostBack;
            this.IsAuthenticate = isAuthenticate;
        }
    }
}
