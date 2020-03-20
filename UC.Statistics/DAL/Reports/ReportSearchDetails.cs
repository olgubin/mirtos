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
    public class ReportSearchDetails
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

        private string _search = "";
        public string Search
        {
            get { return _search; }
            set { _search = value; }
        }

        private string _keyword = "";
        public string Keyword
        {
            get { return _keyword; }
            set { _keyword = value; }
        }

        public ReportSearchDetails() { }

        public ReportSearchDetails(DateTime sessionDate, string ip, string userID, string search, string keyword)
        {
            this.SessionDate = sessionDate;
            this.Ip = ip;
            this.UserID = userID;
            this.Search = search;
            this.Keyword = keyword;
        }
    }
}
