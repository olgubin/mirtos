using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Globalization;
using System.Web;
using UC.DAL.Store;
using UC.Core;

namespace UC.BLL.Store
{
    /// <summary>
    /// Менеджер валют
    /// </summary>
    public class CurrencyManager
    {
        private const string CURRENCIES_ALL_KEY = "UC.currency.all";
        private const string CURRENCIES_BY_ID_KEY = "UC.currency.id-{0}";

        /// <summary>
        /// Получает все валюты
        /// </summary>
        /// <returns>Коллекция валют</returns>
        public static CurrencyCollection GetCurrencies()
        {
            string key = string.Format(CURRENCIES_ALL_KEY);
            object obj2 = UCCache.Get(key);
            if (obj2 != null)
            {
                return (CurrencyCollection)obj2;
            }

            CurrencyCollection currencyCollection = SqlCurrencyProvider.GetCurrencies();
            UCCache.Max(key, currencyCollection);

            return currencyCollection;
        }


        /// <summary>
        /// Получает валюту по идентификатору
        /// </summary>
        /// <param name="CurrencyID">идентификатор валюты</param>
        /// <returns>Currency</returns>
        public static Currency GetByCurrencyID(int CurrencyID)
        {
            string key = string.Format(CURRENCIES_BY_ID_KEY, CurrencyID);
            object obj2 = UCCache.Get(key);
            if (obj2 != null)
            {
                return (Currency)obj2;
            }

            Currency currency = SqlCurrencyProvider.GetByCurrencyID(CurrencyID);
            UCCache.Max(key, currency);

            return currency;
        }

        public static Currency PrimaryCurrency
        {
            get
            {
                int primaryCurrencyID = SettingManager.GetSettingValueInteger("Currency.PrimaryCurrency");
                return GetByCurrencyID(primaryCurrencyID);
            }
            set
            {
                if (value != null)
                    SettingManager.SetParam("Currency.PrimaryCurrency", value.CurrencyID.ToString(), string.Empty);
            }
        }

        public static decimal ConvertCurrency(decimal Amount, Currency SourceCurrencyCode, Currency TargetCurrencyCode)
        {
            decimal result = Amount;
            if (SourceCurrencyCode.CurrencyID == TargetCurrencyCode.CurrencyID)
                return result;
            if (result != decimal.Zero && SourceCurrencyCode.CurrencyID != TargetCurrencyCode.CurrencyID)
            {
                result = ConvertToPrimaryCurrency(result, SourceCurrencyCode);
                result = ConvertFromPrimaryCurrency(result, TargetCurrencyCode);
            }
            return result;
        }

        public static decimal ConvertToPrimaryCurrency(decimal Amount, Currency SourceCurrencyCode)
        {
            decimal result = Amount;

            decimal ExchangeRate = SourceCurrencyCode.Rate;

            if (ExchangeRate == decimal.Zero)
            {
                result = decimal.Zero;
                //throw new ArgumentException("Не задан курс для валюты =" + SourceCurrencyCode.Name);
            }
            else
            {
                result = result * ExchangeRate;
            }

            return result;
        }

        public static Decimal ConvertFromPrimaryCurrency(Decimal Amount, Currency TargetCurrencyCode)
        {
            Decimal result = Amount;

            Decimal ExchangeRate = TargetCurrencyCode.Rate;

            if (ExchangeRate == decimal.Zero)
            {
                result = decimal.Zero;
                //throw new ArgumentException("Не задан курс для валюты  =" + TargetCurrencyCode.Name);
            }
            else
            {
                result = result / ExchangeRate;
            }

            return result;
        }

        /// <summary>
        /// Добавляет валюту
        /// </summary>
        public static Currency InsertCurrency
            (
            string Name,
            string CurrencyCode,
            decimal Rate,
            bool Published,
            int DisplayOrder
            )
        {
            Currency currency = SqlCurrencyProvider.InsertCurrency
                (
                Name,
                CurrencyCode,
                Rate,
                Published,
                DisplayOrder
                );

            UCCache.RemoveByPattern("currency");

            return currency;
        }

        /// <summary>
        /// Обновляет валюту
        /// </summary>
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
            Currency сurrency = SqlCurrencyProvider.UpdateCurrency
                (
                CurrencyID,
                Name,
                CurrencyCode,
                Rate,
                Published,
                DisplayOrder
                );

            UCCache.RemoveByPattern("currency");

            return сurrency;
        }

        /// <summary>
        /// Удаляет валюту
        /// </summary>
        /// <param name="CurrencyID">идентификатор валюты</param>
        public static void DeleteCurrency(int CurrencyID)
        {
            bool ret = SqlCurrencyProvider.DeleteCurrency(CurrencyID);

            new RecordDeletedEvent("currency", CurrencyID, null).Raise();

            UCCache.RemoveByPattern("currency");
        }

        public static Currency WorkingCurrency
        {
            get
            {
                Currency currency = new Currency();

                if (HttpContext.Current == null)
                {
                    currency = CurrencyManager.PrimaryCurrency;

                }
                else
                {
                    if (HttpContext.Current.Session["CurrencyID"] != null)
                    {
                        int currencyID = (int)HttpContext.Current.Session["CurrencyID"];
                        currency = CurrencyManager.GetByCurrencyID(currencyID);
                    }
                    else
                    {
                        currency = CurrencyManager.PrimaryCurrency;
                    }
                }

                return currency;
            }
            set
            {
                if (value != null)
                {
                    HttpContext.Current.Session["CurrencyID"] = value.CurrencyID;
                }
            }

            //get
            //{
            //    if (NopContext.Current.IsAdmin)
            //    {
            //        return CurrencyManager.PrimaryStoreCurrency;
            //    }
            //    Customer customer = NopContext.Current.User;
            //    CurrencyCollection publishedCurrencies = CurrencyManager.GetAllCurrencies();
            //    if (customer != null)
            //    {
            //        Currency customerCurrency = customer.Currency;
            //        if (customerCurrency != null)
            //            foreach (Currency _currency in publishedCurrencies)
            //                if (_currency.CurrencyID == customerCurrency.CurrencyID)
            //                    return customerCurrency;
            //    }
            //    else if (CommonHelper.GetCookieInt("Nop.CustomerCurrency") > 0)
            //    {
            //        Currency customerCurrency = CurrencyManager.GetByCurrencyID(CommonHelper.GetCookieInt("Nop.CustomerCurrency"));
            //        if (customerCurrency != null)
            //            foreach (Currency _currency in publishedCurrencies)
            //                if (_currency.CurrencyID == customerCurrency.CurrencyID)
            //                    return customerCurrency;
            //    }
            //    foreach (Currency _currency in publishedCurrencies)
            //        return _currency;
            //    return CurrencyManager.PrimaryStoreCurrency;
            //}
            //set
            //{
            //    if (value == null)
            //        return;
            //    Customer customer = NopContext.Current.User;
            //    if (customer != null)
            //    {
            //        customer = CustomerManager.UpdateCustomer(customer.CustomerID, customer.CustomerGUID,
            //            customer.Email, customer.PasswordHash, customer.SaltKey, customer.AffiliateID,
            //            customer.BillingAddressID, customer.ShippingAddressID, customer.LastShippingMethodID,
            //            customer.LastPaymentMethodID, customer.LanguageID, value.CurrencyID,
            //            customer.IsAdmin, customer.Active, customer.Deleted, customer.RegistrationDate);
            //    }
            //    if (!NopContext.Current.IsAdmin)
            //    {
            //        CommonHelper.SetCookie("Nop.CustomerCurrency", value.CurrencyID.ToString(), new TimeSpan(365, 0, 0, 0, 0));
            //    }
            //}
        }
    }
}
