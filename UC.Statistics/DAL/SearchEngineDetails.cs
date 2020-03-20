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
    public class SearchEngineDetails
    {
        private int _searchEngineID = 0;
        public int SearchEngineID
        {
            get { return _searchEngineID; }
            set { _searchEngineID = value; }
        }

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _searchMask = "";
        public string SearchMask
        {
            get { return _searchMask; }
            set { _searchMask = value; }
        }

        private string _keywordMask = "";
        public string KeywordMask
        {
            get { return _keywordMask; }
            set { _keywordMask = value; }
        }

        public SearchEngineDetails() { }

        public SearchEngineDetails(int searchEngineID, string name, string searchMask, string keywordMask)
        {
            this.SearchEngineID = searchEngineID;
            this.Name = name;
            this.SearchMask = searchMask;
            this.KeywordMask = keywordMask;
        }
    }
}
