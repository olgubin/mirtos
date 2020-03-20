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
    internal class SqlFilterManufacturerProvider:DataAccess
    {
        public static FilterManufacturerCollection GetFilterManufacturerByManufacturerID(int ManufacturerID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_Filter_Manufacturer_MappingGetByManufacturerID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = ManufacturerID;
                cn.Open();
                return GetFilterManufacturerCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static FilterManufacturer GetByFilterManufacturerID(int FilterManufacturerID)
        {
            if (FilterManufacturerID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_Filter_Manufacturer_MappingGetByFilterManufacturerID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterManufacturerID", SqlDbType.Int).Value = FilterManufacturerID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFilterManufacturerFromReader(reader);
                else
                    return null;
            }
        }

        public static FilterManufacturer InsertFilterManufacturer
            (
            int ManufacturerID, 
            int FilterID,
            int DisplayOrder
            )
        {
            FilterManufacturer filterManufacturer = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_Filter_Manufacturer_MappingInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = ManufacturerID;
                cmd.Parameters.Add("@FilterID", SqlDbType.Int).Value = FilterID;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cmd.Parameters.Add("@FilterManufacturerID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int FilterManufacturerID = (int)cmd.Parameters["@FilterManufacturerID"].Value;
                    filterManufacturer = GetByFilterManufacturerID(FilterManufacturerID);
                }
                return filterManufacturer;
            }
        }

        public static FilterManufacturer UpdateFilterManufacturer
            (
            int FilterManufacturerID,
            int ManufacturerID,
            int FilterID,
            int DisplayOrder
            )
        {
            FilterManufacturer filterManufacturer = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_Filter_Manufacturer_MappingUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterManufacturerID", SqlDbType.Int).Value = FilterManufacturerID;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = ManufacturerID;
                cmd.Parameters.Add("@FilterID", SqlDbType.Int).Value = FilterID;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    filterManufacturer = GetByFilterManufacturerID(FilterManufacturerID);

                return filterManufacturer;
            }
        }

        public static bool DeleteFilterManufacturer(int FilterManufacturerID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_Filter_Manufacturer_MappingDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterManufacturerID", SqlDbType.Int).Value = FilterManufacturerID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// ¬озвращает коллекцию характеристик продукта из ридера
        /// </summary>
        public static FilterManufacturerCollection GetFilterManufacturerCollectionFromReader(IDataReader reader)
        {
            FilterManufacturerCollection filterManufacturerCollection = new FilterManufacturerCollection();

            while (reader.Read())
                filterManufacturerCollection.Add(GetFilterManufacturerFromReader(reader));

            return filterManufacturerCollection;
        }

        /// <summary>
        /// ¬озвращает характеристики продукта из текущей записи ридера
        /// </summary>
        public static FilterManufacturer GetFilterManufacturerFromReader(IDataReader reader)
        {
            FilterManufacturer filterManufacturer = new FilterManufacturer();
            filterManufacturer.FilterManufacturerID = GetInt(reader, "FilterManufacturerID");
            filterManufacturer.FilterID = GetInt(reader, "FilterID");
            filterManufacturer.ManufacturerID = GetInt(reader, "ManufacturerID");
            filterManufacturer.DisplayOrder = GetInt(reader, "DisplayOrder");
            return filterManufacturer;
        }

    }
}
