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
    internal class SqlProductAttributeMappingProvider:DataAccess
    {
        public static bool DeleteProductAttributeMapping(int ProductAttributeMappingID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductAttributeMappingDelete",cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductAttributeMappingID", SqlDbType.Int).Value = ProductAttributeMappingID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public static ProductAttributeMappingCollection GetProductAttributeMappingByProductID(int ProductID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductAttributeMappingGetByProductID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                cn.Open();
                return GetProductAttributeMappingCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static ProductAttributeMapping GetByProductAttributeMappingID(int ProductAttributeMappingID)
        {
            if (ProductAttributeMappingID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductAttributeMappingGet", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductAttributeMappingID", SqlDbType.Int).Value = ProductAttributeMappingID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetProductAttributeMappingFromReader(reader);
                else
                    return null;
            }
        }

        public static ProductAttributeMapping InsertProductAttributeMapping
            (
            int ProductID, 
            int ProductAttributeID,
            string AttributeValue, 
            int DisplayOrder,
            bool DisplayInShort
            )
        {
            ProductAttributeMapping productAttributeMapping = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductAttributeMappingInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                cmd.Parameters.Add("@ProductAttributeID", SqlDbType.Int).Value = ProductAttributeID;
                cmd.Parameters.Add("@AttributeValue", SqlDbType.NVarChar).Value = AttributeValue;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cmd.Parameters.Add("@DisplayInShort", SqlDbType.Bit).Value = DisplayInShort;
                cmd.Parameters.Add("@ProductAttributeMappingID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int ProductAttributeMappingID = (int)cmd.Parameters["@ProductAttributeMappingID"].Value;
                    productAttributeMapping = GetByProductAttributeMappingID(ProductAttributeMappingID);
                }
                return productAttributeMapping;
            }
        }

        public static ProductAttributeMapping UpdateProductAttributeMapping
            (
            int ProductAttributeMappingID,
            int ProductID, 
            int ProductAttributeID, 
            string AttributeValue, 
            int DisplayOrder,
            bool DisplayInShort
            )
        {
            ProductAttributeMapping productAttributeMapping = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductAttributeMappingUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductAttributeMappingID", SqlDbType.Int).Value = ProductAttributeMappingID;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                cmd.Parameters.Add("@ProductAttributeID", SqlDbType.Int).Value = ProductAttributeID;
                cmd.Parameters.Add("@AttributeValue", SqlDbType.NVarChar).Value = AttributeValue;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cmd.Parameters.Add("@DisplayInShort", SqlDbType.Bit).Value = DisplayInShort;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    productAttributeMapping = GetByProductAttributeMappingID(ProductAttributeMappingID);

                return productAttributeMapping;
            }
        }

        /// <summary>
        /// ¬озвращает коллекцию характеристик продукта из ридера
        /// </summary>
        public static ProductAttributeMappingCollection GetProductAttributeMappingCollectionFromReader(IDataReader reader)
        {
            ProductAttributeMappingCollection productAttributeMappingCollection = new ProductAttributeMappingCollection();

            while (reader.Read())
                productAttributeMappingCollection.Add(GetProductAttributeMappingFromReader(reader));

            return productAttributeMappingCollection;
        }

        /// <summary>
        /// ¬озвращает характеристики продукта из текущей записи ридера
        /// </summary>
        public static ProductAttributeMapping GetProductAttributeMappingFromReader(IDataReader reader)
        {
            ProductAttributeMapping productAttributeMapping = new ProductAttributeMapping();
            productAttributeMapping.ProductAttributeMappingID = GetInt(reader, "ProductAttributeMappingID");
            productAttributeMapping.ProductID = GetInt(reader, "ProductID");
            productAttributeMapping.ProductAttributeID = GetInt(reader, "ProductAttributeID");
            productAttributeMapping.AttributeValue = GetString(reader, "AttributeValue");
            productAttributeMapping.DisplayOrder = GetInt(reader, "DisplayOrder");
            productAttributeMapping.DisplayInShort = GetBoolean(reader, "DisplayInShort");
            return productAttributeMapping;
        }

    }
}
