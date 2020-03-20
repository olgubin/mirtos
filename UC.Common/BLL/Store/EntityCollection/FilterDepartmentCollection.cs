using System;
using System.Collections.Generic;
using System.Text;
using UC.Core;

namespace UC.BLL.Store
{
    public class FilterDepartmentCollection : BaseEntityCollection<FilterDepartment>
    {
        public FilterDepartment FindFilterDepartment(int FilterID, int DepartmentID)
        {
            foreach (FilterDepartment filterDepartment in this)
                if (filterDepartment.FilterID == FilterID && filterDepartment.DepartmentID == DepartmentID)
                    return filterDepartment;
            return null;
        }
    }
}
