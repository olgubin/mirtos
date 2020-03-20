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
    public class HostDetails
    {
        private string _ip = "";
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private DateTime _firstDate = DateTime.Now;
        public DateTime FirstDate
        {
            get { return _firstDate; }
            set { _firstDate = value; }
        }

        private DateTime _lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return _lastDate; }
            set { _lastDate = value; }
        }

        private int _sessionCount = 0;
        public int SessionCount
        {
            get { return _sessionCount; }
            set { _sessionCount = value; }
        }

        private int _requestCount = 0;
        public int RequestCount
        {
            get { return _requestCount; }
            set { _requestCount = value; }
        }

        public HostDetails() { }

        public HostDetails(string ip, DateTime firstDate, DateTime lastDate, int sessionCount, int requestCount)
        {
            this.IP = ip; 
            this.FirstDate = firstDate;
            this.LastDate = lastDate;
            this.SessionCount = sessionCount;
            this.RequestCount = requestCount;
        }
    }
}
