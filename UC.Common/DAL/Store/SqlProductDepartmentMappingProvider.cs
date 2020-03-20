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
    internal class SqlProductDepartmentsMappingProvider:DataAccess
    {
        public static bool DeleteProductDepartmentMapping(int ProductDepartmentID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductDepartmentMappingDelete",cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductDepartmentID", SqlDbType.Int).Value = ProductDepartmentID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public static ProductDepartmentMappingCollection GetProductDepartmentMappingByProductID(int ProductID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductDepartmentMappingGetByProductID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                cn.Open();
                return GetProductDepartmentMappingCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static ProductDepartmentMappingCollection GetProductDepartmentMappingByDepartmentID(int DepartmentID, bool Visible)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductDepartmentMappingGetByDepartmentID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;
                cmd.Parameters.Add("@Visible", SqlDbType.Int).Value = Visible;
                cn.Open();
                return GetProductDepartmentMappingCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static ProductDepartmentMapping GetByProductDepartmentMappingID(int ProductDepartmentID)
        {
            if (ProductDepartmentID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductDepartmentMappingGet", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductDepartmentID", SqlDbType.Int).Value = ProductDepartmentID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetProductDepartmentMappingFromReader(reader);
                else
                    return null;
            }
        }

        public static ProductDepartmentMapping InsertProductDepartmentMapping
            (
            int ProductID,
            int DepartmentID,
            int DisplayOrder
            )
        {
            ProductDepartmentMapping productDepartmentMapping = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductDepartmentMappingInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cmd.Parameters.Add("@ProductDepartmentID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int ProductDepartmentID = (int)cmd.Parameters["@ProductDepartmentID"].Value;
                    productDepartmentMapping = GetByProductDepartmentMappingID(ProductDepartmentID);
                }
                return productDepartmentMapping;
            }
        }

        public static ProductDepartmentMapping UpdateProductDepartmentMapping
            (
            int ProductDepartmentID,
            int ProductID, 
            int DepartmentID, 
            int DisplayOrder
            )
        {
            ProductDepartmentMapping productDepartmentMapping = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductDepartmentMappingUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductDepartmentID", SqlDbType.Int).Value = ProductDepartmentID;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    productDepartmentMapping = GetByProductDepartmentMappingID(ProductDepartmentID);

                return productDepartmentMapping;
            }
        }

        /// <summary>
        /// ¬озвращает коллекцию разделов продукта из ридера
        /// </summary>
        public static ProductDepartmentMappingCollection GetProductDepartmentMappingCollectionFromReader(IDataReader reader)
        {
            ProductDepartmentMappingCollection productDepartmentMappingCollection = new ProductDepartmentMappingCollection();

            while (reader.Read())
                productDepartmentMappingCollection.Add(GetProductDepartmentMappingFromReader(reader));

            return productDepartmentMappingCollection;
        }

        /// <summary>
        /// ¬озвращает раздел продукта из текущей записи ридера
        /// </summary>
        public static ProductDepartmentMapping GetProductDepartmentMappingFromReader(IDataReader reader)
        {
            ProductDepartmentMapping productDepartmentMapping = new ProductDepartmentMapping();
            productDepartmentMapping.ProductDepartmentID = GetInt(reader, "ProductDepartmentID");
            productDepartmentMapping.ProductID = GetInt(reader, "ProductID");
            productDepartmentMapping.DepartmentID = GetInt(reader, "DepartmentID");
            productDepartmentMapping.DisplayOrder = GetInt(reader, "DisplayOrder");
            return productDepartmentMapping;
        }

    }
}
