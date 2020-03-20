using System;
using System.Collections.Generic;
using System.Text;
using UC.Core;

namespace UC.BLL.Store
{
    /// <summary>
    /// Шаблон отображения товаров
    /// </summary>
    public class DepartmentTemplate : BaseEntity
    {
        public DepartmentTemplate()
        {
        }

        public int DepartmentTemplateID { get; set; }

        public string Name { get; set; }

        public string TemplatePath { get; set; }

        public int DisplayOrder { get; set; }
    }
}
