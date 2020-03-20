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
    public class SiteDetails
    {
        private int _siteID = 0;
        public int SiteID
        {
            get { return _siteID; }
            set { _siteID = value; }
        }

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public SiteDetails() { }

        public SiteDetails(int siteID, string name)
        {
            this.SiteID = siteID;
            this.Name = name;
        }
    }
}
