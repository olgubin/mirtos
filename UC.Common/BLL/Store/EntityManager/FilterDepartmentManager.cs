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
        /// Получает все характеристики указанного товара
        /// </summary>
        /// <param name="ProductID">Идентификатор товара</param>
        /// <returns>Коллекция характеристик товара</returns>
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
        /// Возвращает уникальный список FilterCriteriaProduct для указанного раздела каталога
        /// </summary>
        /// <param name="ProductID">Идентификатор товара</param>
        /// <returns>Коллекция характеристик товара</returns>
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
        /// Получить характеристику товара 
        /// </summary>
        /// <param name="ProductSpecificationAttributeID">идентификатор характеристики товара</param>
        /// <returns>Характеристика товара</returns>
        public static FilterDepartment GetByFilterDepartmentID(int FilterDepartmentID)
        {
            FilterDepartment filterDepartment = SqlFilterDepartmentProvider.GetByFilterDepartmentID(FilterDepartmentID);
            return filterDepartment;
        }

        /// <summary>
        /// Добавить характеристику товара
        /// </summary>
        /// <param name="ProductID">Идентификатор товара</param>
        /// <param name="ProductAttributeID">Идентификатор характеристики товаров</param>
        /// <param name="AttributeValue">Значение</param>
        /// <param name="DisplayOrder">Порядок тображения</param>
        /// <returns>Характеристика товара</returns>
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
        /// Обновление характеристики товара
        /// </summary>
        /// <param name="ProductAttributeMappingID">идентификатор характеристики товара</param>
        /// <param name="ProductID">идентификатор товара</param>
        /// <param name="ProductAttributeID">идентификатор характеристики товаров</param>
        /// <param name="AttributeValue">значение характеристики</param>
        /// <param name="DisplayOrder">порядок отображения</param>
        /// <returns>Характеристика товара</returns>
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
        /// Удаляем соответствие характеристики товару
        /// </summary>
        /// <param name="ProductAttributeMappingID">Идентификатор соответствия товара и характеристики</param>
        public static void DeleteFilterDepartment(int FilterDepartmentID)
        {
            bool ret = SqlFilterDepartmentProvider.DeleteFilterDepartment(FilterDepartmentID);

            new RecordDeletedEvent("FilterDepartment", FilterDepartmentID, null).Raise();

            UCCache.RemoveByPattern(FILTERDEPARTMENT_KEY);
            UCCache.RemoveByPattern(FILTERCRITERIA_BY_DEPARTMENTID);
        }
    }
}
