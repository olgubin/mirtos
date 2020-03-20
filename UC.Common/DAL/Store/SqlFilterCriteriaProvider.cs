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
    internal class SqlFilterCriteriaProvider : DataAccess
    {
        public static FilterCriteria GetByFilterCriteriaID(int FilterCriteriaID)
        {
            if (FilterCriteriaID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterCriteriaGetByFilterCriteriaID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterCriteriaID", SqlDbType.Int).Value = FilterCriteriaID;
                cn.Open();

                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetFilterCriteriaFromReader(reader);
                else
                    return null;
            }
        }

        public static FilterCriteriaCollection GetFilterCriteria()
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterCriteriaGet", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetFilterCriteriaCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static FilterCriteriaCollection GetFilterCriteriaByFilterID(int FilterID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterCriteriaGetByFilterID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterID", SqlDbType.Int).Value = FilterID;
                cn.Open();
                return GetFilterCriteriaCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static FilterCriteriaCollection GetFilterCriteriaByDepartmentID(int DepartmentID, bool Visible)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterCriteriaGetByDepartmentID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;
                cmd.Parameters.Add("@Visible", SqlDbType.Bit).Value = Visible;
                cn.Open();
                return GetFilterCriteriaCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Получает уникальный список критериев фильтрации по указанному идентификатору производителя
        /// </summary>
        /// <param name="ManufacturerID"></param>
        /// <param name="Visible"></param>
        /// <returns></returns>
        public static FilterCriteriaCollection GetFilterCriteriaByManufacturerID(int ManufacturerID, bool Visible)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterCriteriaGetByManufacturerID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = ManufacturerID;
                cmd.Parameters.Add("@Visible", SqlDbType.Bit).Value = Visible;
                cn.Open();
                return GetFilterCriteriaCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static FilterCriteria InsertFilterCriteria
            (
            int FilterID,
            string Criterion,
            int DisplayOrder
            )
        {
            FilterCriteria filterCriteria = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterCriteriaInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterID", SqlDbType.Int).Value = FilterID;
                cmd.Parameters.Add("@Criterion", SqlDbType.NVarChar).Value = Criterion;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cmd.Parameters.Add("@FilterCriteriaID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int FilterCriteriaID = (int)cmd.Parameters["@FilterCriteriaID"].Value;
                    filterCriteria = GetByFilterCriteriaID(FilterCriteriaID);
                }
                return filterCriteria;
            }
        }

        public static FilterCriteria UpdateFilterCriteria
            (
            int FilterCriteriaID, 
            int FilterID,
            string Criterion,
            int DisplayOrder
            )
        {
            FilterCriteria filterCriteria = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterCriteriaUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterCriteriaID", SqlDbType.Int).Value = FilterCriteriaID;
                cmd.Parameters.Add("@FilterID", SqlDbType.Int).Value = FilterID;
                cmd.Parameters.Add("@Criterion", SqlDbType.NVarChar).Value = Criterion;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                    filterCriteria = GetByFilterCriteriaID(FilterCriteriaID);

                return filterCriteria;
            }
        }

        public static bool DeleteFilterCriteria(int FilterCriteriaID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_FilterCriteriaDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FilterCriteriaID", SqlDbType.Int).Value = FilterCriteriaID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Возвращает коллекцию связанных товаров
        /// </summary>
        public static FilterCriteriaCollection GetFilterCriteriaCollectionFromReader(IDataReader reader)
        {
            FilterCriteriaCollection filterCriteriaCollection = new FilterCriteriaCollection();

            while (reader.Read())
                filterCriteriaCollection.Add(GetFilterCriteriaFromReader(reader));

            return filterCriteriaCollection;
        }

        /// <summary>
        /// Возвращает связанный товар
        /// </summary>
        public static FilterCriteria GetFilterCriteriaFromReader(IDataReader reader)
        {
            FilterCriteria filterCriteria = new FilterCriteria();
            filterCriteria.FilterCriteriaID = GetInt(reader, "FilterCriteriaID");
            filterCriteria.FilterID = GetInt(reader, "FilterID");
            filterCriteria.Criterion = GetString(reader, "Criterion");
            filterCriteria.DisplayOrder = GetInt(reader, "DisplayOrder");

            return filterCriteria;
        }
    }
}
