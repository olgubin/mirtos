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
    internal class SqlCurrencyProvider : DataAccess
    {
        public static CurrencyCollection GetCurrencies()
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_Currency_Get", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetCurrencyCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static Currency GetByCurrencyID(int CurrencyID)
        {
            if (CurrencyID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_Currency_GetByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CurrencyID", SqlDbType.Int).Value = CurrencyID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetCurrencyFromReader(reader);
                else
                    return null;
            }
        }

        public static Currency InsertCurrency
            (
            string Name,
            string CurrencyCode,
            decimal Rate,
            bool Published,
            int DisplayOrder
            )
        {
            Currency currency = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_Currency_Insert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                cmd.Parameters.Add("@CurrencyCode", SqlDbType.NVarChar).Value = CurrencyCode;
                cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = Rate;
                cmd.Parameters.Add("@Published", SqlDbType.Bit).Value = Published;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cmd.Parameters.Add("@CurrencyID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int currencyID = (int)cmd.Parameters["@CurrencyID"].Value;
                    currency = GetByCurrencyID(currencyID);
                }
                return currency;
            }
        }

        public static Currency UpdateCurrency
            (
            int CurrencyID,
            string Name,
            string CurrencyCode,
            decimal Rate,
            bool Published,
            int DisplayOrder
            )
        {
            Currency currency = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_Currency_Update", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CurrencyID", SqlDbType.Int).Value = CurrencyID;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                cmd.Parameters.Add("@CurrencyCode", SqlDbType.NVarChar).Value = CurrencyCode;
                cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = Rate;
                cmd.Parameters.Add("@Published", SqlDbType.Bit).Value = Published;
                cmd.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = DisplayOrder;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    currency = GetByCurrencyID(CurrencyID);

                return currency;
            }
        }

        public static bool DeleteCurrency(int CurrencyID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_Currency_Delete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CurrencyID", SqlDbType.Int).Value = CurrencyID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Возвращает коллекцию разделов из ридера
        /// </summary>
        public static CurrencyCollection GetCurrencyCollectionFromReader(IDataReader reader)
        {
            CurrencyCollection currencyCollection = new CurrencyCollection();

            while (reader.Read())
                currencyCollection.Add(GetCurrencyFromReader(reader));

            return currencyCollection;
        }

        /// <summary>
        /// Возвращает раздел из текущей записи ридера
        /// </summary>
        public static Currency GetCurrencyFromReader(IDataReader reader)
        {
            Currency currency = new Currency();
            currency.CurrencyID = GetInt(reader, "CurrencyID");
            currency.Name = GetString(reader, "Name");
            currency.CurrencyCode = GetString(reader, "CurrencyCode");
            currency.Rate = GetDecimal(reader, "Rate");
            currency.Published = GetBoolean(reader, "Published");
            currency.DisplayOrder = GetInt(reader, "DisplayOrder");

            return currency;
        }
    }
}
