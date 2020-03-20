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
    /// Product category mapping manager
    /// </summary>
    public class ProductDepartmentMappingManager
    {
        private const string PRODUCTDEPARTMENTS = "UC.product.department";
        private const string ALLBYDEPARTMENTID_KEY = ".all.departmentid-{0}-{1}";
        private const string ALLBYPRODUCTID_KEY = ".all.productid-{0}";
        private const string BY_ID_KEY = ".id-{0}";

        /// <summary>
        /// Удаляет раздел товара
        /// </summary>
        /// <param name="ProductCategoryID">Идентификатор раздела товара</param>
        public static void DeleteProductDepartment(int ProductDepartmentID)
        {
            bool ret = SqlProductDepartmentsMappingProvider.DeleteProductDepartmentMapping(ProductDepartmentID);

            new RecordDeletedEvent("ProductDepartmentMapping", ProductDepartmentID, null).Raise();

            UCCache.RemoveByPattern(PRODUCTDEPARTMENTS);
        }

        /// <summary>
        /// Получает ссылки на все товары в указанной категории
        /// </summary>
        /// <param name="CategoryID">CategoryID</param>
        /// <returns>ProductDepartmentMappingCollection</returns>
        public static ProductDepartmentMappingCollection GetProductDepartmentMappingByDepartmentID(int DepartmentID, bool Visible)
        {
            string key = string.Format(PRODUCTDEPARTMENTS + ALLBYDEPARTMENTID_KEY, DepartmentID, Visible);
            object obj = UCCache.Get(key);

            if (obj != null)
            {
                return (ProductDepartmentMappingCollection)obj;
            }

            ProductDepartmentMappingCollection productDepartmentMappingCollection = SqlProductDepartmentsMappingProvider.GetProductDepartmentMappingByDepartmentID(DepartmentID, Visible);

            UCCache.Max(key, productDepartmentMappingCollection);

            return productDepartmentMappingCollection;
        }

        /// <summary>
        /// Получает ссылки на все разделы в которых есть указанный товар
        /// </summary>
        /// <param name="CategoryID">ProductID</param>
        /// <returns>ProductDepartmentMappingCollection</returns>
        public static ProductDepartmentMappingCollection GetProductDepartmentMappingByProductID(int ProductID)
        {
            string key = string.Format(PRODUCTDEPARTMENTS + ALLBYPRODUCTID_KEY, ProductID);
            object obj = UCCache.Get(key);

            if (obj != null)
            {
                return (ProductDepartmentMappingCollection)obj;
            }

            ProductDepartmentMappingCollection productDepartmentMappingCollection = SqlProductDepartmentsMappingProvider.GetProductDepartmentMappingByProductID(ProductID);

            UCCache.Max(key, productDepartmentMappingCollection);

            return productDepartmentMappingCollection;
        }

        /// <summary>
        /// Получает связку товар категория по идентификатору
        /// </summary>
        /// <param name="ProductDepartmentID">ProductDepartmentID</param>
        /// <returns>ProductDepartmentMapping</returns>
        public static ProductDepartmentMapping GetByProductDepartmentMappingID(int ProductDepartmentID)
        {
            string key = string.Format(PRODUCTDEPARTMENTS + BY_ID_KEY, ProductDepartmentID);
            object obj = UCCache.Get(key);

            if (obj != null)
            {
                return (ProductDepartmentMapping)obj;
            }

            ProductDepartmentMapping productDepartmentMapping = SqlProductDepartmentsMappingProvider.GetByProductDepartmentMappingID(ProductDepartmentID);

            UCCache.Max(key, productDepartmentMapping);

            return productDepartmentMapping;
        }

        /// <summary>
        /// Добавление связи товара с разделом
        /// </summary>
        /// <param name="ProductID">ProductID</param>
        /// <param name="DepartmentID">DepartmentID</param>
        /// <param name="DisplayOrder">DisplayOrder</param>
        /// <returns>ProductDepartmentMapping</returns>
        public static ProductDepartmentMapping InsertProductDepartmentMapping
            (
            int ProductID,
            int DepartmentID,
            int DisplayOrder)
        {
            ProductDepartmentMapping productDepartmentMapping = SqlProductDepartmentsMappingProvider.InsertProductDepartmentMapping
                (
                ProductID,
                DepartmentID, 
                DisplayOrder 
                );

            UCCache.RemoveByPattern(PRODUCTDEPARTMENTS);

            return productDepartmentMapping;
        }

        /// <summary>
        /// Обновление связи товара и раздела
        /// </summary>
        /// <param name="ProductDepartmentID">ProductDepartmentID</param>
        /// <param name="ProductID">ProductID</param>
        /// <param name="DepartmentID">DepartmentID</param>
        /// <param name="DisplayOrder">DisplayOrder</param>
        /// <returns>ProductDepartmentMapping</returns>
        public static ProductDepartmentMapping UpdateProductDepartmentMapping
            (
            int ProductDepartmentID, 
            int ProductID,
            int DepartmentID,
            int DisplayOrder
            )
        {
            ProductDepartmentMapping productDepartmentMapping = SqlProductDepartmentsMappingProvider.UpdateProductDepartmentMapping
                (
                ProductDepartmentID,
                ProductID,
                DepartmentID, 
                DisplayOrder 
                );

            UCCache.RemoveByPattern(PRODUCTDEPARTMENTS);

            return productDepartmentMapping;
        }
    }
}
