using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Globalization;
using System.Web;
using UC.DAL.Store;
using UC.Core;

namespace UC.BLL.Store
{
    public class ProductSearchedManager
    {
        private const string PRODUCTS_SEARCH_KEY = "UC.product.search-{0}";

        /// <summary>
        /// Получить все товары
        /// </summary>
        /// <param name="showHidden">Отображать скрытые</param>
        /// <returns>Product collection</returns>
        public static ProductSearchedCollection GetProductsSearch(string searchWords)
        {
            string key = string.Format(PRODUCTS_SEARCH_KEY, searchWords.Replace(" ", "_").ToUpper());
            object obj = UCCache.Get(key);
            if (obj != null)
            {
                return (ProductSearchedCollection)obj;
            }

            ProductSearchedCollection productSearchedCollection = SqlProductSearchedProvider.GetSearch(searchWords);

            UCCache.Max(key, productSearchedCollection);

            return productSearchedCollection;
        }
    }
}