using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using UC.BLL.Store;

namespace UC.DAL.Store
{
    internal class SqlProductFeaturedProvider : DataAccess
    {
        public static ProductFeatured GetByProductFeaturedID(int ProductFeaturedID)
        {
            if (ProductFeaturedID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductFeaturedGetByProductFeaturedID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductFeaturedID", SqlDbType.Int).Value = ProductFeaturedID;
                cn.Open();

                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetProductFeaturedFromReader(reader);
                else
                    return null;
            }
        }

        public static ProductFeaturedCollection GetProductFeatured(bool showHidden)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductFeaturedGet", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ShowHidden", SqlDbType.Bit).Value = showHidden;
                cn.Open();
                return GetProductFeaturedCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static ProductFeatured InsertProductFeatured
            (
            int ProductID, 
            string Description,
            int DisplayOrder
            )
        {
            ProductFeatured productFeatured = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductFeaturedInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cmd.Parameters.Add("@ProductFeaturedID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int productFeaturedID = (int)cmd.Parameters["@ProductFeaturedID"].Value;
                    productFeatured = GetByProductFeaturedID(productFeaturedID);
                }
                return productFeatured;
            }
        }

        public static ProductFeatured UpdateProductFeatured
            (
            int ProductFeaturedID, 
            int ProductID,
            string Description,
            int DisplayOrder
            )
        {
            ProductFeatured productFeatured = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductFeaturedUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductFeaturedID", SqlDbType.Int).Value = ProductFeaturedID;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                    productFeatured = GetByProductFeaturedID(ProductFeaturedID);

                return productFeatured;
            }
        }

        public static bool DeleteProductFeatured(int ProductFeaturedID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductFeaturedDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductFeaturedID", SqlDbType.Int).Value = ProductFeaturedID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Возвращает коллекцию связанных товаров
        /// </summary>
        public static ProductFeaturedCollection GetProductFeaturedCollectionFromReader(IDataReader reader)
        {
            ProductFeaturedCollection productFeaturedCollection = new ProductFeaturedCollection();

            while (reader.Read())
                productFeaturedCollection.Add(GetProductFeaturedFromReader(reader));

            return productFeaturedCollection;
        }

        /// <summary>
        /// Возвращает связанный товар
        /// </summary>
        public static ProductFeatured GetProductFeaturedFromReader(IDataReader reader)
        {
            ProductFeatured productFeatured = new ProductFeatured();
            productFeatured.ProductFeaturedID = GetInt(reader, "ProductFeaturedID");
            productFeatured.ProductID = GetInt(reader, "ProductID");
            productFeatured.Description = GetString(reader, "Description");
            productFeatured.DisplayOrder = GetInt(reader, "DisplayOrder");

            return productFeatured;
        }
    }
}
