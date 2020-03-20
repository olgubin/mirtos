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
    public class FilterCriteriaProductManager
    {
        private const string FILTERCRITERIAPRODUCT_KEY = "UC.filtercriteriaproduct-{0}";

        /// <summary>
        /// Получает все характеристики указанного товара
        /// </summary>
        /// <param name="ProductID">Идентификатор товара</param>
        /// <returns>Коллекция характеристик товара</returns>
        public static FilterCriteriaProductCollection GetFilterCriteriaProductByProductID(int ProductID)
        {
            string key = string.Format(FILTERCRITERIAPRODUCT_KEY, ProductID);
            object obj = UCCache.Get(key);

            if (obj != null)
            {
                return (FilterCriteriaProductCollection)obj;
            }

            FilterCriteriaProductCollection filterCriteriaProductCollection = SqlFilterCriteriaProductProvider.GetFilterCriteriaProductByProductID(ProductID);

            UCCache.Max(key, filterCriteriaProductCollection);

            return filterCriteriaProductCollection;
        }

        /// <summary>
        /// Получает все характеристики указанного товара
        /// </summary>
        /// <param name="ProductID">Идентификатор товара</param>
        /// <returns>Коллекция характеристик товара</returns>
        public static FilterCriteriaProductCollection GetFilterCriteriaProductByFilterCriteriaID(int FilterCriteriaID)
        {
            FilterCriteriaProductCollection filterCriteriaProductCollection = SqlFilterCriteriaProductProvider.GetFilterCriteriaProductByFilterCriteriaID(FilterCriteriaID);

            return filterCriteriaProductCollection;
        }

        /// <summary>
        /// Получить характеристику товара 
        /// </summary>
        /// <param name="ProductSpecificationAttributeID">идентификатор характеристики товара</param>
        /// <returns>Характеристика товара</returns>
        public static FilterCriteriaProduct GetByFilterCriteriaProductID(int FilterCriteriaProductID)
        {
            FilterCriteriaProduct filterCriteriaProduct = SqlFilterCriteriaProductProvider.GetByFilterCriteriaProductID(FilterCriteriaProductID);
            return filterCriteriaProduct;
        }

        /// <summary>
        /// Добавить характеристику товара
        /// </summary>
        /// <param name="ProductID">Идентификатор товара</param>
        /// <param name="ProductAttributeID">Идентификатор характеристики товаров</param>
        /// <param name="AttributeValue">Значение</param>
        /// <param name="DisplayOrder">Порядок тображения</param>
        /// <returns>Характеристика товара</returns>
        public static FilterCriteriaProduct InsertFilterCriteriaProduct
            (
            int ProductID, 
            int FilterCriteriaID
            )
        {
            FilterCriteriaProduct filterCriteriaProduct = SqlFilterCriteriaProductProvider.InsertFilterCriteriaProduct
                (
                ProductID,
                FilterCriteriaID
                );

            UCCache.RemoveByPattern(FILTERCRITERIAPRODUCT_KEY);
            
            return filterCriteriaProduct;
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
        public static FilterCriteriaProduct UpdateFilterCriteriaProduct
            (
            int FilterCriteriaProductID,
            int ProductID,
            int FilterCriteriaID
            )
        {
            FilterCriteriaProduct filterCriteriaProduct = SqlFilterCriteriaProductProvider.UpdateFilterCriteriaProduct
                (
                FilterCriteriaProductID,
                ProductID,
                FilterCriteriaID
                );

            UCCache.RemoveByPattern(FILTERCRITERIAPRODUCT_KEY);

            return filterCriteriaProduct;
        }

        /// <summary>
        /// Удаляем соответствие характеристики товару
        /// </summary>
        /// <param name="ProductAttributeMappingID">Идентификатор соответствия товара и характеристики</param>
        public static void DeleteFilterCriteriaProduct(int FilterCriteriaProductID)
        {
            bool ret = SqlFilterCriteriaProductProvider.DeleteFilterCriteriaProduct(FilterCriteriaProductID);

            new RecordDeletedEvent("FilterCriteriaProduct", FilterCriteriaProductID, null).Raise();

            UCCache.RemoveByPattern(FILTERCRITERIAPRODUCT_KEY);
        }
    }
}
