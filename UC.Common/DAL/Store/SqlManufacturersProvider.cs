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
    internal class SqlManufacturersProvider : DataAccess
    {
        /// <summary>
        /// Возвращает коллекцию производителей
        /// </summary>
        public static ManufacturerCollection GetManufacturers(bool showHidden)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ManufacturersGet", cn);
                cmd.Parameters.Add("@showHidden", SqlDbType.Bit).Value = showHidden;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetManufacturerCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Возвращает производителя по его идентификатору
        /// </summary>
        public static Manufacturer GetByManufacturerID(int manufacturerID)
        {
            if (manufacturerID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ManufacturerGetByManufacturerID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = manufacturerID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetManufacturerFromReader(reader);
                else
                    return null;
            }
        }

        /// <summary>
        /// Удаляет производителя
        /// </summary>
        public static bool DeleteManufacturer(int manufacturerID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ManufacturerDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = manufacturerID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Возвращает полное описание
        /// </summary>
        public static string GetManufacturerLongDescription(int ManufacturerID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ManufacturerGetLongDescription", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = ManufacturerID;
                cn.Open();
                return (string)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// Обновление полного описания
        /// </summary>
        public static bool UpdateManufacturerLongDescription(int ManufacturerID, string LongDescription)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ManufacturerUpdateLongDescription", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = ManufacturerID;
                cmd.Parameters.Add("@LongDescription", SqlDbType.NVarChar).Value = LongDescription;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Обновляет данные о производителе
        /// </summary>
        public static Manufacturer UpdateManufacturer
            (
            int ManufacturerID,
            string Title,
            string Description,
            string MetaTitle,
            string MetaDescription,
            string MetaKeywords,
            string ImageUrl,
            string Url,
            int ArticleID,
            int DisplayOrder,
            bool Published,
            DateTime AddedDate,
            string AddedBy
            )
        {
            Manufacturer manufacturer = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ManufacturerUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = ManufacturerID;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Title;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
                cmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = MetaTitle;
                cmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = MetaDescription;
                cmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = MetaKeywords;
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ImageUrl;
                cmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = Url;
                cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ArticleID;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cmd.Parameters.Add("@Published", SqlDbType.Int).Value = Published;
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = AddedDate;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = AddedBy;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    manufacturer = GetByManufacturerID(ManufacturerID);

                return manufacturer;
            }
        }

        /// <summary>
        /// СОздает нового производителя
        /// </summary>
        public static Manufacturer InsertManufacturer
            (
            string Title,
            string Description,
            string MetaTitle,
            string MetaDescription,
            string MetaKeywords,
            string ImageUrl,
            string Url,
            int ArticleID,
            int DisplayOrder,
            bool Published,
            DateTime AddedDate,
            string AddedBy
            )
        {
            Manufacturer manufacturer = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ManufacturerInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Title;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
                cmd.Parameters.Add("@MetaTitle", SqlDbType.NVarChar).Value = MetaTitle;
                cmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar).Value = MetaDescription;
                cmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar).Value = MetaKeywords;
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ImageUrl;
                cmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = Url;
                cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ArticleID;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cmd.Parameters.Add("@Published", SqlDbType.Int).Value = Published;
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = AddedDate;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = AddedBy;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int ManufacturerID = (int)cmd.Parameters["@ManufacturerID"].Value;
                    manufacturer = GetByManufacturerID(ManufacturerID);
                }
                return manufacturer;
            }
        }

        /// <summary>
        /// Изменение видимости бренда
        /// </summary>
        public static bool ManufacturerPublished(int manufacturerID, bool isPublished)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ManufacturerPublished", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = manufacturerID;
                cmd.Parameters.Add("@isPublished", SqlDbType.Bit).Value = isPublished;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Возвращает Manufacturer заполненный из DataReader's
        /// </summary>
        public static Manufacturer GetManufacturerFromReader(IDataReader reader)
        {
            Manufacturer manufacturer = new Manufacturer();
            manufacturer.ManufacturerID = GetInt(reader, "ManufacturerID");
            manufacturer.Title = GetString(reader, "Title");
            manufacturer.Description = GetString(reader, "Description");
            manufacturer.MetaTitle = GetString(reader, "MetaTitle");
            manufacturer.MetaDescription = GetString(reader, "MetaDescription");
            manufacturer.MetaKeywords = GetString(reader, "MetaKeywords");
            manufacturer.ImageUrl = GetString(reader, "ImageUrl");
            manufacturer.Url = GetString(reader, "Url");
            manufacturer.ArticleID = GetInt(reader, "ArticleID");
            manufacturer.DisplayOrder = GetInt(reader, "DisplayOrder");
            manufacturer.Published = GetBoolean(reader, "Published");
            manufacturer.AddedDate = GetDateTime(reader, "AddedDate");
            manufacturer.AddedBy = GetString(reader, "AddedBy");

            return manufacturer;
        }

        /// <summary>
        /// Возвращает коллекцию объектов Manufacturer c данными, заполненными из DataReader
        /// </summary>
        public static ManufacturerCollection GetManufacturerCollectionFromReader(IDataReader reader)
        {
            ManufacturerCollection manufacturers = new ManufacturerCollection();
            while (reader.Read())
                manufacturers.Add(GetManufacturerFromReader(reader));
            return manufacturers;
        }
    }
}
