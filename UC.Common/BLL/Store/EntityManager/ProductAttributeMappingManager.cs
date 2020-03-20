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
        /// ������� ������������ �������������� ������
        /// </summary>
        /// <param name="ProductAttributeMappingID">������������� ������������ ������ � ��������������</param>
        public static void DeleteProductAttributeMapping(int ProductAttributeMappingID)
        {
            bool ret = SqlProductAttributeMappingProvider.DeleteProductAttributeMapping(ProductAttributeMappingID);

            new RecordDeletedEvent("ProductAttributeMapping", ProductAttributeMappingID, null).Raise();

            UCCache.RemoveByPattern(PRODUCTATTRIBUTEMAPPING_KEY);
        }

        /// <summary>
        /// �������� ��� �������������� ���������� ������
        /// </summary>
        /// <param name="ProductID">������������� ������</param>
        /// <returns>��������� ������������� ������</returns>
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
        /// �������� ��� �������������� ���������� ������ ��� �������� ��������
        /// </summary>
        /// <param name="ProductID">������������� ������</param>
        /// <returns>��������� ������������� ������</returns>
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
        /// �������� �������������� ������ 
        /// </summary>
        /// <param name="ProductSpecificationAttributeID">������������� �������������� ������</param>
        /// <returns>�������������� ������</returns>
        public static ProductAttributeMapping GetByProductAttributeMappingID(int ProductAttributeMappingID)
        {
            ProductAttributeMapping productAttributeMapping = SqlProductAttributeMappingProvider.GetByProductAttributeMappingID(ProductAttributeMappingID);
            return productAttributeMapping;
        }

        /// <summary>
        /// �������� �������������� ������
        /// </summary>
        /// <param name="ProductID">������������� ������</param>
        /// <param name="ProductAttributeID">������������� �������������� �������</param>
        /// <param name="AttributeValue">��������</param>
        /// <param name="DisplayOrder">������� ����������</param>
        /// <returns>�������������� ������</returns>
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
        /// ���������� �������������� ������
        /// </summary>
        /// <param name="ProductAttributeMappingID">������������� �������������� ������</param>
        /// <param name="ProductID">������������� ������</param>
        /// <param name="ProductAttributeID">������������� �������������� �������</param>
        /// <param name="AttributeValue">�������� ��������������</param>
        /// <param name="DisplayOrder">������� �����������</param>
        /// <returns>�������������� ������</returns>
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
