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
        /// �������� ��� �������������� ���������� ������
        /// </summary>
        /// <param name="ProductID">������������� ������</param>
        /// <returns>��������� ������������� ������</returns>
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
        /// �������� ��� �������������� ���������� ������
        /// </summary>
        /// <param name="ProductID">������������� ������</param>
        /// <returns>��������� ������������� ������</returns>
        public static FilterCriteriaProductCollection GetFilterCriteriaProductByFilterCriteriaID(int FilterCriteriaID)
        {
            FilterCriteriaProductCollection filterCriteriaProductCollection = SqlFilterCriteriaProductProvider.GetFilterCriteriaProductByFilterCriteriaID(FilterCriteriaID);

            return filterCriteriaProductCollection;
        }

        /// <summary>
        /// �������� �������������� ������ 
        /// </summary>
        /// <param name="ProductSpecificationAttributeID">������������� �������������� ������</param>
        /// <returns>�������������� ������</returns>
        public static FilterCriteriaProduct GetByFilterCriteriaProductID(int FilterCriteriaProductID)
        {
            FilterCriteriaProduct filterCriteriaProduct = SqlFilterCriteriaProductProvider.GetByFilterCriteriaProductID(FilterCriteriaProductID);
            return filterCriteriaProduct;
        }

        /// <summary>
        /// �������� �������������� ������
        /// </summary>
        /// <param name="ProductID">������������� ������</param>
        /// <param name="ProductAttributeID">������������� �������������� �������</param>
        /// <param name="AttributeValue">��������</param>
        /// <param name="DisplayOrder">������� ����������</param>
        /// <returns>�������������� ������</returns>
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
        /// ���������� �������������� ������
        /// </summary>
        /// <param name="ProductAttributeMappingID">������������� �������������� ������</param>
        /// <param name="ProductID">������������� ������</param>
        /// <param name="ProductAttributeID">������������� �������������� �������</param>
        /// <param name="AttributeValue">�������� ��������������</param>
        /// <param name="DisplayOrder">������� �����������</param>
        /// <returns>�������������� ������</returns>
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
        /// ������� ������������ �������������� ������
        /// </summary>
        /// <param name="ProductAttributeMappingID">������������� ������������ ������ � ��������������</param>
        public static void DeleteFilterCriteriaProduct(int FilterCriteriaProductID)
        {
            bool ret = SqlFilterCriteriaProductProvider.DeleteFilterCriteriaProduct(FilterCriteriaProductID);

            new RecordDeletedEvent("FilterCriteriaProduct", FilterCriteriaProductID, null).Raise();

            UCCache.RemoveByPattern(FILTERCRITERIAPRODUCT_KEY);
        }
    }
}
