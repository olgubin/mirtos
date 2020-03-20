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
    internal class SqlDepartmentTemplateProvider : DataAccess
    {
        public static DepartmentTemplateCollection GetAllDepartmentTemplates()
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_DepartmentTemplateGet", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetDepartmentTemplateCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static DepartmentTemplate GetByDepartmentTemplateID(int DepartmentTemplateID)
        {
            if (DepartmentTemplateID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_DepartmentTemplateGetByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentTemplateID", SqlDbType.Int).Value = DepartmentTemplateID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetDepartmentTemplateFromReader(reader);
                else
                    return null;
            }
        }

        public static DepartmentTemplate InsertDepartmentTemplate
            (
            string Name,
            string TemplatePath,
            int DisplayOrder
            )
        {
            DepartmentTemplate departmentTemplate = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_DepartmentTemplateInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                cmd.Parameters.Add("@TemplatePath", SqlDbType.NVarChar).Value = TemplatePath;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cmd.Parameters.Add("@DepartmentTemplateID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int DepartmentTemplateID = (int)cmd.Parameters["@DepartmentTemplateID"].Value;
                    departmentTemplate = GetByDepartmentTemplateID(DepartmentTemplateID);
                }
                return departmentTemplate;
            }
        }

        public static DepartmentTemplate UpdateDepartmentTemplate
            (
            int DepartmentTemplateID,
            string Name,
            string TemplatePath,
            int DisplayOrder
            )
        {
            DepartmentTemplate departmentTemplate = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_DepartmentTemplateUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentTemplateID", SqlDbType.Int).Value = DepartmentTemplateID;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                cmd.Parameters.Add("@TemplatePath", SqlDbType.NVarChar).Value = TemplatePath;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    departmentTemplate = GetByDepartmentTemplateID(DepartmentTemplateID);

                return departmentTemplate;
            }
        }

        public static bool DeleteDepartmentTemplate(int DepartmentTemplateID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_DepartmentTemplateDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentTemplateID", SqlDbType.Int).Value = DepartmentTemplateID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Возвращает коллекцию шаблонов разделов из ридера
        /// </summary>
        public static DepartmentTemplateCollection GetDepartmentTemplateCollectionFromReader(IDataReader reader)
        {
            DepartmentTemplateCollection departmentTemplateCollection = new DepartmentTemplateCollection();

            while (reader.Read())
                departmentTemplateCollection.Add(GetDepartmentTemplateFromReader(reader));

            return departmentTemplateCollection;
        }

        /// <summary>
        /// Возвращает шаблон раздела из текущей записи ридера
        /// </summary>
        public static DepartmentTemplate GetDepartmentTemplateFromReader(IDataReader reader)
        {
            DepartmentTemplate departmentTemplate = new DepartmentTemplate();

            departmentTemplate.DepartmentTemplateID = GetInt(reader, "DepartmentTemplateID");
            departmentTemplate.Name = GetString(reader, "Name");
            departmentTemplate.TemplatePath = GetString(reader, "TemplatePath");
            departmentTemplate.DisplayOrder = GetInt(reader, "DisplayOrder");

            return departmentTemplate;
        }
    }
}
