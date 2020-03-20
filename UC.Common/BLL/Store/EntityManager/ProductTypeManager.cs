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
    /// Менеджер типов товаров
    /// </summary>
    public class ProductTypeManager
    {
        private const string PRODUCTTYPE_ALL_KEY = "UC.producttype.all";
        private const string PRODUCTTYPE_BY_ID_KEY = "UC.producttype.id-{0}";

        /// <summary>
        /// Получить список типов товаров
        /// </summary>
        /// <returns>коллекция типов товаров</returns>
        public static ProductTypeCollection GetProductTypes()
        {
            string key = PRODUCTTYPE_ALL_KEY;
            object obj = UCCache.Get(key);
            if (obj != null)
            {
                return (ProductTypeCollection)obj;
            }

            ProductTypeCollection productTypeCollection = SqlProductTypeProvider.GetProductTypes();

            UCCache.Max(key, productTypeCollection);

            return productTypeCollection;
        }

        /// <summary>
        /// Получает тип товара по идентификатору
        /// </summary>
        /// <param name="ProductTypeID">идентификатор типа товара</param>
        /// <returns>Класс тип товара</returns>
        public static ProductType GetByProductTypeID(int ProductTypeID)
        {
            string key = string.Format(PRODUCTTYPE_BY_ID_KEY, ProductTypeID);
            object obj2 = UCCache.Get(key);
            if (obj2 != null)
            {
                return (ProductType)obj2;
            }

            ProductType productType = SqlProductTypeProvider.GetByProductTypeID(ProductTypeID);

            UCCache.Max(key, productType);

            return productType;
        }

        /// <summary>
        /// Удаляет тип товара
        /// </summary>
        /// <param name="ProductTypeID">идентификатор типа товаров</param>
        public static void DeleteProductType(int ProductTypeID)
        {
            bool ret = SqlProductTypeProvider.DeleteProductType(ProductTypeID);

            UCCache.RemoveByPattern(PRODUCTTYPE_ALL_KEY);
            UCCache.RemoveByPattern(PRODUCTTYPE_BY_ID_KEY);
        }

        /// <summary>
        /// Добавить тип товара
        /// </summary>
        /// <param name="Type">Имя характеристики товаров</param>
        /// <returns>Характеристика</returns>
        public static ProductType InsertProductType(string Type)
        {
            ProductType productType = SqlProductTypeProvider.InsertProductType(Type);

            UCCache.RemoveByPattern(PRODUCTTYPE_ALL_KEY);
            UCCache.RemoveByPattern(PRODUCTTYPE_BY_ID_KEY);

            return productType;
        }

        /// <summary>
        /// Обновить тип товаров
        /// </summary>
        /// <param name="ProductTypeID">Идентификатор типа товара</param>
        /// <param name="Type">Имя типа товаров</param>
        /// <returns>тип товаров</returns>
        public static ProductType UpdateProductType(int ProductTypeID, string Type)
        {
            ProductType productType = SqlProductTypeProvider.UpdateProductType(ProductTypeID, Type);

            UCCache.RemoveByPattern(PRODUCTTYPE_ALL_KEY);
            UCCache.RemoveByPattern(PRODUCTTYPE_BY_ID_KEY);

            return productType;
        }
    }
}
