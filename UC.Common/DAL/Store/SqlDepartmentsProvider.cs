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
    internal class SqlDepartmentsProvider: DataAccess
    {
        public static DepartmentCollection GetAllDepartments(int ParentDepartmentID, bool showHidden)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_DepartmentsGet", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ShowHidden", SqlDbType.Bit).Value = showHidden;
                cmd.Parameters.Add("@ParentDepartmentID", SqlDbType.Int).Value = ParentDepartmentID;
                cn.Open();
                return GetDepartmentCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static DepartmentCollection GetByManufacturerID(int ManufacturerID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_DepartmentGetByManufacturerID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = ManufacturerID;
                cn.Open();
                return GetDepartmentCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static Department GetByDepartmentID(int DepartmentID)
        {
            if (DepartmentID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_DepartmentGetByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetDepartmentFromReader(reader);
                else
                    return null;
            }
        }

        /// <summary>
        /// Возвращает полное описание раздела
        /// </summary>
        public static string GetDepartmentLongDescription(int DepartmentID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_DepartmentGetLongDescription", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;
                cn.Open();
                return (string)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// Обновление полного описания
        /// </summary>
        public static bool UpdateDepartmentLongDescription(int DepartmentID, string LongDescription)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_DepartmentUpdateLongDescription", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;
                cmd.Parameters.Add("@LongDescription", SqlDbType.NVarChar).Value = LongDescription;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public static Department InsertDepartment
            (
            string Name,
            string Description,
            string MetaKeywords,
            string MetaDescription,
            string MetaTitle,
            int ParentDepartmentID,
            string ImageUrl,
            bool Published,
            int DisplayOrder,
            DateTime AddedDate,
            string AddedBy,
            int TemplateID
            )
        {
            Department department = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_DepartmentInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
                cmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = MetaKeywords;
                cmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = MetaDescription;
                cmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = MetaTitle;
                cmd.Parameters.Add("@ParentDepartmentID", SqlDbType.Int).Value = ParentDepartmentID;
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ImageUrl;
                cmd.Parameters.Add("@Published", SqlDbType.Bit).Value = Published;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = AddedDate;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = AddedBy;
                cmd.Parameters.Add("@TemplateID", SqlDbType.Int).Value = TemplateID;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int DepartmentID = (int)cmd.Parameters["@DepartmentID"].Value;
                    department = GetByDepartmentID(DepartmentID);
                }
                return department;
            }
        }

        public static Department UpdateDepartment
            (
            int DepartmentID,
            string Name,
            string Description,
            string MetaKeywords,
            string MetaDescription,
            string MetaTitle,
            int ParentDepartmentID,
            string ImageUrl,
            bool Published,
            int DisplayOrder,
            DateTime AddedDate,
            string AddedBy,
            int TemplateID
            )
        {
            Department department = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_DepartmentUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
                cmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = MetaKeywords;
                cmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = MetaDescription;
                cmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = MetaTitle;
                cmd.Parameters.Add("@ParentDepartmentID", SqlDbType.Int).Value = ParentDepartmentID;
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ImageUrl;
                cmd.Parameters.Add("@Published", SqlDbType.Bit).Value = Published;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = AddedDate;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = AddedBy;
                cmd.Parameters.Add("@TemplateID", SqlDbType.Int).Value = TemplateID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    department = GetByDepartmentID(DepartmentID);

                return department;
            }
        }

        /// <summary>
        /// Удаляет раздел
        /// </summary>
        public static bool DeleteDepartment(int DepartmentID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_DepartmentDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Возвращает коллекцию разделов из ридера
        /// </summary>
        public static DepartmentCollection GetDepartmentCollectionFromReader(IDataReader reader)
        {
            DepartmentCollection departmentCollection = new DepartmentCollection();

            while (reader.Read())
                departmentCollection.Add(GetDepartmentFromReader(reader));

            return departmentCollection;
        }

        /// <summary>
        /// Возвращает раздел из текущей записи ридера
        /// </summary>
        public static Department GetDepartmentFromReader(IDataReader reader)
        {
            Department department = new Department();
            department.DepartmentID = GetInt(reader, "DepartmentID");
            department.Name = GetString(reader, "Name");
            department.Description = GetString(reader, "Description");
            department.MetaKeywords = GetString(reader, "MetaKeywords");
            department.MetaDescription = GetString(reader, "MetaDescription");
            department.MetaTitle = GetString(reader, "MetaTitle");
            department.ParentDepartmentID = GetInt(reader, "ParentDepartmentID");
            department.Published = GetBoolean(reader, "Published");
            department.ImageUrl = GetString(reader, "ImageUrl");
            department.DisplayOrder = GetInt(reader, "DisplayOrder");
            department.AddedDate = GetDateTime(reader, "AddedDate");
            department.AddedBy = GetString(reader, "AddedBy");
            department.TemplateID = GetInt(reader, "TemplateID");

            return department;
        }
    }
}
