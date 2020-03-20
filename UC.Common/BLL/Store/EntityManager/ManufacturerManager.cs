using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using UC.DAL.Store;
using UC.Core;

namespace UC.BLL.Store
{
    public class ManufacturerManager
    {
        private const string MANUFACTURERS_ALL_KEY = "UC.manufacturer.all-{0}";
        private const string MANUFACTURERS_BY_ID_KEY = "UC.manufacturer.id-{0}";

        /***********************************
        * Статические методы
        ************************************/

        /// <summary>
        /// Возвращает коллекцию производителей
        /// </summary>
        public static ManufacturerCollection GetManufacturers(bool showHidden)
        {
            string key = string.Format(MANUFACTURERS_ALL_KEY, showHidden);
            object obj = UCCache.Get(key);
            if (obj != null)
            {
                return (ManufacturerCollection)obj;
            }

            ManufacturerCollection manufacturerCollection = SqlManufacturersProvider.GetManufacturers(showHidden);
            UCCache.Max(key, manufacturerCollection);

            return manufacturerCollection;
        }

        /// <summary>
        /// Возвращает коллекцию всех производителей
        /// </summary>
        public static ManufacturerCollection GetManufacturers()
        {
            return GetManufacturers(true);
        }

        /// <summary>
        /// Возвращает указанное количество производителей, первые по списку
        /// </summary>
        public static ManufacturerCollection GetManufacturersTop(int count)
        {
            ManufacturerCollection manufacturerCollection = SqlManufacturersProvider.GetManufacturers(false);

            ManufacturerCollection ret = new ManufacturerCollection();

            for (int i = 0; i < count; i++)
            {
                if (i > manufacturerCollection.Count - 1)
                    break;

                ret.Add(manufacturerCollection[i]);
            }

            return ret;
        }

        /// <summary>
        /// Возвращает производителя по указанному ID
        /// </summary>
        public static Manufacturer GetManufacturerByID(int manufacturerID)
        {
            string key = string.Format(MANUFACTURERS_BY_ID_KEY, manufacturerID);
            object obj = UCCache.Get(key);
            if (obj != null)
            {
                return (Manufacturer)obj;
            }

            Manufacturer manufacturer = SqlManufacturersProvider.GetByManufacturerID(manufacturerID);
            UCCache.Max(key, manufacturer);

            return manufacturer;
        }

        /// <summary>
        /// Возвращает полное описание
        /// </summary>
        public static string GetManufacturerLongDescription(int ManufacturerID)
        {
            return SqlManufacturersProvider.GetManufacturerLongDescription(ManufacturerID);
        }

        /// <summary>
        /// Обновляет полное описание
        /// </summary>
        public static bool UpdateManufacturerLongDescription(int ManufacturerID, string LongDescription)
        {
            bool ret = SqlManufacturersProvider.UpdateManufacturerLongDescription(ManufacturerID, LongDescription);

            return ret;
        }

        /// <summary>
        /// Обновляет информацию о производителе
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
            bool Published
            )
        {
            Manufacturer manufacturer = SqlManufacturersProvider.UpdateManufacturer
                (
                ManufacturerID,
                Title,
                Description,
                MetaTitle,
                MetaDescription,
                MetaKeywords,
                ImageUrl,
                Url,
                ArticleID,
                DisplayOrder,
                Published,
                DateTime.Now,
                BizObject.CurrentUserName
                );

            UCCache.RemoveByPattern(MANUFACTURERS_ALL_KEY);
            UCCache.RemoveByPattern(MANUFACTURERS_BY_ID_KEY);

            return manufacturer;
        }

        /// <summary>
        /// Создает нового производителя
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
            bool Published
            )
        {
            Manufacturer manufacturer = SqlManufacturersProvider.InsertManufacturer
                (
                Title,
                Description,
                MetaTitle,
                MetaDescription,
                MetaKeywords,
                ImageUrl,
                Url,
                ArticleID,
                DisplayOrder,
                Published,
                DateTime.Now,
                BizObject.CurrentUserName
                );

            UCCache.RemoveByPattern(MANUFACTURERS_ALL_KEY);
            UCCache.RemoveByPattern(MANUFACTURERS_BY_ID_KEY);

            return manufacturer;
        }

        /// <summary>
        /// Удаляет существующего производителя
        /// </summary>
        public static void DeleteManufacturer(int manufacturerID)
        {
            bool ret = SqlManufacturersProvider.DeleteManufacturer(manufacturerID);

            new RecordDeletedEvent("manufacturer", manufacturerID, null).Raise();

            UCCache.RemoveByPattern(MANUFACTURERS_ALL_KEY);
            UCCache.RemoveByPattern(MANUFACTURERS_BY_ID_KEY);
        }

        /// <summary>
        /// Отображение, скрытие бренда
        /// </summary>
        public static bool VisibleManufacturer(int manufacturerID, bool isVisible)
        {
            bool ret = SqlManufacturersProvider.ManufacturerPublished(manufacturerID, isVisible);

            UCCache.RemoveByPattern(MANUFACTURERS_ALL_KEY);
            UCCache.RemoveByPattern(MANUFACTURERS_BY_ID_KEY);

            return ret;
        }
    }
}