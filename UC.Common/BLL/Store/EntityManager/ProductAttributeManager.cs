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
    /// <summary>
    /// Менеджер характеристик товаров
    /// </summary>
    public class ProductAttributeManager
    {
        private const string PRODUCTATTRIBUTE_ALL_KEY = "UC.department.all";
        private const string PRODUCTATTRIBUTE_BY_ID_KEY = "UC.ProductAttributes.id-{0}";

        /// <summary>
        /// Получить список характеристик товаров
        /// </summary>
        /// <returns>коллекция характеристик товаров</returns>
        public static ProductAttributeCollection GetProductAttributes()
        {
            string key = PRODUCTATTRIBUTE_ALL_KEY;
            object obj = UCCache.Get(key);
            if (obj != null)
            {
                return (ProductAttributeCollection)obj;
            }

            ProductAttributeCollection productAttributeCollection = SqlProductAttributeProvider.GetProductAttributes();

            UCCache.Max(key, productAttributeCollection);

            return productAttributeCollection;
        }

        /// <summary>
        /// Получает характеристику товаров по идентификатору
        /// </summary>
        /// <param name="ProductAttributeID">идентификатор характеристики товаров</param>
        /// <returns>Класс характеристики товаров</returns>
        public static ProductAttribute GetByProductAttributeID(int ProductAttributeID)
        {
            string key = string.Format(PRODUCTATTRIBUTE_BY_ID_KEY, ProductAttributeID);
            object obj2 = UCCache.Get(key);
            if (obj2 != null)
            {
                return (ProductAttribute)obj2;
            }

            ProductAttribute productAttribute = SqlProductAttributeProvider.GetByProductAttributeID(ProductAttributeID);

            UCCache.Max(key, productAttribute);

            return productAttribute;
        }

        /// <summary>
        /// Удаляет характеристику товаров
        /// </summary>
        /// <param name="ProductAttributeID">идентификатор характеристики товаров</param>
        public static void DeleteProductAttribute(int ProductAttributeID)
        {
            bool ret = SqlProductAttributeProvider.DeleteProductAttribute(ProductAttributeID);

            new RecordDeletedEvent("ProductAttribute", ProductAttributeID, null).Raise();

            UCCache.RemoveByPattern(PRODUCTATTRIBUTE_ALL_KEY);
            UCCache.RemoveByPattern(PRODUCTATTRIBUTE_BY_ID_KEY);
        }

        /// <summary>
        /// Добавить характеристику товаров
        /// </summary>
        /// <param name="Name">Имя характеристики товаров</param>
        /// <returns>Характеристика</returns>
        public static ProductAttribute InsertProductAttribute(string Name)
        {
            ProductAttribute productAttribute = SqlProductAttributeProvider.InsertProductAttribute(Name);

            UCCache.RemoveByPattern(PRODUCTATTRIBUTE_ALL_KEY);
            UCCache.RemoveByPattern(PRODUCTATTRIBUTE_BY_ID_KEY);

            return productAttribute;
        }

        /// <summary>
        /// Обновить характеристику товаров
        /// </summary>
        /// <param name="AttributeID">Идентификатор характеристики товаров</param>
        /// <param name="Name">Имя характеристики товаров</param>
        /// <returns>Характеристика товраов</returns>
        public static ProductAttribute UpdateProductAttribute(int ProductAttributeID, string Name)
        {
            ProductAttribute productAttribute = SqlProductAttributeProvider.UpdateProductAttribute(ProductAttributeID, Name);

            UCCache.RemoveByPattern(PRODUCTATTRIBUTE_ALL_KEY);
            UCCache.RemoveByPattern(PRODUCTATTRIBUTE_BY_ID_KEY);

            return productAttribute;
        }
    }
}
