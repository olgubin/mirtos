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
    public class SessionDetails
    {
        private int _sessionID = 0;
        public int SessionID
        {
            get { return _sessionID; }
            set { _sessionID = value; }
        }

        private string _userID = "";
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private string _ip = "";
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private string _browserString = "";
        public string BrowserString
        {
            get { return _browserString; }
            set { _browserString = value; }
        }

        private string _refferalURL = "";
        public string RefferalURL
        {
            get { return _refferalURL; }
            set { _refferalURL = value; }
        }

        private int _botID = 0;
        public int BotID
        {
            get { return _botID; }
            set { _botID = value; }
        }

        private int _siteID = 0;
        public int SiteID
        {
            get { return _siteID; }
            set { _siteID = value; }
        }

        private int _searchEngineID = 0;
        public int SearchEngineID
        {
            get { return _searchEngineID; }
            set { _searchEngineID = value; }
        }

        private int _keywordID = 0;
        public int KeywordID
        {
            get { return _keywordID; }
            set { _keywordID = value; }
        }

        public SessionDetails() { }

        public SessionDetails(int sessionID, string userID, string ip, string browserString, string refferalURL, 
            int botID, int siteID, int searchEngineID, int keywordID)
        {
            this.SessionID = sessionID;
            this.UserID = userID;
            this.IP = ip;
            this.BrowserString = browserString;
            this.RefferalURL = refferalURL;
            this.BotID = botID;
            this.SiteID = siteID;
            this.SearchEngineID = searchEngineID;
            this.KeywordID = keywordID;
        }
    }
}
