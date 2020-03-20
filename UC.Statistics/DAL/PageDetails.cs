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
    public class PageDetails
    {
        private int _pageID = 0;
        public int PageID
        {
            get { return _pageID; }
            set { _pageID = value; }
        }

        private string _pageURL = "";
        public string PageURL
        {
            get { return _pageURL; }
            set { _pageURL = value; }
        }

        public PageDetails() { }

        public PageDetails(int pageID, string pageURL)
        {
            this.PageID = pageID;
            this.PageURL = pageURL;
        }
    }
}
