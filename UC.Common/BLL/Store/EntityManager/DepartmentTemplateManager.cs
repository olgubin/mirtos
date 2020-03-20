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
    /// Менеджер шаблонов отображения раздела товаров
    /// </summary>
    public class DepartmentTemplateManager
    {
        private const string DEPARTMENTTEMPLATES_ALL_KEY = "Nop.departmenttemplate.all";
        private const string DEPARTMENTTEMPLATES_BY_ID_KEY = "Nop.departmenttemplate.id-{0}";

        public static DepartmentTemplateCollection GetAllDepartmentTemplates()
        {
            string key = string.Format(DEPARTMENTTEMPLATES_ALL_KEY);
            object obj2 = UCCache.Get(key);
            if (obj2 != null)
            {
                return (DepartmentTemplateCollection)obj2;
            }

            DepartmentTemplateCollection departmentTemplateCollection = SqlDepartmentTemplateProvider.GetAllDepartmentTemplates();
            UCCache.Max(key, departmentTemplateCollection);

            return departmentTemplateCollection;
        }

        public static DepartmentTemplate GetByDepartmentTemplateID(int DepartmentTemplateID)
        {
            string key = string.Format(DEPARTMENTTEMPLATES_BY_ID_KEY, DepartmentTemplateID);
            object obj2 = UCCache.Get(key);
            if (obj2 != null)
            {
                return (DepartmentTemplate)obj2;
            }

            DepartmentTemplate departmentTemplate = SqlDepartmentTemplateProvider.GetByDepartmentTemplateID(DepartmentTemplateID);
            UCCache.Max(key, departmentTemplate);

            return departmentTemplate;
        }

        public static DepartmentTemplate InsertDepartmentTemplate
            (
            string Name,
            string TemplatePath,
            int DisplayOrder
            )
        {
            DepartmentTemplate departmentTemplate = SqlDepartmentTemplateProvider.InsertDepartmentTemplate
                (
                Name,
                TemplatePath,
                DisplayOrder
                );

            UCCache.RemoveByPattern(DEPARTMENTTEMPLATES_ALL_KEY);
            UCCache.RemoveByPattern(DEPARTMENTTEMPLATES_BY_ID_KEY);

            return departmentTemplate;
        }

        public static DepartmentTemplate UpdateDepartmentTemplate
            (
            int DepartmentTemplateID,
            string Name,
            string TemplatePath,
            int DisplayOrder
            )
        {
            DepartmentTemplate departmentTemplate = SqlDepartmentTemplateProvider.UpdateDepartmentTemplate
                (
                DepartmentTemplateID,
                Name,
                TemplatePath,
                DisplayOrder
                );

            UCCache.RemoveByPattern(DEPARTMENTTEMPLATES_ALL_KEY);
            UCCache.RemoveByPattern(DEPARTMENTTEMPLATES_BY_ID_KEY);

            return departmentTemplate;
        }

        public static void DeleteDepartmentTemplate(int DepartmentTemplateID)
        {
            bool ret = SqlDepartmentTemplateProvider.DeleteDepartmentTemplate(DepartmentTemplateID);

            new RecordDeletedEvent("departmentTemplate", DepartmentTemplateID, null).Raise();

            UCCache.RemoveByPattern(DEPARTMENTTEMPLATES_ALL_KEY);
            UCCache.RemoveByPattern(DEPARTMENTTEMPLATES_BY_ID_KEY);
        }
    }
}