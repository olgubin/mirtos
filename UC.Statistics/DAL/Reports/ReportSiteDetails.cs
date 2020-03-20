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
    public class ReportSiteDetails
    {
        private DateTime _sessionDate = DateTime.Now;
        public DateTime SessionDate
        {
            get { return _sessionDate; }
            set { _sessionDate = value; }
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

        private string _site = "";
        public string Site
        {
            get { return _site; }
            set { _site = value; }
        }

        private string _url = "";
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public ReportSiteDetails() { }

        public ReportSiteDetails(DateTime sessionDate, string ip, string userID, string site, string url)
        {
            this.SessionDate = sessionDate;
            this.Ip = ip;
            this.UserID = userID;
            this.Site = site;
            this.Url = url;
        }
    }
}
