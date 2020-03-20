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
    public class FilterDepartment : BaseEntity
    {
        public FilterDepartment()
        {
        }

        public int FilterDepartmentID { get; set; }
        public int FilterID { get; set; }
        public int DepartmentID { get; set; }
        public int DisplayOrder { get; set; }

        public Filter Filter
        {
            get
            {
                return FilterManager.GetByFilterID(FilterID);
            }
        }

        //public Department Department
        //{
        //    get
        //    {
        //        return ProductManager.GetByProductID(DepartmentID);
        //    }
        //}
    }
}
