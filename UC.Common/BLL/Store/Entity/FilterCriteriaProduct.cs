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
    public class FilterCriteriaProduct : BaseEntity
    {
        public FilterCriteriaProduct()
        {
        }

        public int FilterCriteriaProductID { get; set; }
        public int FilterCriteriaID { get; set; }
        public int ProductID { get; set; }

        public FilterCriteria FilterCriteria
        {
            get
            {
                return FilterCriteriaManager.GetByFilterCriteriaID(FilterCriteriaID);
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
