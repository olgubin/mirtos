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
    internal class SqlFilterCriteriaProductProvider:DataAccess
    {
        public static FilterCriteriaProductCollection GetFilterCriteriaProductByProductID(int ProductID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterCriteria_Product_MappingGetByProductID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                cn.Open();
                return GetFilterCriteriaProductCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static FilterCriteriaProductCollection GetFilterCriteriaProductByFilterCriteriaID(int FilterCriteriaID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterCriteria_Product_MappingGetByFilterCriteriaID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterCriteriaID", SqlDbType.Int).Value = FilterCriteriaID;
                cn.Open();
                return GetFilterCriteriaProductCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static FilterCriteriaProduct GetByFilterCriteriaProductID(int FilterCriteriaProductID)
        {
            if (FilterCriteriaProductID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterCriteria_Product_MappingGetByFilterCriteriaProductID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterCriteriaProductID", SqlDbType.Int).Value = FilterCriteriaProductID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFilterCriteriaProductFromReader(reader);
                else
                    return null;
            }
        }

        public static FilterCriteriaProduct InsertFilterCriteriaProduct
            (
            int ProductID, 
            int FilterCriteriaID
            )
        {
            FilterCriteriaProduct filterCriteriaProduct = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterCriteria_Product_MappingInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                cmd.Parameters.Add("@FilterCriteriaID", SqlDbType.Int).Value = FilterCriteriaID;
                cmd.Parameters.Add("@FilterCriteriaProductID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int FilterCriteriaProductID = (int)cmd.Parameters["@FilterCriteriaProductID"].Value;
                    filterCriteriaProduct = GetByFilterCriteriaProductID(FilterCriteriaProductID);
                }
                return filterCriteriaProduct;
            }
        }

        public static FilterCriteriaProduct UpdateFilterCriteriaProduct
            (
            int FilterCriteriaProductID,
            int ProductID,
            int FilterCriteriaID
            )
        {
            FilterCriteriaProduct filterCriteriaProduct = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterCriteria_Product_MappingUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterCriteriaProductID", SqlDbType.Int).Value = FilterCriteriaProductID;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                cmd.Parameters.Add("@FilterCriteriaID", SqlDbType.Int).Value = FilterCriteriaID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    filterCriteriaProduct = GetByFilterCriteriaProductID(FilterCriteriaProductID);

                return filterCriteriaProduct;
            }
        }

        public static bool DeleteFilterCriteriaProduct(int FilterCriteriaProductID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterCriteria_Product_MappingDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterCriteriaProductID", SqlDbType.Int).Value = FilterCriteriaProductID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// ¬озвращает коллекцию характеристик продукта из ридера
        /// </summary>
        public static FilterCriteriaProductCollection GetFilterCriteriaProductCollectionFromReader(IDataReader reader)
        {
            FilterCriteriaProductCollection filterCriteriaProductCollection = new FilterCriteriaProductCollection();

            while (reader.Read())
                filterCriteriaProductCollection.Add(GetFilterCriteriaProductFromReader(reader));

            return filterCriteriaProductCollection;
        }

        /// <summary>
        /// ¬озвращает характеристики продукта из текущей записи ридера
        /// </summary>
        public static FilterCriteriaProduct GetFilterCriteriaProductFromReader(IDataReader reader)
        {
            FilterCriteriaProduct filterCriteriaProduct = new FilterCriteriaProduct();
            filterCriteriaProduct.FilterCriteriaProductID = GetInt(reader, "FilterCriteriaProductID");
            filterCriteriaProduct.FilterCriteriaID = GetInt(reader, "FilterCriteriaID");
            filterCriteriaProduct.ProductID = GetInt(reader, "ProductID");
            return filterCriteriaProduct;
        }

    }
}
