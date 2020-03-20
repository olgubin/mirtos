using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using UC.Core;

namespace UC.DAL
{
    internal class SqlSettingProvider : DataAccess
    {
        public static SettingCollection GetAllSettings()
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Setting_Get", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetSettingCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static Setting GetBySettingID(int SettingID)
        {
            if (SettingID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Setting_GetByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SettingID", SqlDbType.Int).Value = SettingID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetSettingFromReader(reader);
                else
                    return null;
            }
        }

        public static Setting InsertSetting
            (
            string Name,
            string Value,
            string Description
            )
        {
            Setting setting = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Setting_Insert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                cmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = Value;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
                cmd.Parameters.Add("@SettingID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int settingID = (int)cmd.Parameters["@SettingID"].Value;
                    setting = GetBySettingID(settingID);
                }
                return setting;
            }
        }

        public static Setting UpdateSetting
            (
            int SettingID,
            string Name,
            string Value,
            string Description
            )
        {
            Setting setting = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Setting_Update", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SettingID", SqlDbType.Int).Value = SettingID;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                cmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = Value;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    setting = GetBySettingID(SettingID);

                return setting;
            }
        }

        public static bool DeleteSetting(int SettingID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Setting_Delete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SettingID", SqlDbType.Int).Value = SettingID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Возвращает коллекцию разделов из ридера
        /// </summary>
        public static SettingCollection GetSettingCollectionFromReader(IDataReader reader)
        {
            SettingCollection settingCollection = new SettingCollection();

            while (reader.Read())
                settingCollection.Add(GetSettingFromReader(reader));

            return settingCollection;
        }

        /// <summary>
        /// Возвращает раздел из текущей записи ридера
        /// </summary>
        public static Setting GetSettingFromReader(IDataReader reader)
        {
            Setting setting = new Setting();
            setting.SettingID = GetInt(reader, "SettingID");
            setting.Name = GetString(reader, "Name");
            setting.Value = GetString(reader, "Value");
            setting.Description = GetString(reader, "Description");

            return setting;
        }
    }
}
