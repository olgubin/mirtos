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
    /// Менеджер разделов
    /// </summary>
    public class DepartmentManager
    {
        private const string DEPARTMENTS_ALL_KEY = "UC.department.all-{0}-{1}";
        private const string DEPARTMENTS_BY_ID_KEY = "UC.department.id-{0}";
        private const string DEPARTMENTS_BY_MANUFACTURERID_KEY = "UC.department.manufacturerid-{0}";

        /// <summary>
        /// Получает видимые разделы
        /// </summary>
        /// <param name="ParentCategoryID">Идентификатор родительского раздела</param>
        /// <returns>Коллекция разделов</returns>
        public static DepartmentCollection GetDepartments(int ParentDepartmentID)
        {
            return GetAllDepartments(ParentDepartmentID, false);
        }

        /// <summary>
        /// Получает все разделы
        /// </summary>
        /// <param name="ParentCategoryID">Идентификатор родительского раздела</param>
        /// <returns>Коллекция разделов</returns>
        public static DepartmentCollection GetAllDepartments(int ParentDepartmentID, bool showHidden)
        {
            string key = string.Format(DEPARTMENTS_ALL_KEY, showHidden, ParentDepartmentID);
            object obj2 = UCCache.Get(key);
            if (obj2 != null)
            {
                return (DepartmentCollection)obj2;
            }

            DepartmentCollection departmentCollection = SqlDepartmentsProvider.GetAllDepartments(ParentDepartmentID, showHidden);
            UCCache.Max(key, departmentCollection);

            return departmentCollection;
        }

        /// <summary>
        /// Получает все разделы
        /// </summary>
        /// <param name="ParentCategoryID">Идентификатор родительского раздела</param>
        /// <returns>Коллекция разделов</returns>
        public static DepartmentCollection GetByManufacturerID(int ManufacturerID)
        {
            string key = string.Format(DEPARTMENTS_BY_MANUFACTURERID_KEY, ManufacturerID);
            object obj2 = UCCache.Get(key);
            if (obj2 != null)
            {
                return (DepartmentCollection)obj2;
            }

            DepartmentCollection departmentCollection = SqlDepartmentsProvider.GetByManufacturerID(ManufacturerID);
            UCCache.Max(key, departmentCollection);

            return departmentCollection;
        }

        /// <summary>
        /// Получает раздел
        /// </summary>
        /// <param name="DepartmentID">Category identifier</param>
        /// <returns>Department</returns>
        public static Department GetByDepartmentID(int DepartmentID)
        {
            string key = string.Format(DEPARTMENTS_BY_ID_KEY, DepartmentID);
            object obj2 = UCCache.Get(key);
            if (obj2 != null)
            {
                return (Department)obj2;
            }

            Department department = SqlDepartmentsProvider.GetByDepartmentID(DepartmentID);
            UCCache.Max(key, department);

            return department;
        }

        /// <summary>
        /// Возвращает полное описание раздела
        /// </summary>
        public static string GetDepartmentLongDescription(int DepartmentID)
        {
            return SqlDepartmentsProvider.GetDepartmentLongDescription(DepartmentID);
        }

        /// <summary>
        /// Обновляет полное описание раздела
        /// </summary>
        public static bool UpdateDepartmentLongDescription(int DepartmentID, string LongDescription)
        {
            bool ret = SqlDepartmentsProvider.UpdateDepartmentLongDescription(DepartmentID, LongDescription);

            return ret;
        }

        /// <summary>
        /// Получает ветку разделов
        /// </summary>
        /// <param name="DepartmentID">Идентификатор раздела</param>
        /// <returns>Department</returns>
        public static DepartmentCollection GetBreadCrumb(int DepartmentID)
        {
            DepartmentCollection breadCrumb = new DepartmentCollection();
            Department department = GetByDepartmentID(DepartmentID);
            while (department != null)
            {
                breadCrumb.Add(department);
                department = department.ParentDepartment;
            }
            breadCrumb.Reverse();
            return breadCrumb;
        }

        /// <summary>
        /// Получает ветку разделов
        /// </summary>
        /// <param name="DepartmentID">Идентификатор раздела</param>
        /// <returns>Department</returns>
        public static DepartmentCollection GetBreadCrumb(int DepartmentID, int DepartmentRootID)
        {
            DepartmentCollection breadCrumb = new DepartmentCollection();
            Department department = GetByDepartmentID(DepartmentID);
            while (department != null)
            {
                breadCrumb.Add(department);
                if (department.ParentDepartment == null)
                {
                    break;
                }
                else
                {
                    if (department.ParentDepartment.DepartmentID == DepartmentRootID)
                        break;
                    else
                        department = department.ParentDepartment;
                }
            }
            breadCrumb.Reverse();
            return breadCrumb;
        }

        /// <summary>
        /// Добавляет категорию
        /// </summary>
        public static Department InsertDepartment
            (
            string Name,
            string Description,
            string MetaKeywords,
            string MetaDescription,
            string MetaTitle,
            int ParentDepartmentID,
            string ImageUrl,
            bool Published,
            int DisplayOrder,
            int TemplateID
            )
        {
            Department department = SqlDepartmentsProvider.InsertDepartment
                (
                Name,
                Description,
                MetaKeywords,
                MetaDescription,
                MetaTitle,
                ParentDepartmentID,
                ImageUrl,
                Published,
                DisplayOrder,
                DateTime.Now,
                BizObject.CurrentUserName,
                TemplateID
                );

            UCCache.RemoveByPattern("department");

            return department;
        }

        /// <summary>
        /// Обновляет раздел
        /// </summary>
        public static Department UpdateDepartment
            (
            int DepartmentID,
            string Name,
            string Description,
            string MetaKeywords,
            string MetaDescription,
            string MetaTitle,
            int ParentDepartmentID,
            string ImageUrl,
            bool Published,
            int DisplayOrder,
            int TemplateID
            )
        {
            if (DepartmentID == ParentDepartmentID)
                ParentDepartmentID = 0;

            Department department = SqlDepartmentsProvider.UpdateDepartment
                (
                DepartmentID,
                Name,
                Description,
                MetaKeywords,
                MetaDescription,
                MetaTitle,
                ParentDepartmentID,
                ImageUrl,
                Published,
                DisplayOrder,
                DateTime.Now,
                BizObject.CurrentUserName,
                TemplateID
                );

            UCCache.RemoveByPattern("department");

            return department;
        }

        /// <summary>
        /// Marks category as deleted
        /// </summary>
        /// <param name="CategoryID">Category identifier</param>
        public static void DeleteDepartment(int DepartmentID)
        {
            bool ret = SqlDepartmentsProvider.DeleteDepartment(DepartmentID);

            new RecordDeletedEvent("department", DepartmentID, null).Raise();

            UCCache.RemoveByPattern("department");
        }
    }
}
