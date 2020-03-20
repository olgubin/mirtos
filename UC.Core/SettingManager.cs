using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Globalization;
using UC.DAL;

namespace UC.Core
{
    /// <summary>
    /// Менеджер настроек
    /// </summary>
    public class SettingManager
    {
        private const string SETTINGS_ALL_KEY = "UC.setting.all";

        public static SettingCollection GetAllSettings()
        {
            string key = SETTINGS_ALL_KEY;
            object obj2 = UCCache.Get(key);
            if (obj2 != null)
            {
                return (SettingCollection)obj2;
            }

            SettingCollection settingCollection = SqlSettingProvider.GetAllSettings();

            UCCache.Max(key, settingCollection);

            return settingCollection;
        }

        public static Setting GetBySettingID(int SettingID)
        {
            return SqlSettingProvider.GetBySettingID(SettingID);
        }

        public static Setting SetParam(string Name, string Value, string Description)
        {
            Setting setting = GetSettingByName(Name);
            if (setting != null)
                return UpdateSetting(setting.SettingID, setting.Name, Value, setting.Description);
            else
                return InsertSetting(Name, Value, Description);
        }

        public static Setting SetParamNative(string Name, decimal Value, string Description)
        {
            string valueStr = Value.ToString(new CultureInfo("ru-RU"));
            return SetParam(Name, valueStr, Description);
        }

        internal static Setting InsertSetting(string Name, string Value, string Description)
        {
            Setting setting = SqlSettingProvider.InsertSetting(Name, Value, Description);

            UCCache.RemoveByPattern(SETTINGS_ALL_KEY);

            return setting;
        }

        internal static Setting UpdateSetting(int SettingID, string Name, string Value, string Description)
        {
            Setting setting = SqlSettingProvider.UpdateSetting(SettingID, Name, Value, Description);

            UCCache.RemoveByPattern(SETTINGS_ALL_KEY);

            return setting;
        }

        public static void DeleteSetting(int SettingID)
        {
            SqlSettingProvider.DeleteSetting(SettingID);

            UCCache.RemoveByPattern(SETTINGS_ALL_KEY);
        }

        public static bool GetSettingValueBoolean(string Name)
        {
            return GetSettingValueBoolean(Name, false);
        }

        public static bool GetSettingValueBoolean(string Name, bool DefaultValue)
        {
            string value = GetSettingValue(Name);
            if (value.Length > 0)
            {
                return bool.Parse(value);
            }
            return DefaultValue;
        }

        public static int GetSettingValueInteger(string Name)
        {
            return GetSettingValueInteger(Name, 0);
        }

        public static int GetSettingValueInteger(string Name, int DefaultValue)
        {
            string value = GetSettingValue(Name);
            if (value.Length > 0)
            {
                return int.Parse(value);
            }
            return DefaultValue;
        }

        public static decimal GetSettingValueDecimalNative(string Name)
        {
            return GetSettingValueDecimalNative(Name, decimal.Zero);
        }

        public static decimal GetSettingValueDecimalNative(string Name, decimal DefaultValue)
        {
            string value = GetSettingValue(Name);
            if (value.Length > 0)
            {
                return decimal.Parse(value, new CultureInfo("ru-RU"));
            }
            return DefaultValue;
        }

        public static string GetSettingValue(string Name)
        {
            Setting setting = GetSettingByName(Name);
            if (setting != null)
                return setting.Value;
            return string.Empty;
        }

        public static Setting GetSettingByName(string Name)
        {
            SettingCollection settingCollection = GetAllSettings();
            foreach (Setting setting in settingCollection)
                if (setting.Name == Name)
                    return setting;
            return null;
        }
    }
}
