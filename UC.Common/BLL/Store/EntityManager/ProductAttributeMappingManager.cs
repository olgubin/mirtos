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
    public class ProductAttributeMappingManager
    {
        private const string PRODUCTATTRIBUTEMAPPING_KEY = "UC.productattributemapping-{0}";

        /// <summary>
        /// Удаляем соответствие характеристики товару
        /// </summary>
        /// <param name="ProductAttributeMappingID">Идентификатор соответствия товара и характеристики</param>
        public static void DeleteProductAttributeMapping(int ProductAttributeMappingID)
        {
            bool ret = SqlProductAttributeMappingProvider.DeleteProductAttributeMapping(ProductAttributeMappingID);

            new RecordDeletedEvent("ProductAttributeMapping", ProductAttributeMappingID, null).Raise();

            UCCache.RemoveByPattern(PRODUCTATTRIBUTEMAPPING_KEY);
        }

        /// <summary>
        /// Получает все характеристики указанного товара
        /// </summary>
        /// <param name="ProductID">Идентификатор товара</param>
        /// <returns>Коллекция характеристик товара</returns>
        public static ProductAttributeMappingCollection GetProductAttributeMappingByProductID(int ProductID)
        {
            string key = string.Format(PRODUCTATTRIBUTEMAPPING_KEY, ProductID);
            object obj = UCCache.Get(key);

            if (obj != null)
            {
                return (ProductAttributeMappingCollection)obj;
            }

            ProductAttributeMappingCollection productAttributeMappingCollection = SqlProductAttributeMappingProvider.GetProductAttributeMappingByProductID(ProductID);

            UCCache.Max(key, productAttributeMappingCollection);

            return productAttributeMappingCollection;
        }

        /// <summary>
        /// Получает все характеристики указанного товара для краткого описания
        /// </summary>
        /// <param name="ProductID">Идентификатор товара</param>
        /// <returns>Коллекция характеристик товара</returns>
        public static ProductAttributeMappingCollection GetProductAttributeMappingByProductIDInShort(int ProductID)
        {
            string key = string.Format(PRODUCTATTRIBUTEMAPPING_KEY, ProductID);
            object obj = UCCache.Get(key);

            ProductAttributeMappingCollection productAttributeMappingCollection = null;

            if (obj != null)
            {
                productAttributeMappingCollection = (ProductAttributeMappingCollection)obj;
            }

            productAttributeMappingCollection = SqlProductAttributeMappingProvider.GetProductAttributeMappingByProductID(ProductID);

            UCCache.Max(key, productAttributeMappingCollection);

            ProductAttributeMappingCollection result = new ProductAttributeMappingCollection();

            foreach (ProductAttributeMapping item in productAttributeMappingCollection)
            {
                if (item.DisplayInShort)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        /// <summary>
        /// Получить характеристику товара 
        /// </summary>
        /// <param name="ProductSpecificationAttributeID">идентификатор характеристики товара</param>
        /// <returns>Характеристика товара</returns>
        public static ProductAttributeMapping GetByProductAttributeMappingID(int ProductAttributeMappingID)
        {
            ProductAttributeMapping productAttributeMapping = SqlProductAttributeMappingProvider.GetByProductAttributeMappingID(ProductAttributeMappingID);
            return productAttributeMapping;
        }

        /// <summary>
        /// Добавить характеристику товара
        /// </summary>
        /// <param name="ProductID">Идентификатор товара</param>
        /// <param name="ProductAttributeID">Идентификатор характеристики товаров</param>
        /// <param name="AttributeValue">Значение</param>
        /// <param name="DisplayOrder">Порядок тображения</param>
        /// <returns>Характеристика товара</returns>
        public static ProductAttributeMapping InsertProductAttributeMapping
            (
            int ProductID, 
            int ProductAttributeID,
            string AttributeValue, 
            int DisplayOrder,
            bool DisplayInShort)
        {
            ProductAttributeMapping productAttributeMapping = SqlProductAttributeMappingProvider.InsertProductAttributeMapping(ProductID,
                ProductAttributeID, AttributeValue, DisplayOrder, DisplayInShort);

            UCCache.RemoveByPattern(PRODUCTATTRIBUTEMAPPING_KEY);

            return productAttributeMapping;
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
        public static ProductAttributeMapping UpdateProductAttributeMapping
            (
            int ProductAttributeMappingID, 
            int ProductID, 
            int ProductAttributeID, 
            string AttributeValue, 
            int DisplayOrder,
            bool DisplayInShort
            )
        {
            ProductAttributeMapping productAttributeMapping = SqlProductAttributeMappingProvider.UpdateProductAttributeMapping(ProductAttributeMappingID,
                ProductID, ProductAttributeID, AttributeValue, DisplayOrder, DisplayInShort);

            UCCache.RemoveByPattern(PRODUCTATTRIBUTEMAPPING_KEY);

            return productAttributeMapping;
        }
    }
}
