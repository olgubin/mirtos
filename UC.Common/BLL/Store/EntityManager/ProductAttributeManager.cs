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
    /// �������� ������������� �������
    /// </summary>
    public class ProductAttributeManager
    {
        private const string PRODUCTATTRIBUTE_ALL_KEY = "UC.department.all";
        private const string PRODUCTATTRIBUTE_BY_ID_KEY = "UC.ProductAttributes.id-{0}";

        /// <summary>
        /// �������� ������ ������������� �������
        /// </summary>
        /// <returns>��������� ������������� �������</returns>
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
        /// �������� �������������� ������� �� ��������������
        /// </summary>
        /// <param name="ProductAttributeID">������������� �������������� �������</param>
        /// <returns>����� �������������� �������</returns>
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
        /// ������� �������������� �������
        /// </summary>
        /// <param name="ProductAttributeID">������������� �������������� �������</param>
        public static void DeleteProductAttribute(int ProductAttributeID)
        {
            bool ret = SqlProductAttributeProvider.DeleteProductAttribute(ProductAttributeID);

            new RecordDeletedEvent("ProductAttribute", ProductAttributeID, null).Raise();

            UCCache.RemoveByPattern(PRODUCTATTRIBUTE_ALL_KEY);
            UCCache.RemoveByPattern(PRODUCTATTRIBUTE_BY_ID_KEY);
        }

        /// <summary>
        /// �������� �������������� �������
        /// </summary>
        /// <param name="Name">��� �������������� �������</param>
        /// <returns>��������������</returns>
        public static ProductAttribute InsertProductAttribute(string Name)
        {
            ProductAttribute productAttribute = SqlProductAttributeProvider.InsertProductAttribute(Name);

            UCCache.RemoveByPattern(PRODUCTATTRIBUTE_ALL_KEY);
            UCCache.RemoveByPattern(PRODUCTATTRIBUTE_BY_ID_KEY);

            return productAttribute;
        }

        /// <summary>
        /// �������� �������������� �������
        /// </summary>
        /// <param name="AttributeID">������������� �������������� �������</param>
        /// <param name="Name">��� �������������� �������</param>
        /// <returns>�������������� �������</returns>
        public static ProductAttribute UpdateProductAttribute(int ProductAttributeID, string Name)
        {
            ProductAttribute productAttribute = SqlProductAttributeProvider.UpdateProductAttribute(ProductAttributeID, Name);

            UCCache.RemoveByPattern(PRODUCTATTRIBUTE_ALL_KEY);
            UCCache.RemoveByPattern(PRODUCTATTRIBUTE_BY_ID_KEY);

            return productAttribute;
        }
    }
}
