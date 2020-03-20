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
    internal class SqlProductedRelatedProvider : DataAccess
    {
        public static ProductRelated GetByProductRelatedID(int ProductRelatedID)
        {
            if (ProductRelatedID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductRelatedGetByProductRelatedID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductRelatedID", SqlDbType.Int).Value = ProductRelatedID;
                cn.Open();

                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetProductRelatedFromReader(reader);
                else
                    return null;

            }
        }

        public static ProductRelatedCollection GetProductRelatedByProductID1(int ProductID1, bool showHidden)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductRelatedGetByProductID1", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID1", SqlDbType.Int).Value = ProductID1;
                cmd.Parameters.Add("@ShowHidden", SqlDbType.Bit).Value = showHidden;
                cn.Open();
                return GetProductRelatedCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static ProductRelated InsertProductRelated
            (
            int ProductID1, 
            int ProductID2, 
            int DisplayOrder
            )
        {
            ProductRelated productRelated = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductRelatedInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID1", SqlDbType.Int).Value = ProductID1;
                cmd.Parameters.Add("@ProductID2", SqlDbType.Int).Value = ProductID2;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cmd.Parameters.Add("@ProductRelatedID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int productRelatedID = (int)cmd.Parameters["@ProductRelatedID"].Value;
                    productRelated = GetByProductRelatedID(productRelatedID);
                }
                return productRelated;
            }
        }

        public static ProductRelated UpdateProductRelated
            (
            int ProductRelatedID, 
            int ProductID1, 
            int ProductID2,
            int DisplayOrder
            )
        {
            ProductRelated productRelated = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductRelatedUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductRelatedID", SqlDbType.Int).Value = ProductRelatedID;
                cmd.Parameters.Add("@ProductID1", SqlDbType.Int).Value = ProductID1;
                cmd.Parameters.Add("@ProductID2", SqlDbType.Int).Value = ProductID2;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                    productRelated = GetByProductRelatedID(ProductRelatedID);

                return productRelated;
            }
        }

        public static bool DeleteProductRelated(int ProductRelatedID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductRelatedDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductRelatedID", SqlDbType.Int).Value = ProductRelatedID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Возвращает коллекцию связанных товаров
        /// </summary>
        public static ProductRelatedCollection GetProductRelatedCollectionFromReader(IDataReader reader)
        {
            ProductRelatedCollection productRelatedCollection = new ProductRelatedCollection();

            while (reader.Read())
                productRelatedCollection.Add(GetProductRelatedFromReader(reader));

            return productRelatedCollection;
        }

        /// <summary>
        /// Возвращает связанный товар
        /// </summary>
        public static ProductRelated GetProductRelatedFromReader(IDataReader reader)
        {
            ProductRelated productRelated = new ProductRelated();
            productRelated.ProductRelatedID = GetInt(reader, "ProductRelatedID");
            productRelated.ProductID1 = GetInt(reader, "ProductID1");
            productRelated.ProductID2 = GetInt(reader, "ProductID2");
            productRelated.DisplayOrder = GetInt(reader, "DisplayOrder");

            return productRelated;
        }
    }
}
