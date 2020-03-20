using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using UC.Core;

namespace UC.BLL.Store
{
    public class Department : BaseEntity
    {
        public Department()
        {
        }

        public int DepartmentID { get; set; }

        public int ParentDepartmentID { get; set; }

        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public string Description { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

        public string ImageUrl { get; set; }

        public bool Published { get; set; }

        public DateTime AddedDate { get; set; }

        public string AddedBy { get; set; }

        public int TemplateID { get; set; }

        public string LongDescription
        {
            get { return DepartmentManager.GetDepartmentLongDescription(DepartmentID); }
        }

        public Department ParentDepartment
        {
            get
            {
                return DepartmentManager.GetByDepartmentID(ParentDepartmentID);
            }
        }

        public DepartmentTemplate DepartmentTemplate
        {
            get
            {
                return DepartmentTemplateManager.GetByDepartmentTemplateID(TemplateID);
            }
        }

        //public ProductDepartmentCollection ProductDepartments
        //{
        //    get
        //    {
        //        return ProductDepartmentManager.GetProductDepartmentsByDepartmentID(DepartmentID);
        //    }
        //}
    }
}