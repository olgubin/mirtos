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
    public class BotDetails
    {
        private int _botID = 0;
        public int BotID
        {
            get { return _botID; }
            set { _botID = value; }
        }
        
        private int _searchEngineID = 0;
        public int SearchEngineID
        {
            get { return _searchEngineID; }
            set { _searchEngineID = value; }
        }

        private string _mask = "";
        public string Mask
        {
            get { return _mask; }
            set { _mask = value; }
        }

        public BotDetails() { }
        
        public BotDetails(int botID, int searchEngineID, string mask)
        {
            this.BotID = botID;
            this.SearchEngineID = searchEngineID;
            this.Mask = mask;
        }
    }
}
