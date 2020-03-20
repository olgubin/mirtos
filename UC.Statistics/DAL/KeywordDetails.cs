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
    public class KeywordDetails
    {
        private int _keywordID = 0;
        public int KeywordID
        {
            get { return _keywordID; }
            set { _keywordID = value; }
        }

        private string _keywords = "";
        public string Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }

        public KeywordDetails() { }

        public KeywordDetails(int keywordID, string keywords)
        {
            this.KeywordID = keywordID;
            this.Keywords = keywords;
        }
    }
}
