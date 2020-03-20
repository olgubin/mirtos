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
    public class SqlNewslettersProvider : NewslettersProvider
    {
        /// <summary>
        /// ¬озвращает указанную страницу коллекции новостей
        /// </summary>
        public override List<NewsletterDetails> GetNewsletters(int pageIndex, int pageSize)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Newsletters_GetNewsletters", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                int lowerBound = pageIndex * pageSize + 1;
                int upperBound = (pageIndex + 1) * pageSize;
                cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
                cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
                cn.Open();
                return GetNewsletterCollectionFromReader(ExecuteReader(cmd), false);
            }
        }

        /// <summary>
        /// ¬озвращает указанное количество последних новостей
        /// </summary>
        public override List<NewsletterDetails> GetNewslettersLast(int count)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Newsletters_GetNewslettersLast", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Count", SqlDbType.Int).Value = count;
                cn.Open();
                return GetNewsletterCollectionFromReader(ExecuteReader(cmd), false);
            }
        }

        /// <summary>
        /// ¬озвращает все неразосланные новости
        /// </summary>
        public override List<NewsletterDetails> GetNewslettersNoSending()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Newsletters_GetNewslettersNoSending", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetNewsletterCollectionFromReader(ExecuteReader(cmd), false);
            }
        }

        /// <summary>
        /// ¬озвращает общее количество новостей
        /// </summary>
        public override int GetNewsletterCount()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Newsletters_GetNewsletterCount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// Returns an existing newsletter with the specified ID
        /// </summary>
        public override NewsletterDetails GetNewsletterByID(int newsletterID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Newsletters_GetNewsletterByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NewsletterID", SqlDbType.Int).Value = newsletterID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetNewsletterFromReader(reader);
                else
                    return null;
            }
        }

        /// <summary>
        /// Deletes a newsletter
        /// </summary>
        public override bool DeleteNewsletter(int newsletterID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Newsletters_DeleteNewsletter", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NewsletterID", SqlDbType.Int).Value = newsletterID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Updates a newsletter
        /// </summary>
        public override bool UpdateNewsletter(NewsletterDetails newsletter)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Newsletters_UpdateNewsletter", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = newsletter.AddedDate;
                cmd.Parameters.Add("@NewsletterID", SqlDbType.Int).Value = newsletter.ID;
                cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = newsletter.Subject;
                cmd.Parameters.Add("@Abstract", SqlDbType.NVarChar).Value = newsletter.Abstract;
                cmd.Parameters.Add("@HtmlBody", SqlDbType.NText).Value = newsletter.HtmlBody;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Creates a new newsletter
        /// </summary>
        public override int InsertNewsletter(NewsletterDetails newsletter)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Newsletters_InsertNewsletter", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = newsletter.AddedDate;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = newsletter.AddedBy;
                cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = newsletter.Subject;
                cmd.Parameters.Add("@Abstract", SqlDbType.NVarChar).Value = newsletter.Abstract;
                cmd.Parameters.Add("@HtmlBody", SqlDbType.NText).Value = newsletter.HtmlBody;
                cmd.Parameters.Add("@NewsletterID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@NewsletterID"].Value;
            }
        }

        /// <summary>
        /// ”станавливает признак новость разослана
        /// </summary>
        public override bool IsSendingNewsletter(int newsletterID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Newsletters_IsSendingNewsletter", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NewsletterID", SqlDbType.Int).Value = newsletterID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }
    }
}
