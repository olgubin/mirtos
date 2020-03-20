using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using UC.BLL.Gallery;

namespace UC.DAL.Gallery
{
    internal class SqlPortfolioProvider: DataAccess
    {
        public static Portfolio GetByPortfolioID(int PortfolioID)
        {
            if (PortfolioID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Portfolio_GetByPortfolioID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PortfolioID", SqlDbType.Int).Value = PortfolioID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetPortfolioFromReader(reader);
                else
                    return null;
            }
        }

        public static PortfolioCollection GetPortfolio()
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Portfolio_Get", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetPortfolioCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static bool DeletePortfolio(int PortfolioID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Portfolio_Delete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PortfolioID", SqlDbType.Int).Value = PortfolioID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public static Portfolio InsertPortfolio
            (
            string Description,
            string ImageUrl,
            int DisplayOrder
            )
        {
            Portfolio portfolio = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Portfolio_Insert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ImageUrl;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cmd.Parameters.Add("@PortfolioID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int productAttributeID = (int)cmd.Parameters["@PortfolioID"].Value;
                    portfolio = GetByPortfolioID(productAttributeID);
                }
                return portfolio;
            }
        }

        public static Portfolio UpdatePortfolio
            (
            int PortfolioID,
            string Description,
            string ImageUrl,
            int DisplayOrder
            )
        {
            Portfolio portfolio = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Portfolio_Update", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PortfolioID", SqlDbType.Int).Value = PortfolioID;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ImageUrl;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    portfolio = GetByPortfolioID(PortfolioID);

                return portfolio;
            }
        }

        /// <summary>
        /// Возвращает коллекцию характеристик из ридера
        /// </summary>
        public static PortfolioCollection GetPortfolioCollectionFromReader(IDataReader reader)
        {
            PortfolioCollection portfolioCollection = new PortfolioCollection();

            while (reader.Read())
                portfolioCollection.Add(GetPortfolioFromReader(reader));

            return portfolioCollection;
        }

        /// <summary>
        /// Возвращает характеристики из текущей записи ридера
        /// </summary>
        public static Portfolio GetPortfolioFromReader(IDataReader reader)
        {
            Portfolio portfolio = new Portfolio();
            portfolio.PortfolioID = GetInt(reader, "PortfolioID");
            portfolio.Description = GetString(reader, "Description");
            portfolio.ImageUrl = GetString(reader, "ImageUrl");
            portfolio.DisplayOrder = GetInt(reader, "DisplayOrder");

            return portfolio;
        }
    }
}
