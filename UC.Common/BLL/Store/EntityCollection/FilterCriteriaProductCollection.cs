using System;
using System.Collections.Generic;
using System.Text;
using UC.Core;

namespace UC.BLL.Store
{
    public class FilterCriteriaProductCollection : BaseEntityCollection<FilterCriteriaProduct>
    {
        public FilterCriteriaProduct FindFilterCriteriaProduct(int FilterCriteriaID, int ProductID)
        {
            foreach (FilterCriteriaProduct filterCriteriaProduct in this)
                if (filterCriteriaProduct.FilterCriteriaID == FilterCriteriaID && filterCriteriaProduct.ProductID == ProductID)
                    return filterCriteriaProduct;
            return null;
        }
    }
}
