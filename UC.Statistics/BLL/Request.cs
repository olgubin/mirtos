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
using UC.IpBlocking.BLL;

namespace UC.BLL.Statistics
{
    public class Request : BaseStatistics
    {
        private int _requestID = 0;
        public int RequestID
        {
            get { return _requestID; }
            set { _requestID = value; }
        }

        private int _sessionID = 0;
        public int SessionID
        {
            get { return _sessionID; }
            set { _sessionID = value; }
        }

        private DateTime _requestDate = DateTime.Now;
        public DateTime RequestDate
        {
            get { return _requestDate; }
            set { _requestDate = value; }
        }

        private int _pageID = 0;
        public int PageID
        {
            get { return _pageID; }
            set { _pageID = value; }
        }

        private string _queryString = "";
        public string QueryString
        {
            get { return _queryString; }
            set { _queryString = value; }
        }

        private bool _isPostBack = false;
        public bool IsPostBack
        {
            get { return _isPostBack; }
            set { _isPostBack = value; }
        }

        private bool _isAuthenticate = false;
        public bool IsAuthenticate
        {
            get { return _isAuthenticate; }
            set { _isAuthenticate = value; }
        }

        public Request(int requestID, int sessionID, DateTime requestDate, int pageID, string queryString,
            bool isPostBack, bool isAuthenticate)
        {
            this.RequestID = requestID;
            this.SessionID = sessionID;
            this.RequestDate = requestDate;
            this.PageID = pageID;
            this.QueryString = queryString;
            this.IsPostBack = isPostBack;
            this.IsAuthenticate = isAuthenticate;
        }

        /***********************************
        * —татические методы
        ************************************/

        /// <summary>
        /// ќбработка http запроса
        /// </summary>
        public static void DoRequest(HttpContext context)
        {
            bool add = true;

            foreach (PageElement item in Settings.Pages)
            {
                if (context.Request.RawUrl.IndexOf(item.Page) != -1)
                {
                    add = false;
                    break;
                }
            }

            //не включаем запросы к файлам ресурсов захламл€ющие базу
            //if (context.Request.RawUrl.IndexOf("WebResource.axd") == -1 & context.Request.RawUrl.IndexOf("psimage.aspx") == -1)
            if (add)
            {
                // добавлено специально чтобы не фиксировать статистику ботов
                if (Bot.GetBotID(context.Request.UserAgent) <= 0)
                {
                    // добавлено специально чтобы не фиксировать статистику с игнорируемых хостов
                    //if (Host.GetIgnoreHostByIP(context.Request.UserHostAddress) == null)
                    if (!BlockIpManager.CheckIgnoreIp(context.Request.UserHostAddress))
                    {
                        int sessionID = Session.GetSessionID(context);
                        if (sessionID < 1) { return; }

                        int pageID = Page.GetPageID(context.Request.RawUrl.IndexOf("?") != -1 ? context.Request.RawUrl.Substring(0, context.Request.RawUrl.IndexOf("?")) : context.Request.RawUrl);
                        if (pageID < 1) { return; }

                        InsertRequest(sessionID, pageID, context.Request.QueryString.ToString(), context.Request.HttpMethod == "POST",
                            context.Request.IsAuthenticated);
                    }
                }
            }
        }

        /// <summary>
        /// ƒобавление запроса
        /// </summary>
        public static int InsertRequest(int sessionID, int pageID, string queryString, bool isPostBack, bool isAuthenticate)
        {
            RequestDetails record = new RequestDetails(0, sessionID, DateTime.Now, pageID, queryString, isPostBack, isAuthenticate);
            int ret = StatisticsProvider.Instance.InsertRequest(record);
            BizObject.PurgeCacheItems("statistics_request");
            return ret;
        }

        /// <summary>
        /// ƒобавление запроса
        /// </summary>
        public static bool DeleteRequestsByHost(string IP)
        {
            bool ret = StatisticsProvider.Instance.DeleteRequestsByHost(IP);
            BizObject.PurgeCacheItems("statistics_request");
            return ret;
        }
    }
}
