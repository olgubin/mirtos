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
        /// �������� ��� �������������� ���������� ������
        /// </summary>
        /// <param name="ProductID">������������� ������</param>
        /// <returns>��������� ������������� ������</returns>
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
        /// ���������� ���������� ������ FilterCriteriaProduct ��� ���������� ������� ��������
        /// </summary>
        /// <param name="ProductID">������������� ������</param>
        /// <returns>��������� ������������� ������</returns>
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
        /// �������� �������������� ������ 
        /// </summary>
        /// <param name="ProductSpecificationAttributeID">������������� �������������� ������</param>
        /// <returns>�������������� ������</returns>
        public static FilterManufacturer GetByFilterManufacturerID(int FilterManufacturerID)
        {
            FilterManufacturer filterManufacturer = SqlFilterManufacturerProvider.GetByFilterManufacturerID(FilterManufacturerID);
            return filterManufacturer;
        }

        /// <summary>
        /// �������� �������������� ������
        /// </summary>
        /// <param name="ProductID">������������� ������</param>
        /// <param name="ProductAttributeID">������������� �������������� �������</param>
        /// <param name="AttributeValue">��������</param>
        /// <param name="DisplayOrder">������� ����������</param>
        /// <returns>�������������� ������</returns>
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
        /// ���������� �������������� ������
        /// </summary>
        /// <param name="ProductAttributeMappingID">������������� �������������� ������</param>
        /// <param name="ProductID">������������� ������</param>
        /// <param name="ProductAttributeID">������������� �������������� �������</param>
        /// <param name="AttributeValue">�������� ��������������</param>
        /// <param name="DisplayOrder">������� �����������</param>
        /// <returns>�������������� ������</returns>
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
        /// ������� ������������ �������������� ������
        /// </summary>
        /// <param name="ProductAttributeMappingID">������������� ������������ ������ � ��������������</param>
        public static void DeleteFilterManufacturer(int FilterManufacturerID)
        {
            bool ret = SqlFilterManufacturerProvider.DeleteFilterManufacturer(FilterManufacturerID);

            new RecordDeletedEvent("FilterManufacturer", FilterManufacturerID, null).Raise();

            UCCache.RemoveByPattern(FILTERMANUFACTURER_KEY);
            UCCache.RemoveByPattern(FILTERCRITERIA_BY_MANUFACTURERID);
        }
    }
}
