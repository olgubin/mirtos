using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using UC.DAL;

namespace UC.BLL.Statistics
{
    public class Session : BaseStatistics
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

        public Session(int sessionID, string userID, string ip, string browserString, string refferalURL, 
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

        /***********************************
        * Статические методы
        ************************************/

        /// <summary>
        /// Получение идентификатора сессии
        /// </summary>
        public static int GetSessionID(HttpContext context)
        {
            int sessionID = -1;

            if (context.Session != null)
            {
                if (context.Session["SessionID"] != null)
                    sessionID = (int)context.Session["SessionID"];
                else
                {
                    sessionID = InsertSession(context);
                    context.Session["SessionID"] = sessionID;
                }
            }
            else
            {
                if (context.Request.Cookies["SessionID"] != null)
                    sessionID = Int32.Parse(context.Request.Cookies["SessionID"].Value);
                else
                {
                    sessionID = InsertSession(context);
                    context.Response.Cookies.Add(new HttpCookie("SessionID", sessionID.ToString()));
                }
            }

            if (sessionID > 0)
            {
                if (context.Request.IsAuthenticated)
                    AuthenticationSession(sessionID, context.User.Identity.Name);
            }

            return sessionID;
        }

        /// <summary>
        /// Добавление сессии
        /// </summary>
        public static int InsertSession(HttpContext context)
        {
            int sessionID = -1;
            int botID = -1;
            int searchEngineID = -1;
            int keywordID = -1;
            int siteID = -1;

            botID = Bot.GetBotID(context.Request.UserAgent);

            if (context.Request.UrlReferrer != null && context.Request.UrlReferrer.ToString() != "")
            {
                SearchEngine searchEngine = SearchEngine.GetSearchEngineByURL(context.Request.UrlReferrer.ToString());
                if (searchEngine != null)
                {
                    searchEngineID = searchEngine.SearchEngineID;
                    keywordID = Keyword.GetKeywordID(context, searchEngine.KeywordMask);
                }

                siteID = Site.GetSiteID(context.Request.UrlReferrer.Host);
            }

            sessionID = InsertSession(context.User.Identity.Name, context.Request.UserHostAddress,
                context.Request.UserAgent == null ? "" : context.Request.UserAgent,
                //context.Request.UrlReferrer == null ? "" : HttpUtility.UrlDecode(context.Request.UrlReferrer.OriginalString, System.Text.Encoding.UTF8),
                context.Request.UrlReferrer == null ? "" : context.Request.UrlReferrer.OriginalString,
                botID, siteID, searchEngineID, keywordID);

            return sessionID;
        }

        /// <summary>
        /// Добавление сессии
        /// </summary>
        public static int InsertSession(string userID, string ip, string browserString, string refferalURL, int botID,
            int siteID, int searchEngineID, int keywordID)
        {
            SessionDetails record = new SessionDetails(0, userID, ip, browserString, refferalURL, botID, siteID, searchEngineID, keywordID);
            int ret = StatisticsProvider.Instance.InsertSession(record);
            //BizObject.PurgeCacheItems("statistics_session");
            return ret;
        }

        /// <summary>
        /// Аутентификация сессии
        /// </summary>
        public static bool AuthenticationSession(int sessionID, string userID)
        {
            bool ret = StatisticsProvider.Instance.AuthenticationSession(sessionID, userID);
            //BizObject.PurgeCacheItems("statistics_session_" + sessionID.ToString());
            //BizObject.PurgeCacheItems("statistics_sessions");
            return ret;
        }
    }
}
