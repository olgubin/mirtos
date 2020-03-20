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
    internal class SqlProductTypeProvider: DataAccess
    {
        public static ProductTypeCollection GetProductTypes()
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductTypeGet", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetProductTypeCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static ProductType GetByProductTypeID(int ProductTypeID)
        {
            if (ProductTypeID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductTypeGetByProductTypeID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductTypeID", SqlDbType.Int).Value = ProductTypeID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetProductTypeFromReader(reader);
                else
                    return null;
            }
        }

        public static bool DeleteProductType(int ProductTypeID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductTypeDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductTypeID", SqlDbType.Int).Value = ProductTypeID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public static ProductType InsertProductType(string Type)
        {
            ProductType productType = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductTypeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = Type;
                cmd.Parameters.Add("@ProductTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int productTypeID = (int)cmd.Parameters["@ProductTypeID"].Value;
                    productType = GetByProductTypeID(productTypeID);
                }
                return productType;
            }
        }

        public static ProductType UpdateProductType(int ProductTypeID, string Type)
        {
            ProductType productType = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductTypeUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductTypeID", SqlDbType.Int).Value = ProductTypeID;
                cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = Type;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    productType = GetByProductTypeID(ProductTypeID);

                return productType;
            }
        }

        /// <summary>
        /// Возвращает коллекцию характеристик из ридера
        /// </summary>
        public static ProductTypeCollection GetProductTypeCollectionFromReader(IDataReader reader)
        {
            ProductTypeCollection productTypeCollection = new ProductTypeCollection();

            while (reader.Read())
                productTypeCollection.Add(GetProductTypeFromReader(reader));

            return productTypeCollection;
        }

        /// <summary>
        /// Возвращает характеристики из текущей записи ридера
        /// </summary>
        public static ProductType GetProductTypeFromReader(IDataReader reader)
        {
            ProductType productType = new ProductType();
            productType.ProductTypeID = GetInt(reader, "ProductTypeID");
            productType.Type = GetString(reader, "Type");

            return productType;
        }
    }
}
