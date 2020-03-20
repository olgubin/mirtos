using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Caching;

namespace UC.DAL.SqlClient
{
    public class SqlStatisticsProvider : StatisticsProvider
    {
        /// <summary>
        /// Добавление запроса
        /// </summary>
        public override int InsertRequest(RequestDetails request)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_InsertRequest", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SessionID", SqlDbType.Int).Value = request.SessionID;
                cmd.Parameters.Add("@RequestDate", SqlDbType.DateTime).Value = request.RequestDate;
                cmd.Parameters.Add("@PageID", SqlDbType.Int).Value = request.PageID;
                cmd.Parameters.Add("@QueryString", SqlDbType.NVarChar).Value = request.QueryString;
                cmd.Parameters.Add("@IsPostBack", SqlDbType.Bit).Value = request.IsPostBack;
                cmd.Parameters.Add("@IsAuthenticate", SqlDbType.Bit).Value = request.IsAuthenticate;
                cmd.Parameters.Add("@RequestID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@RequestID"].Value;
            }
        }

        /// <summary>
        /// Добавление сессии
        /// </summary>
        public override int InsertSession(SessionDetails request)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_InsertSession", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = request.UserID;
                cmd.Parameters.Add("@IP", SqlDbType.NVarChar).Value = request.IP;
                cmd.Parameters.Add("@BrowserString", SqlDbType.NVarChar).Value = request.BrowserString;
                cmd.Parameters.Add("@RefferalURL", SqlDbType.NVarChar).Value = request.RefferalURL;
                if (request.BotID > 0) 
                    cmd.Parameters.Add("@BotID", SqlDbType.Int).Value = request.BotID;
                else
                    cmd.Parameters.Add("@BotID", SqlDbType.Int).Value = DBNull.Value;
                if (request.SiteID > 0) 
                    cmd.Parameters.Add("@SiteID", SqlDbType.Int).Value = request.SiteID;
                else
                    cmd.Parameters.Add("@SiteID", SqlDbType.Int).Value = DBNull.Value;
                if (request.SearchEngineID > 0) 
                    cmd.Parameters.Add("@SearchEngineID", SqlDbType.Int).Value = request.SearchEngineID;
                else
                    cmd.Parameters.Add("@SearchEngineID", SqlDbType.Int).Value = DBNull.Value;
                if (request.KeywordID > 0) 
                    cmd.Parameters.Add("@KeywordID", SqlDbType.Int).Value = request.KeywordID;
                else
                    cmd.Parameters.Add("@KeywordID", SqlDbType.Int).Value = DBNull.Value;

                cmd.Parameters.Add("@SessionID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@SessionID"].Value;
            }
        }

        /// <summary>
        /// Аутентификация сессии
        /// </summary>
        public override bool AuthenticationSession(int sessionID, string userID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_AuthenticationSession", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SessionID", SqlDbType.Int).Value = sessionID;
                cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = userID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }


        /// <summary>
        /// Добавление посещаемой страницы
        /// </summary>
        public override int InsertPage(PageDetails request)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_InsertPage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PageURL", SqlDbType.NVarChar).Value = request.PageURL;
                cmd.Parameters.Add("@PageID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@PageID"].Value;
            }
        }

        /// <summary>
        /// Возвращает коллекцию посещаемых страниц Page
        /// </summary>
        public override List<PageDetails> GetPages()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_GetPages", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetPageCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Возвращает коллекцию поисковых роботов Bot
        /// </summary>
        public override List<BotDetails> GetBots()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_GetBots", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetBotCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Возвращает коллекцию поисковиков SearchEngine
        /// </summary>
        public override List<SearchEngineDetails> GetSearchEngines()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_GetSearchEngines", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetSearchEngineCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Добавление поисковой фразы Keyword
        /// </summary>
        public override int InsertKeyword(KeywordDetails request)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_InsertKeyword", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Keywords", SqlDbType.NVarChar).Value = request.Keywords;
                cmd.Parameters.Add("@KeywordID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@KeywordID"].Value;
            }
        }

        /// <summary>
        /// Возвращает коллекцию поисковых фраз Keyword
        /// </summary>
        public override List<KeywordDetails> GetKeywords()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_GetKeywords", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetKeywordCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Добавление сайта с которого пришел посетитель Site
        /// </summary>
        public override int InsertSite(SiteDetails request)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_InsertSite", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = request.Name;
                cmd.Parameters.Add("@SiteID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@SiteID"].Value;
            }
        }

        /// <summary>
        /// Возвращает коллекцию сайтов с которых приходили посетители Site
        /// </summary>
        public override List<SiteDetails> GetSites()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_GetSites", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetSiteCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Возвращает коллекцию хостов с которых приходили посетители Host
        /// </summary>
        public override List<HostDetails> GetHosts(string sortExpression, int pageIndex, int pageSize)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_GetHosts", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                sortExpression = EnsureValidHostsSortExpression(sortExpression);
                int lowerBound = pageIndex * pageSize + 1;
                int upperBound = (pageIndex + 1) * pageSize;
                cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
                cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
                cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
                cn.Open();
                return GetHostCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Возвращает общее количество хостов
        /// </summary>
        public override int GetHostCount()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_GetHostCount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// Возвращает хочт из списка по ИП
        /// </summary>
        public override HostDetails GetHostByIP(string IP)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_GetHostByIP", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IP", SqlDbType.NVarChar).Value = IP;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetHostFromReader(reader);
                else
                    return null;
            }
        }

        /// <summary>
        /// Удаляет запросы и сессии указанного ИП
        /// </summary>
        public override bool DeleteRequestsByHost(string IP)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_DeleteRequestsByHost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IP", SqlDbType.NVarChar).Value = IP;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Возвращает отчет - статистика за указанный период времени
        /// </summary>
        public override StatisticsDetails ReportStatistics(DateTime firstDate, DateTime lastDate)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_ReportStatistics", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FirstDate", SqlDbType.DateTime).Value = firstDate;
                cmd.Parameters.Add("@LastDate", SqlDbType.DateTime).Value = lastDate;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetStatisticsFromReader(reader);
                else
                    return null;
            }
        }

        /// <summary>
        /// Возвращает коллекцию страниц с харакетристиками посещаемости
        /// </summary>
        public override List<ReportPageDetails> ReportPages(string sortExpression, int pageIndex, int pageSize)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_ReportPages", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                sortExpression = EnsureValidReportPagesSortExpression(sortExpression);
                int lowerBound = pageIndex * pageSize + 1;
                int upperBound = (pageIndex + 1) * pageSize;
                cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
                cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
                cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
                cn.Open();
                return GetReportPageCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Возвращает общее количество страниц в статистике
        /// </summary>
        public override int ReportPagesCount()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_ReportPagesCount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// Возвращает коллекцию запросов
        /// </summary>
        public override List<ReportRequestDetails> ReportRequestsByUrl(string sortExpression, int pageIndex, int pageSize, string url)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_ReportRequestsByUrl", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                sortExpression = EnsureValidReportRequestsSortExpression(sortExpression);
                int lowerBound = pageIndex * pageSize + 1;
                int upperBound = (pageIndex + 1) * pageSize;
                cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
                cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
                cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
                cmd.Parameters.Add("@url", SqlDbType.NVarChar).Value = url;
                cn.Open();
                return GetReportRequestCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Возвращает общее количество запросов
        /// </summary>
        public override int ReportRequestsByUrlCount(string url)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_ReportRequestsByUrlCount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@url", SqlDbType.NVarChar).Value = url;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// Возвращает коллекцию запросов для указанного IP
        /// </summary>
        public override List<ReportRequestDetails> ReportRequestsByIP(string sortExpression, int pageIndex, int pageSize, string ip)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_ReportRequestsByIP", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                sortExpression = EnsureValidReportRequestsSortExpression(sortExpression);
                int lowerBound = pageIndex * pageSize + 1;
                int upperBound = (pageIndex + 1) * pageSize;
                cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
                cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
                cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
                cmd.Parameters.Add("@ip", SqlDbType.NVarChar).Value = ip;
                cn.Open();
                return GetReportRequestCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Возвращает общее количество запросов
        /// </summary>
        public override int ReportRequestsByIPCount(string ip)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_ReportRequestsByIPCount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ip", SqlDbType.NVarChar).Value = ip;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// Возвращает коллекцию запросов за период
        /// </summary>
        public override List<ReportRequestDetails> ReportRequestsByDate(string sortExpression, int pageIndex, int pageSize, DateTime firstDate, DateTime lastDate)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_ReportRequestsByDate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                sortExpression = EnsureValidReportRequestsSortExpression(sortExpression);
                int lowerBound = pageIndex * pageSize + 1;
                int upperBound = (pageIndex + 1) * pageSize;
                cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
                cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
                cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
                cmd.Parameters.Add("@firstdate", SqlDbType.DateTime).Value = firstDate;
                cmd.Parameters.Add("@lastdate", SqlDbType.DateTime).Value = lastDate;
                cn.Open();
                return GetReportRequestCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Возвращает общее количество запросов за период
        /// </summary>
        public override int ReportRequestsByDateCount(DateTime firstDate, DateTime lastDate)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_ReportRequestsByDateCount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@firstdate", SqlDbType.DateTime).Value = firstDate;
                cmd.Parameters.Add("@lastdate", SqlDbType.DateTime).Value = lastDate;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// Возвращает коллекцию приходов с поисковых систем з апериод
        /// </summary>
        public override List<ReportSearchDetails> ReportSearchesByDate(string sortExpression, int pageIndex, int pageSize, DateTime firstDate, DateTime lastDate)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_ReportSearchesByDate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                sortExpression = EnsureValidReportSearchesSortExpression(sortExpression);
                int lowerBound = pageIndex * pageSize + 1;
                int upperBound = (pageIndex + 1) * pageSize;
                cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
                cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
                cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
                cmd.Parameters.Add("@firstdate", SqlDbType.DateTime).Value = firstDate;
                cmd.Parameters.Add("@lastdate", SqlDbType.DateTime).Value = lastDate;
                cn.Open();
                return GetReportSearchCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Возвращает общее количество приходов с поисковых систем за период
        /// </summary>
        public override int ReportSearchesByDateCount(DateTime firstDate, DateTime lastDate)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_ReportSearchesByDateCount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@firstdate", SqlDbType.DateTime).Value = firstDate;
                cmd.Parameters.Add("@lastdate", SqlDbType.DateTime).Value = lastDate;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// Возвращает коллекцию приходов с других сайтов за период
        /// </summary>
        public override List<ReportSiteDetails> ReportSitesByDate(string sortExpression, int pageIndex, int pageSize, DateTime firstDate, DateTime lastDate)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_ReportSitesByDate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                sortExpression = EnsureValidReportSitesSortExpression(sortExpression);
                int lowerBound = pageIndex * pageSize + 1;
                int upperBound = (pageIndex + 1) * pageSize;
                cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
                cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
                cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
                cmd.Parameters.Add("@firstdate", SqlDbType.DateTime).Value = firstDate;
                cmd.Parameters.Add("@lastdate", SqlDbType.DateTime).Value = lastDate;
                cn.Open();
                return GetReportSiteCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Возвращает общее количество приходов с других сайтов за период
        /// </summary>
        public override int ReportSitesByDateCount(DateTime firstDate, DateTime lastDate)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Statistics_ReportSitesByDateCount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@firstdate", SqlDbType.DateTime).Value = firstDate;
                cmd.Parameters.Add("@lastdate", SqlDbType.DateTime).Value = lastDate;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }
    }
}
