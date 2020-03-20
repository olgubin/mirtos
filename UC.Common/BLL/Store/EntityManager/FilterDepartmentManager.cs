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
    public class FilterDepartmentManager
    {
        private const string FILTERDEPARTMENT_KEY = "UC.filterdepartment-{0}";
        private const string FILTERCRITERIA_BY_DEPARTMENTID = "UC.filtercriteria.department-{0}-{1}";

        /// <summary>
        /// �������� ��� �������������� ���������� ������
        /// </summary>
        /// <param name="ProductID">������������� ������</param>
        /// <returns>��������� ������������� ������</returns>
        public static FilterDepartmentCollection GetFilterDepartmentByDepartmentID(int DepartmentID)
        {
            string key = string.Format(FILTERDEPARTMENT_KEY, DepartmentID);
            object obj = UCCache.Get(key);

            if (obj != null)
            {
                return (FilterDepartmentCollection)obj;
            }

            FilterDepartmentCollection filterDepartmentCollection = SqlFilterDepartmentProvider.GetFilterDepartmentByDepartmentID(DepartmentID);

            UCCache.Max(key, filterDepartmentCollection);

            return filterDepartmentCollection;
        }

        /// <summary>
        /// ���������� ���������� ������ FilterCriteriaProduct ��� ���������� ������� ��������
        /// </summary>
        /// <param name="ProductID">������������� ������</param>
        /// <returns>��������� ������������� ������</returns>
        public static FilterCriteriaCollection GetFilterCriteriaByDepartmentID(int DepartmentID, bool Visible)
        {
            string key = string.Format(FILTERCRITERIA_BY_DEPARTMENTID, DepartmentID, Visible);
            object obj = UCCache.Get(key);

            if (obj != null)
            {
                return (FilterCriteriaCollection)obj;
            }

            FilterCriteriaCollection filterCriteriaCollection = SqlFilterCriteriaProvider.GetFilterCriteriaByDepartmentID(DepartmentID, Visible);

            UCCache.Max(key, filterCriteriaCollection);

            return filterCriteriaCollection;
        }

        /// <summary>
        /// �������� �������������� ������ 
        /// </summary>
        /// <param name="ProductSpecificationAttributeID">������������� �������������� ������</param>
        /// <returns>�������������� ������</returns>
        public static FilterDepartment GetByFilterDepartmentID(int FilterDepartmentID)
        {
            FilterDepartment filterDepartment = SqlFilterDepartmentProvider.GetByFilterDepartmentID(FilterDepartmentID);
            return filterDepartment;
        }

        /// <summary>
        /// �������� �������������� ������
        /// </summary>
        /// <param name="ProductID">������������� ������</param>
        /// <param name="ProductAttributeID">������������� �������������� �������</param>
        /// <param name="AttributeValue">��������</param>
        /// <param name="DisplayOrder">������� ����������</param>
        /// <returns>�������������� ������</returns>
        public static FilterDepartment InsertFilterDepartment
            (
            int DepartmentID, 
            int FilterID,
            int DisplayOrder
            )
        {
            FilterDepartment filterDepartment = SqlFilterDepartmentProvider.InsertFilterDepartment
                (
                DepartmentID,
                FilterID, 
                DisplayOrder
                );

            UCCache.RemoveByPattern(FILTERDEPARTMENT_KEY);
            UCCache.RemoveByPattern(FILTERCRITERIA_BY_DEPARTMENTID);

            return filterDepartment;
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
        public static FilterDepartment UpdateFilterDepartment
            (
            int FilterDepartmentID,
            int DepartmentID,
            int FilterID,
            int DisplayOrder
            )
        {
            FilterDepartment filterDepartment = SqlFilterDepartmentProvider.UpdateFilterDepartment
                (
                FilterDepartmentID,
                DepartmentID,
                FilterID,
                DisplayOrder
                );

            UCCache.RemoveByPattern(FILTERDEPARTMENT_KEY);
            UCCache.RemoveByPattern(FILTERCRITERIA_BY_DEPARTMENTID);

            return filterDepartment;
        }

        /// <summary>
        /// ������� ������������ �������������� ������
        /// </summary>
        /// <param name="ProductAttributeMappingID">������������� ������������ ������ � ��������������</param>
        public static void DeleteFilterDepartment(int FilterDepartmentID)
        {
            bool ret = SqlFilterDepartmentProvider.DeleteFilterDepartment(FilterDepartmentID);

            new RecordDeletedEvent("FilterDepartment", FilterDepartmentID, null).Raise();

            UCCache.RemoveByPattern(FILTERDEPARTMENT_KEY);
            UCCache.RemoveByPattern(FILTERCRITERIA_BY_DEPARTMENTID);
        }
    }
}
