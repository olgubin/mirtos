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
    public class ReportPageDetails
    {
        private int _hits = 0;
        public int Hits
        {
            get { return _hits; }
            set { _hits = value; }
        }

        private string _url = "";
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private DateTime _lastDate = DateTime.Now;
        public DateTime LastDate
        {
            get { return _lastDate; }
            set { _lastDate = value; }
        }

        public ReportPageDetails() { }

        public ReportPageDetails(int hits, string url, DateTime lastDate)
        {
            this.Hits = hits;
            this.Url = url;
            this.LastDate = lastDate;
        }
    }
}
