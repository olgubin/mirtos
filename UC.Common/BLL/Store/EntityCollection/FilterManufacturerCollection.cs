using System;
using System.Collections.Generic;
using System.Text;
using UC.Core;

namespace UC.BLL.Store
{
    public class FilterManufacturerCollection : BaseEntityCollection<FilterManufacturer>
    {
        public FilterManufacturer FindFilterManufacturer(int FilterID, int ManufacturerID)
        {
            foreach (FilterManufacturer filterManufacturer in this)
                if (filterManufacturer.FilterID == FilterID && filterManufacturer.ManufacturerID == ManufacturerID)
                    return filterManufacturer;
            return null;
        }
    }
}
