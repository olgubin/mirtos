using System;
using System.Collections.Generic;
using System.Text;
using UC.Core;

namespace UC.BLL.Store
{
    public class FilterCriteria : BaseEntity
    {
        public FilterCriteria()
        {
        }

        public int FilterCriteriaID { get; set; }
        public int FilterID { get; set; }
        public string Criterion { get; set; }
        public int DisplayOrder { get; set; }

        public Filter Filter
        {
            get
            {
                return FilterManager.GetByFilterID(FilterID);
            }
        }
    }
}
