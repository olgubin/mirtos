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
    internal class SqlFilterProvider: DataAccess
    {
        public static Filter GetByFilterID(int FilterID)
        {
            if (FilterID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterGetByFilterID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterID", SqlDbType.Int).Value = FilterID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFilterFromReader(reader);
                else
                    return null;
            }
        }

        public static FilterCollection GetFilters()
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterGet", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetFilterCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static bool DeleteFilter(int FilterID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterID", SqlDbType.Int).Value = FilterID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public static Filter InsertFilter(string Name)
        {
            Filter filter = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                cmd.Parameters.Add("@FilterID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int filterID = (int)cmd.Parameters["@FilterID"].Value;
                    filter = GetByFilterID(filterID);
                }
                return filter;
            }
        }

        public static Filter UpdateFilter(int FilterID, string Name)
        {
            Filter filter = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterID", SqlDbType.Int).Value = FilterID;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    filter = GetByFilterID(FilterID);

                return filter;
            }
        }

        /// <summary>
        /// Возвращает коллекцию характеристик из ридера
        /// </summary>
        public static FilterCollection GetFilterCollectionFromReader(IDataReader reader)
        {
            FilterCollection filterCollection = new FilterCollection();

            while (reader.Read())
                filterCollection.Add(GetFilterFromReader(reader));

            return filterCollection;
        }

        /// <summary>
        /// Возвращает характеристики из текущей записи ридера
        /// </summary>
        public static Filter GetFilterFromReader(IDataReader reader)
        {
            Filter filter = new Filter();
            filter.FilterID = GetInt(reader, "FilterID");
            filter.Name = GetString(reader, "Name");

            return filter;
        }
    }
}
