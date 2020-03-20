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
    /// Менеджер характеристик товаров
    /// </summary>
    public class FilterManager
    {
        private const string FILTER_ALL_KEY = "UC.filter.all";
        private const string FILTER_BY_ID_KEY = "UC.filter.id-{0}";

        /// <summary>
        /// Получить список фильтров
        /// </summary>
        /// <returns>коллекция фильтров</returns>
        public static FilterCollection GetFilters()
        {
            string key = FILTER_ALL_KEY;
            object obj = UCCache.Get(key);
            if (obj != null)
            {
                return (FilterCollection)obj;
            }

            FilterCollection filterCollection = SqlFilterProvider.GetFilters();

            UCCache.Max(key, filterCollection);

            return filterCollection;
        }

        /// <summary>
        /// Получает фильтр по идентификатору
        /// </summary>
        /// <param name="ProductAttributeID">идентификатор фильтра</param>
        /// <returns>Filter</returns>
        public static Filter GetByFilterID(int FilterID)
        {
            string key = string.Format(FILTER_BY_ID_KEY, FilterID);
            object obj2 = UCCache.Get(key);
            if (obj2 != null)
            {
                return (Filter)obj2;
            }

            Filter filter = SqlFilterProvider.GetByFilterID(FilterID);

            UCCache.Max(key, filter);

            return filter;
        }

        /// <summary>
        /// Удаляет характеристику товаров
        /// </summary>
        /// <param name="ProductAttributeID">идентификатор характеристики товаров</param>
        public static void DeleteFilter(int FilterID)
        {
            bool ret = SqlFilterProvider.DeleteFilter(FilterID);

            new RecordDeletedEvent("Filter", FilterID, null).Raise();

            UCCache.RemoveByPattern(FILTER_ALL_KEY);
            UCCache.RemoveByPattern(FILTER_BY_ID_KEY);
        }

        /// <summary>
        /// Добавить характеристику товаров
        /// </summary>
        /// <param name="Name">Имя характеристики товаров</param>
        /// <returns>Характеристика</returns>
        public static Filter InsertFilter(string Name)
        {
            Filter filter = SqlFilterProvider.InsertFilter(Name);

            UCCache.RemoveByPattern(FILTER_ALL_KEY);
            UCCache.RemoveByPattern(FILTER_BY_ID_KEY);

            return filter;
        }

        /// <summary>
        /// Обновить характеристику товаров
        /// </summary>
        /// <param name="AttributeID">Идентификатор характеристики товаров</param>
        /// <param name="Name">Имя характеристики товаров</param>
        /// <returns>Характеристика товраов</returns>
        public static Filter UpdateFilter(int FilterID, string Name)
        {
            Filter filter = SqlFilterProvider.UpdateFilter(FilterID, Name);

            UCCache.RemoveByPattern(FILTER_ALL_KEY);
            UCCache.RemoveByPattern(FILTER_BY_ID_KEY);

            return filter;
        }
    }
}
