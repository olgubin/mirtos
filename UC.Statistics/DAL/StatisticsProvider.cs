using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;

namespace UC.DAL
{
    public abstract class StatisticsProvider : DataAccess
    {
        static private StatisticsProvider _instance = null;
        /// <summary>
        /// ���������� ������ �� ���������� ������������� � web.config
        /// </summary>
        static public StatisticsProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (StatisticsProvider)Activator.CreateInstance(
                       Type.GetType(Globals.Settings.Statistics.ProviderType));
                return _instance;
            }
        }

        public StatisticsProvider()
        {
            this.ConnectionString = Globals.Settings.Statistics.ConnectionString;
            this.EnableCaching = Globals.Settings.Statistics.EnableCaching;
            this.CacheDuration = Globals.Settings.Statistics.CacheDuration;
        }

        //������ ��� ������ � ��������� Request
        public abstract int InsertRequest(RequestDetails request);

        //������ ��� ������ � ��������� Session
        public abstract int InsertSession(SessionDetails request);
        public abstract bool AuthenticationSession(int sessionID, string userID);

        //������ ��� ������ � ����������� ���������� Page
        public abstract int InsertPage(PageDetails request);
        public abstract List<PageDetails> GetPages();

        //������ ��� ������ � ���������� �������� Bot
        public abstract List<BotDetails> GetBots();

        //������ ��� ������ � ������������ SearchEngine
        public abstract List<SearchEngineDetails> GetSearchEngines();

        //������ ��� ������ � ���������� ������� Keyword
        public abstract int InsertKeyword(KeywordDetails request);
        public abstract List<KeywordDetails> GetKeywords();

        //������ ��� ������ � ������� � ������� ��������� ���������� Site
        public abstract int InsertSite(SiteDetails request);
        public abstract List<SiteDetails> GetSites();

        //������ ��� ������ � IP (�������) � ������� ��������� ���������� Host
        public abstract int GetHostCount();
        public abstract List<HostDetails> GetHosts(string sortExpression, int pageIndex, int pageSize);
        public abstract HostDetails GetHostByIP(string IP);
        public abstract bool DeleteRequestsByHost(string IP);

        //������ ��� ������ � ��������
        public abstract StatisticsDetails ReportStatistics(DateTime firstDate, DateTime lastDate);
        public abstract List<ReportPageDetails> ReportPages(string sortExpression, int pageIndex, int pageSize);
        public abstract int ReportPagesCount();
        public abstract List<ReportRequestDetails> ReportRequestsByUrl(string sortExpression, int pageIndex, int pageSize, string url);
        public abstract int ReportRequestsByUrlCount(string url);
        public abstract List<ReportRequestDetails> ReportRequestsByIP(string sortExpression, int pageIndex, int pageSize, string ip);
        public abstract int ReportRequestsByIPCount(string ip);
        public abstract List<ReportRequestDetails> ReportRequestsByDate(string sortExpression, int pageIndex, int pageSize, DateTime firstDate, DateTime lastDate);
        public abstract int ReportRequestsByDateCount(DateTime firstDate, DateTime lastDate);
        public abstract List<ReportSearchDetails> ReportSearchesByDate(string sortExpression, int pageIndex, int pageSize, DateTime firstDate, DateTime lastDate);
        public abstract int ReportSearchesByDateCount(DateTime firstDate, DateTime lastDate);
        public abstract List<ReportSiteDetails> ReportSitesByDate(string sortExpression, int pageIndex, int pageSize, DateTime firstDate, DateTime lastDate);
        public abstract int ReportSitesByDateCount(DateTime firstDate, DateTime lastDate);

        /// <summary>
        /// ���������� ��������� �������� PageDetails c ������� ����������� �� DataReader
        /// </summary>
        protected virtual List<PageDetails> GetPageCollectionFromReader(IDataReader reader)
        {
            List<PageDetails> pages = new List<PageDetails>();
            while (reader.Read())
                pages.Add(GetPageFromReader(reader));
            return pages;
        }

        /// <summary>
        /// ���������� PageDetails ����������� ������� ������� ������ DataReader'�
        /// </summary>
        protected virtual PageDetails GetPageFromReader(IDataReader reader)
        {
            return new PageDetails(
               (int)reader["PageID"],
               reader["PageURL"].ToString());
        }

        /// <summary>
        /// ���������� ��������� �������� BotDetails c ������� ����������� �� DataReader
        /// </summary>
        protected virtual List<BotDetails> GetBotCollectionFromReader(IDataReader reader)
        {
            List<BotDetails> bots = new List<BotDetails>();
            while (reader.Read())
                bots.Add(GetBotFromReader(reader));
            return bots;
        }

        /// <summary>
        /// ���������� BotDetails ����������� ������� ������� ������ DataReader'�
        /// </summary>
        protected virtual BotDetails GetBotFromReader(IDataReader reader)
        {
            return new BotDetails(
               (int)reader["BotID"],
               (reader["SearchEngineID"] == DBNull.Value ? -1 : (int)reader["SearchEngineID"]),
               reader["Mask"].ToString());
        }

        /// <summary>
        /// ���������� ��������� �������� SearchEngineDetails c ������� ����������� �� DataReader
        /// </summary>
        protected virtual List<SearchEngineDetails> GetSearchEngineCollectionFromReader(IDataReader reader)
        {
            List<SearchEngineDetails> searchEngines = new List<SearchEngineDetails>();
            while (reader.Read())
                searchEngines.Add(GetSearchEngineFromReader(reader));
            return searchEngines;
        }

        /// <summary>
        /// ���������� SearchEngineDetails ����������� ������� ������� ������ DataReader'�
        /// </summary>
        protected virtual SearchEngineDetails GetSearchEngineFromReader(IDataReader reader)
        {
            return new SearchEngineDetails(
               (int)reader["SearchEngineID"],
               reader["Name"].ToString(),
               reader["SearchMask"].ToString(),
               reader["KeywordsMask"].ToString());
        }

        /// <summary>
        /// ���������� ��������� �������� KeywordDetails c ������� ����������� �� DataReader
        /// </summary>
        protected virtual List<KeywordDetails> GetKeywordCollectionFromReader(IDataReader reader)
        {
            List<KeywordDetails> keywords = new List<KeywordDetails>();
            while (reader.Read())
                keywords.Add(GetKeywordFromReader(reader));
            return keywords;
        }

        /// <summary>
        /// ���������� KeywordDetails ����������� ������� ������� ������ DataReader'�
        /// </summary>
        protected virtual KeywordDetails GetKeywordFromReader(IDataReader reader)
        {
            return new KeywordDetails(
               (int)reader["KeywordID"],
               reader["Keywords"].ToString());
        }

        /// <summary>
        /// ���������� ��������� �������� SiteDetails c ������� ����������� �� DataReader
        /// </summary>
        protected virtual List<SiteDetails> GetSiteCollectionFromReader(IDataReader reader)
        {
            List<SiteDetails> sites = new List<SiteDetails>();
            while (reader.Read())
                sites.Add(GetSiteFromReader(reader));
            return sites;
        }

        /// <summary>
        /// ���������� SiteDetails ����������� ������� ������� ������ DataReader'�
        /// </summary>
        protected virtual SiteDetails GetSiteFromReader(IDataReader reader)
        {
            return new SiteDetails(
               (int)reader["SiteID"],
               reader["Name"].ToString());
        }

        /// <summary>
        /// ���������� ��������� �������� HostDetails c ������� ����������� �� DataReader
        /// </summary>
        protected virtual List<HostDetails> GetHostCollectionFromReader(IDataReader reader)
        {
            List<HostDetails> hosts = new List<HostDetails>();
            while (reader.Read())
                hosts.Add(GetHostFromReader(reader));
            return hosts;
        }

        /// <summary>
        /// ���������� HostDetails ����������� ������� ������� ������ DataReader'�
        /// </summary>
        protected virtual HostDetails GetHostFromReader(IDataReader reader)
        {
            return new HostDetails(
                reader["IP"].ToString(),
                (DateTime)reader["FirstDate"],
                (DateTime)reader["LastDate"],
                (int)reader["SessionCount"],
                (int)reader["RequestCount"]);
        }

        /// <summary>
        /// ���������� ��������� ���������� ��� ��������� ��������
        /// </summary>
        protected virtual string EnsureValidHostsSortExpression(string sortExpression)
        {
            if (string.IsNullOrEmpty(sortExpression))
                return "ip";

            string sortExpr = sortExpression.ToLower();
            if (!sortExpr.Equals("ip") && !sortExpr.Equals("ip asc") && !sortExpr.Equals("ip desc") &&
               !sortExpr.Equals("firstdate") && !sortExpr.Equals("firstdate asc") && !sortExpr.Equals("firstdate desc") &&
               !sortExpr.Equals("lastdate") && !sortExpr.Equals("lastdate asc") && !sortExpr.Equals("lastdate desc") &&
               !sortExpr.Equals("sessioncount") && !sortExpr.Equals("sessioncount asc") && !sortExpr.Equals("sessioncount desc") &&
               !sortExpr.Equals("requestcount") && !sortExpr.Equals("requestcount asc") && !sortExpr.Equals("requestcount desc"))
            {
                sortExpr = "ip asc";
            }
            if (!sortExpr.StartsWith("ip"))
                sortExpr += ", ip desc";
            return sortExpr;
        }

        /// <summary>
        /// ���������� ����� - ���������� �� ��������� ������ StatisticsDetails ����������� ������� ������� ������ DataReader'�
        /// </summary>
        protected virtual StatisticsDetails GetStatisticsFromReader(IDataReader reader)
        {
            return new StatisticsDetails(
                (reader["FirstDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["FirstDate"]),
                (reader["LastDate"] == DBNull.Value ? DateTime.MaxValue : (DateTime)reader["LastDate"]),
                (reader["SessionsCount"] == DBNull.Value ? 0 : (int)reader["SessionsCount"]),
                (reader["HostsCount"] == DBNull.Value ? 0 : (int)reader["HostsCount"]),
                (reader["UniqueHostsCount"] == DBNull.Value ? 0 : (int)reader["UniqueHostsCount"]),
                (reader["SitesCount"] == DBNull.Value ? 0 : (int)reader["SitesCount"]),
                (reader["SearchCount"] == DBNull.Value ? 0 : (int)reader["SearchCount"]),
                (reader["HitsCount"] == DBNull.Value ? 0 : (int)reader["HitsCount"]),
                (reader["BotsCount"] == DBNull.Value ? 0 : (int)reader["BotsCount"]),
                (reader["BotsRequestsCount"] == DBNull.Value ? 0 : (int)reader["BotsRequestsCount"]));
        }

        /// <summary>
        /// ���������� ��������� ���������� ��� ������ �� ���������
        /// </summary>
        protected virtual string EnsureValidReportPagesSortExpression(string sortExpression)
        {
            if (string.IsNullOrEmpty(sortExpression))
                return "hits desc";

            string sortExpr = sortExpression.ToLower();
            if (!sortExpr.Equals("hits") && !sortExpr.Equals("hits asc") && !sortExpr.Equals("hits desc") &&
               !sortExpr.Equals("url") && !sortExpr.Equals("url asc") && !sortExpr.Equals("url desc") &&
               !sortExpr.Equals("lastdate") && !sortExpr.Equals("lastdate asc") && !sortExpr.Equals("lastdate desc"))
            {
                sortExpr = "hits desc";
            }
            if (!sortExpr.StartsWith("hits"))
                sortExpr += ", hits desc";
            return sortExpr;
        }

        /// <summary>
        /// ���������� ��������� �������� ReportPageDetails c ������� ����������� �� DataReader
        /// </summary>
        protected virtual List<ReportPageDetails> GetReportPageCollectionFromReader(IDataReader reader)
        {
            List<ReportPageDetails> pages = new List<ReportPageDetails>();
            while (reader.Read())
                pages.Add(GetReportPageFromReader(reader));
            return pages;
        }

        /// <summary>
        /// ���������� ����� �� ��������� ReportPageDetails ����������� ������� ������� ������ DataReader'�
        /// </summary>
        protected virtual ReportPageDetails GetReportPageFromReader(IDataReader reader)
        {
            return new ReportPageDetails(
                (reader["Hits"] == DBNull.Value ? 0 : (int)reader["Hits"]),
                (reader["URL"] == DBNull.Value ? "" : reader["URL"].ToString()),
                (reader["LastDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["LastDate"]));
        }

        /// <summary>
        /// ���������� ��������� ���������� ��� ������ �� ��������
        /// </summary>
        protected virtual string EnsureValidReportRequestsSortExpression(string sortExpression)
        {
            if (string.IsNullOrEmpty(sortExpression))
                return "requestdate desc";

            string sortExpr = sortExpression.ToLower();
            if (!sortExpr.Equals("requestdate") && !sortExpr.Equals("requestdate asc") && !sortExpr.Equals("requestdate desc") &&
               !sortExpr.Equals("ip") && !sortExpr.Equals("ip asc") && !sortExpr.Equals("ip desc") &&
               !sortExpr.Equals("userid") && !sortExpr.Equals("userid asc") && !sortExpr.Equals("userid desc") &&
               !sortExpr.Equals("url") && !sortExpr.Equals("url asc") && !sortExpr.Equals("url desc") &&
               !sortExpr.Equals("browserstring") && !sortExpr.Equals("browserstring asc") && !sortExpr.Equals("browserstring desc"))
            {
                sortExpr = "requestdate desc";
            }
            if (!sortExpr.StartsWith("requestdate"))
                sortExpr += ", requestdate desc";
            return sortExpr;
        }

        /// <summary>
        /// ���������� ��������� �������� ReportRequestDetails c ������� ����������� �� DataReader
        /// </summary>
        protected virtual List<ReportRequestDetails> GetReportRequestCollectionFromReader(IDataReader reader)
        {
            List<ReportRequestDetails> requests = new List<ReportRequestDetails>();
            while (reader.Read())
                requests.Add(GetReportRequestFromReader(reader));
            return requests;
        }

        /// <summary>
        /// ���������� ����� �� ��������� ReportRequestDetails ����������� ������� ������� ������ DataReader'�
        /// </summary>
        protected virtual ReportRequestDetails GetReportRequestFromReader(IDataReader reader)
        {
            return new ReportRequestDetails(
                (reader["RequestDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["RequestDate"]),
                (reader["IP"] == DBNull.Value ? "" : reader["IP"].ToString()),
                (reader["UserID"] == DBNull.Value ? "" : reader["UserID"].ToString()),
                (reader["URL"] == DBNull.Value ? "" : reader["URL"].ToString()),
                (reader["browserstring"] == DBNull.Value ? "" : reader["browserstring"].ToString()));
        }

        /// <summary>
        /// ���������� ��������� ���������� ��� ������ �� �����������
        /// </summary>
        protected virtual string EnsureValidReportSearchesSortExpression(string sortExpression)
        {
            if (string.IsNullOrEmpty(sortExpression))
                return "sessiondate desc";

            string sortExpr = sortExpression.ToLower();
            if (!sortExpr.Equals("sessiondate") && !sortExpr.Equals("sessiondate asc") && !sortExpr.Equals("sessiondate desc") &&
               !sortExpr.Equals("ip") && !sortExpr.Equals("ip asc") && !sortExpr.Equals("ip desc") &&
               !sortExpr.Equals("userid") && !sortExpr.Equals("userid asc") && !sortExpr.Equals("userid desc") &&
               !sortExpr.Equals("search") && !sortExpr.Equals("search asc") && !sortExpr.Equals("search desc") &&
               !sortExpr.Equals("keyword") && !sortExpr.Equals("keyword asc") && !sortExpr.Equals("keyword desc"))
            {
                sortExpr = "sessiondate desc";
            }
            if (!sortExpr.StartsWith("sessiondate"))
                sortExpr += ", sessiondate desc";
            return sortExpr;
        }

        /// <summary>
        /// ���������� ��������� �������� ReportSearchDetails c ������� ����������� �� DataReader
        /// </summary>
        protected virtual List<ReportSearchDetails> GetReportSearchCollectionFromReader(IDataReader reader)
        {
            List<ReportSearchDetails> searches = new List<ReportSearchDetails>();
            while (reader.Read())
                searches.Add(GetReportSearchFromReader(reader));
            return searches;
        }

        /// <summary>
        /// ���������� ����� �� ��������� ReportRequestDetails ����������� ������� ������� ������ DataReader'�
        /// </summary>
        protected virtual ReportSearchDetails GetReportSearchFromReader(IDataReader reader)
        {
            return new ReportSearchDetails(
                (reader["SessionDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["SessionDate"]),
                (reader["IP"] == DBNull.Value ? "" : reader["IP"].ToString()),
                (reader["UserID"] == DBNull.Value ? "" : reader["UserID"].ToString()),
                (reader["Search"] == DBNull.Value ? "" : reader["Search"].ToString()),
                (reader["Keyword"] == DBNull.Value ? "" : reader["Keyword"].ToString()));
        }

        /// <summary>
        /// ���������� ��������� ���������� ��� ������ �� ������
        /// </summary>
        protected virtual string EnsureValidReportSitesSortExpression(string sortExpression)
        {
            if (string.IsNullOrEmpty(sortExpression))
                return "sessiondate desc";

            string sortExpr = sortExpression.ToLower();
            if (!sortExpr.Equals("sessiondate") && !sortExpr.Equals("sessiondate asc") && !sortExpr.Equals("sessiondate desc") &&
               !sortExpr.Equals("ip") && !sortExpr.Equals("ip asc") && !sortExpr.Equals("ip desc") &&
               !sortExpr.Equals("userid") && !sortExpr.Equals("userid asc") && !sortExpr.Equals("userid desc") &&
               !sortExpr.Equals("site") && !sortExpr.Equals("site asc") && !sortExpr.Equals("site desc"))
            {
                sortExpr = "sessiondate desc";
            }
            if (!sortExpr.StartsWith("sessiondate"))
                sortExpr += ", sessiondate desc";
            return sortExpr;
        }

        /// <summary>
        /// ���������� ��������� �������� ReportSiteDetails c ������� ����������� �� DataReader
        /// </summary>
        protected virtual List<ReportSiteDetails> GetReportSiteCollectionFromReader(IDataReader reader)
        {
            List<ReportSiteDetails> sites = new List<ReportSiteDetails>();
            while (reader.Read())
                sites.Add(GetReportSiteFromReader(reader));
            return sites;
        }

        /// <summary>
        /// ���������� ����� �� ��������� ReportSiteDetails ����������� ������� ������� ������ DataReader'�
        /// </summary>
        protected virtual ReportSiteDetails GetReportSiteFromReader(IDataReader reader)
        {
            return new ReportSiteDetails(
                (reader["SessionDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["SessionDate"]),
                (reader["IP"] == DBNull.Value ? "" : reader["IP"].ToString()),
                (reader["UserID"] == DBNull.Value ? "" : reader["UserID"].ToString()),
                (reader["Site"] == DBNull.Value ? "" : reader["Site"].ToString()),
                (reader["Url"] == DBNull.Value ? "" : reader["Url"].ToString()));
        }
    }
}
