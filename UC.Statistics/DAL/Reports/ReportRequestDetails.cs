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
    public class ReportRequestDetails
    {
        private DateTime _requestDate = DateTime.Now;
        public DateTime RequestDate
        {
            get { return _requestDate; }
            set { _requestDate = value; }
        }

        private string _ip = "";
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private string _userID = "";
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private string _url = "";
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private string _browserString = "";
        public string BrowserString
        {
            get { return _browserString; }
            set { _browserString = value; }
        }

        public ReportRequestDetails() { }

        public ReportRequestDetails(DateTime requestDate, string ip, string userID, string url, string browserString)
        {
            this.RequestDate = requestDate;
            this.Ip = ip;
            this.UserID = userID;
            this.Url = url;
            this.BrowserString = browserString;
        }
    }
}
