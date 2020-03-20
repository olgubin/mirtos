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
    public class SqlSearchProvider : SearchProvider
    {
        /// <summary>
        /// Добавляет запрос
        /// </summary>
        public override int InsertRequest(SearchRequestDetails request)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Search_InsertRequest", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@SearchDate", SqlDbType.DateTime).Value = request.SearchDate;
                cmd.Parameters.Add("@SearchRequest", SqlDbType.NVarChar).Value = request.SearchRequest;
                cmd.Parameters.Add("@Result", SqlDbType.Int).Value = request.Result;
                cmd.Parameters.Add("@PageFrom", SqlDbType.NVarChar).Value = request.PageFrom;
                cmd.Parameters.Add("@PageRequest", SqlDbType.NVarChar).Value = request.PageRequest;
                cmd.Parameters.Add("@SearchBy", SqlDbType.NVarChar).Value = request.SearchBy;
                cmd.Parameters.Add("@SearchByIP", SqlDbType.NVarChar).Value = request.SearchByIP;
                cmd.Parameters.Add("@SearchID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@SearchID"].Value;
            }
        }

        /// <summary>
        /// Возвращает общее количество поисковых запросов
        /// </summary>
        public override int GetRequestCount()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Search_GetRequestCount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// Получает все запросы
        /// </summary>
        public override List<SearchRequestDetails> GetSearchRequests(string sortExpression, int pageIndex, int pageSize)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Search_GetSearchRequests", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                sortExpression = EnsureValidRequestsSortExpression(sortExpression);
                int lowerBound = pageIndex * pageSize + 1;
                int upperBound = (pageIndex + 1) * pageSize;
                cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
                cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
                cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
                cn.Open();
                return GetRequestCollectionFromReader(ExecuteReader(cmd));
            }
        }
    }
}
