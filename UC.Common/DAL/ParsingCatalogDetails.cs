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
    public class ParsingCatalogDetails
    {
        public ParsingCatalogDetails() { }

        public ParsingCatalogDetails(int id, string title, string siteProviderType, DateTime updateDate)
        {
            this.ID = id;
            this.Title = title;
            this.SiteProviderType = siteProviderType;
            this.UpdateDate = updateDate;
        }

        private int _id = 0;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _title = "";
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _siteProviderType = "";
        public string SiteProviderType
        {
            get { return _siteProviderType; }
            set { _siteProviderType = value; }
        }

        private DateTime _updateDate = DateTime.Now;
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
    }
}