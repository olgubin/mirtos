using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Globalization;
using UC.DAL.Store;
using UC.Core;

namespace UC.BLL.Store
{
    public class FilterManufacturerManager
    {
        private const string FILTERMANUFACTURER_KEY = "UC.filter.manufacturer-{0}";
        private const string FILTERCRITERIA_BY_MANUFACTURERID = "UC.filter.criteria.manufacturer-{0}-{1}";

        /// <summary>
        /// Получает все характеристики указанного товара
        /// </summary>
        /// <param name="ProductID">Идентификатор товара</param>
        /// <returns>Коллекция характеристик товара</returns>
        public static FilterManufacturerCollection GetFilterManufacturerByManufacturerID(int ManufacturerID)
        {
            string key = string.Format(FILTERMANUFACTURER_KEY, ManufacturerID);
            object obj = UCCache.Get(key);

            if (obj != null)
            {
                return (FilterManufacturerCollection)obj;
            }

            FilterManufacturerCollection filterManufacturerCollection = SqlFilterManufacturerProvider.GetFilterManufacturerByManufacturerID(ManufacturerID);

            UCCache.Max(key, filterManufacturerCollection);

            return filterManufacturerCollection;
        }

        /// <summary>
        /// Возвращает уникальный список FilterCriteriaProduct для указанного раздела каталога
        /// </summary>
        /// <param name="ProductID">Идентификатор товара</param>
        /// <returns>Коллекция характеристик товара</returns>
        public static FilterCriteriaCollection GetFilterCriteriaByManufacturerID(int ManufacturerID, bool Visible)
        {
            string key = string.Format(FILTERCRITERIA_BY_MANUFACTURERID, ManufacturerID, Visible);
            object obj = UCCache.Get(key);

            if (obj != null)
            {
                return (FilterCriteriaCollection)obj;
            }

            FilterCriteriaCollection filterCriteriaCollection = SqlFilterCriteriaProvider.GetFilterCriteriaByManufacturerID(ManufacturerID, Visible);

            UCCache.Max(key, filterCriteriaCollection);

            return filterCriteriaCollection;
        }

        /// <summary>
        /// Получить характеристику товара 
        /// </summary>
        /// <param name="ProductSpecificationAttributeID">идентификатор характеристики товара</param>
        /// <returns>Характеристика товара</returns>
        public static FilterManufacturer GetByFilterManufacturerID(int FilterManufacturerID)
        {
            FilterManufacturer filterManufacturer = SqlFilterManufacturerProvider.GetByFilterManufacturerID(FilterManufacturerID);
            return filterManufacturer;
        }

        /// <summary>
        /// Добавить характеристику товара
        /// </summary>
        /// <param name="ProductID">Идентификатор товара</param>
        /// <param name="ProductAttributeID">Идентификатор характеристики товаров</param>
        /// <param name="AttributeValue">Значение</param>
        /// <param name="DisplayOrder">Порядок тображения</param>
        /// <returns>Характеристика товара</returns>
        public static FilterManufacturer InsertFilterManufacturer
            (
            int ManufacturerID, 
            int FilterID,
            int DisplayOrder
            )
        {
            FilterManufacturer filterManufacturer = SqlFilterManufacturerProvider.InsertFilterManufacturer
                (
                ManufacturerID,
                FilterID, 
                DisplayOrder
                );

            UCCache.RemoveByPattern(FILTERMANUFACTURER_KEY);
            UCCache.RemoveByPattern(FILTERCRITERIA_BY_MANUFACTURERID);

            return filterManufacturer;
        }

        /// <summary>
        /// Обновление характеристики товара
        /// </summary>
        /// <param name="ProductAttributeMappingID">идентификатор характеристики товара</param>
        /// <param name="ProductID">идентификатор товара</param>
        /// <param name="ProductAttributeID">идентификатор характеристики товаров</param>
        /// <param name="AttributeValue">значение характеристики</param>
        /// <param name="DisplayOrder">порядок отображения</param>
        /// <returns>Характеристика товара</returns>
        public static FilterManufacturer UpdateFilterManufacturer
            (
            int FilterManufacturerID,
            int ManufacturerID,
            int FilterID,
            int DisplayOrder
            )
        {
            FilterManufacturer filterManufacturer = SqlFilterManufacturerProvider.UpdateFilterManufacturer
                (
                FilterManufacturerID,
                ManufacturerID,
                FilterID,
                DisplayOrder
                );

            UCCache.RemoveByPattern(FILTERMANUFACTURER_KEY);
            UCCache.RemoveByPattern(FILTERCRITERIA_BY_MANUFACTURERID);

            return filterManufacturer;
        }

        /// <summary>
        /// Удаляем соответствие характеристики товару
        /// </summary>
        /// <param name="ProductAttributeMappingID">Идентификатор соответствия товара и характеристики</param>
        public static void DeleteFilterManufacturer(int FilterManufacturerID)
        {
            bool ret = SqlFilterManufacturerProvider.DeleteFilterManufacturer(FilterManufacturerID);

            new RecordDeletedEvent("FilterManufacturer", FilterManufacturerID, null).Raise();

            UCCache.RemoveByPattern(FILTERMANUFACTURER_KEY);
            UCCache.RemoveByPattern(FILTERCRITERIA_BY_MANUFACTURERID);
        }
    }
}
