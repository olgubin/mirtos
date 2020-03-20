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
    internal class SqlFilterDepartmentProvider:DataAccess
    {
        public static FilterDepartmentCollection GetFilterDepartmentByDepartmentID(int DepartmentID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_Filter_Department_MappingGetByDepartmentID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;
                cn.Open();
                return GetFilterDepartmentCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static FilterDepartment GetByFilterDepartmentID(int FilterDepartmentID)
        {
            if (FilterDepartmentID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_Filter_Department_MappingGetByFilterDepartmentID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterDepartmentID", SqlDbType.Int).Value = FilterDepartmentID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFilterDepartmentFromReader(reader);
                else
                    return null;
            }
        }

        public static FilterDepartment InsertFilterDepartment
            (
            int DepartmentID, 
            int FilterID,
            int DisplayOrder
            )
        {
            FilterDepartment filterDepartment = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_Filter_Department_MappingInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;
                cmd.Parameters.Add("@FilterID", SqlDbType.Int).Value = FilterID;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cmd.Parameters.Add("@FilterDepartmentID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int FilterDepartmentID = (int)cmd.Parameters["@FilterDepartmentID"].Value;
                    filterDepartment = GetByFilterDepartmentID(FilterDepartmentID);
                }
                return filterDepartment;
            }
        }

        public static FilterDepartment UpdateFilterDepartment
            (
            int FilterDepartmentID,
            int DepartmentID,
            int FilterID,
            int DisplayOrder
            )
        {
            FilterDepartment filterDepartment = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_Filter_Department_MappingUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterDepartmentID", SqlDbType.Int).Value = FilterDepartmentID;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;
                cmd.Parameters.Add("@FilterID", SqlDbType.Int).Value = FilterID;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    filterDepartment = GetByFilterDepartmentID(FilterDepartmentID);

                return filterDepartment;
            }
        }

        public static bool DeleteFilterDepartment(int FilterDepartmentID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_Filter_Department_MappingDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterDepartmentID", SqlDbType.Int).Value = FilterDepartmentID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// ¬озвращает коллекцию характеристик продукта из ридера
        /// </summary>
        public static FilterDepartmentCollection GetFilterDepartmentCollectionFromReader(IDataReader reader)
        {
            FilterDepartmentCollection filterDepartmentCollection = new FilterDepartmentCollection();

            while (reader.Read())
                filterDepartmentCollection.Add(GetFilterDepartmentFromReader(reader));

            return filterDepartmentCollection;
        }

        /// <summary>
        /// ¬озвращает характеристики продукта из текущей записи ридера
        /// </summary>
        public static FilterDepartment GetFilterDepartmentFromReader(IDataReader reader)
        {
            FilterDepartment filterDepartment = new FilterDepartment();
            filterDepartment.FilterDepartmentID = GetInt(reader, "FilterDepartmentID");
            filterDepartment.FilterID = GetInt(reader, "FilterID");
            filterDepartment.DepartmentID = GetInt(reader, "DepartmentID");
            filterDepartment.DisplayOrder = GetInt(reader, "DisplayOrder");
            return filterDepartment;
        }

    }
}
