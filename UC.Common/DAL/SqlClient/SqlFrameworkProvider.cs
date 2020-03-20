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
    public class SqlFrameworkProvider : FrameworkProvider
    {
        /// <summary>
        /// ���������� xml ��������������� ����� �����
        /// </summary>
        public override bool GetSiteMap(string siteUrl)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Framework_GetSiteMap", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SiteUrl", SqlDbType.NVarChar).Value = siteUrl;
                cn.Open();

                return GetSiteMapFromReader(cmd.ExecuteXmlReader());
            }
        }

        /// <summary>
        /// ���������� ���������� ��������� �������������
        /// </summary>
        public override int GetAnonymousUsersCount()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Framework_GetAnonymousUsersCount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// ���������� ���������� ��������� ��������
        /// </summary>
        public override int GetInnactivesProfileCount()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Framework_GetInnactiveProfileCount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// ���������� ���������� ������� �������
        /// </summary>
        public override int GetWebEventsCount()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Framework_GetWebEventsCount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// ������� ��������� ������������� �� ��������� ������
        /// </summary>
        public override bool DeleteAnonymousUsers(int addDays)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Framework_DeleteAnonymousUsers", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AddDays", SqlDbType.Int).Value = addDays;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// ������� ������� ���������� ��������� �������������
        /// </summary>
        public override bool DeleteInnactiveProfiles(int addDays)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Framework_DeleteInnactiveProfiles", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AddDays", SqlDbType.Int).Value = addDays;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// ������� �������
        /// </summary>
        public override bool DeleteWebEvents()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Framework_DeleteWebEvents", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }
    }
}
