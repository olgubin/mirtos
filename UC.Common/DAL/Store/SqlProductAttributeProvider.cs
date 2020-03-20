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
    internal class SqlProductAttributeProvider: DataAccess
    {
        public static ProductAttribute GetByProductAttributeID(int ProductAttributeID)
        {
            if (ProductAttributeID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductAttributeGetByProductAttributeID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductAttributeID", SqlDbType.Int).Value = ProductAttributeID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetProductAttributeFromReader(reader);
                else
                    return null;
            }
        }

        public static ProductAttributeCollection GetProductAttributes()
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductAttributeGet", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetProductAttributeCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static bool DeleteProductAttribute(int ProductAttributeID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductAttributeDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductAttributeID", SqlDbType.Int).Value = ProductAttributeID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public static ProductAttribute InsertProductAttribute(string Name)
        {
            ProductAttribute productAttribute = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductAttributeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                cmd.Parameters.Add("@ProductAttributeID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int productAttributeID = (int)cmd.Parameters["@ProductAttributeID"].Value;
                    productAttribute = GetByProductAttributeID(productAttributeID);
                }
                return productAttribute;
            }
        }

        public static ProductAttribute UpdateProductAttribute(int ProductAttributeID, string Name)
        {
            ProductAttribute productAttribute = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductAttributeUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductAttributeID", SqlDbType.Int).Value = ProductAttributeID;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    productAttribute = GetByProductAttributeID(ProductAttributeID);

                return productAttribute;
            }
        }

        /// <summary>
        /// Возвращает коллекцию характеристик из ридера
        /// </summary>
        public static ProductAttributeCollection GetProductAttributeCollectionFromReader(IDataReader reader)
        {
            ProductAttributeCollection productAttributetCollection = new ProductAttributeCollection();

            while (reader.Read())
                productAttributetCollection.Add(GetProductAttributeFromReader(reader));

            return productAttributetCollection;
        }

        /// <summary>
        /// Возвращает характеристики из текущей записи ридера
        /// </summary>
        public static ProductAttribute GetProductAttributeFromReader(IDataReader reader)
        {
            ProductAttribute productAttribute = new ProductAttribute();
            productAttribute.ProductAttributeID = GetInt(reader, "ProductAttributeID");
            productAttribute.Name = GetString(reader, "Name");

            return productAttribute;
        }
    }
}
