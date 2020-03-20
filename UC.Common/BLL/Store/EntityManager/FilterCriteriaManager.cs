using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Globalization;
using System.Web;
using UC.BLL.Store;
using UC.DAL.Store;
using UC.Core;

namespace UC.BLL.Store
{
    /// <summary>
    /// Менеджер рекомендованных товаров
    /// </summary>
    public class FilterCriteriaManager
    {
        private const string FILTERCRITERIA_ALL_KEY = "UC.filtercriteria.all";
        private const string FILTERCRITERIA_BY_FILTERID = "UC.filtercriteria.filterid-{0}";

        public static FilterCriteriaCollection GetFilterCriteria()
        {
            string key = string.Format(FILTERCRITERIA_ALL_KEY);
            object obj = UCCache.Get(key);
            if (obj != null)
            {
                return (FilterCriteriaCollection)obj;
            }

            FilterCriteriaCollection filterCriteriaCollection = SqlFilterCriteriaProvider.GetFilterCriteria();
            UCCache.Max(key, filterCriteriaCollection);

            return filterCriteriaCollection;
        }

        public static FilterCriteriaCollection GetFilterCriteriaByFilterID(int FilterID)
        {
            string key = string.Format(FILTERCRITERIA_BY_FILTERID, FilterID.ToString());
            object obj = UCCache.Get(key);
            if (obj != null)
            {
                return (FilterCriteriaCollection)obj;
            }

            FilterCriteriaCollection filterCriteriaCollection = SqlFilterCriteriaProvider.GetFilterCriteriaByFilterID(FilterID);
            UCCache.Max(key, filterCriteriaCollection);

            return filterCriteriaCollection;
        }

        public static FilterCriteria GetByFilterCriteriaID(int FilterCriteriaID)
        {
            return SqlFilterCriteriaProvider.GetByFilterCriteriaID(FilterCriteriaID);
        }

        public static void DeleteFilterCriteria(int FilterCriteriaID)
        {
            SqlFilterCriteriaProvider.DeleteFilterCriteria(FilterCriteriaID);

            UCCache.RemoveByPattern(FILTERCRITERIA_ALL_KEY);
            UCCache.RemoveByPattern(FILTERCRITERIA_BY_FILTERID);
        }

        public static FilterCriteria InsertFilterCriteria
            (
            int FilterID,
            string Criterion,
            int DisplayOrder
            )
        {
            string criterion = "";
            if (Criterion.Length > 127)
                criterion = Criterion.Remove(127);
            else
                criterion = Criterion;

            FilterCriteria filterCriteria = SqlFilterCriteriaProvider.InsertFilterCriteria(FilterID, Criterion, DisplayOrder);

            UCCache.RemoveByPattern(FILTERCRITERIA_ALL_KEY);
            UCCache.RemoveByPattern(FILTERCRITERIA_BY_FILTERID);

            return filterCriteria;
        }

        public static FilterCriteria UpdateFilterCriteria
            (
            int FilterCriteriaID,
            int FilterID,
            string Criterion, 
            int DisplayOrder
            )
        {
            string criterion = "";
            if (Criterion.Length > 127)
                criterion = Criterion.Remove(127);
            else
                criterion = Criterion;

            FilterCriteria filterCriteria = SqlFilterCriteriaProvider.UpdateFilterCriteria(FilterCriteriaID, FilterID, Criterion, DisplayOrder);

            UCCache.RemoveByPattern(FILTERCRITERIA_ALL_KEY);
            UCCache.RemoveByPattern(FILTERCRITERIA_BY_FILTERID);

            return filterCriteria;
        }
    }
}
