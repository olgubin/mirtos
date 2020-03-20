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
    public class ProductFeaturedManager
    {
        private const string PRODUCTFETURED_ALL_KEY = "UC.productfeatured.all-{0}";
        private const string PRODUCTFETURED_TOP_PAGE = "PRODUCTFETURED_TOP_PAGE";

        public static ProductFeaturedCollection GetProductFeatured()
        {
            bool showHidden = HttpContext.Current.User.IsInRole("Administrator");

            string key = string.Format(PRODUCTFETURED_ALL_KEY, showHidden);
            object obj = UCCache.Get(key);
            if (obj != null)
            {
                return (ProductFeaturedCollection)obj;
            }

            ProductFeaturedCollection productFeaturedCollection = SqlProductFeaturedProvider.GetProductFeatured(showHidden);
            UCCache.Max(key, productFeaturedCollection);

            return productFeaturedCollection;
        }

        /// <summary>
        /// Возвращает указанное количество рекомендуемых товаров чередуя показы
        /// </summary>
        public static ProductFeaturedCollection GetProductFeaturedTop(int top, bool rotate)
        {
            ProductFeaturedCollection productFeaturedCollection = GetProductFeatured();

            ProductFeaturedCollection result = new ProductFeaturedCollection();

            if (rotate)
            {
                int page = 0;

                object obj = UCCache.Get(PRODUCTFETURED_TOP_PAGE);

                if (obj != null)
                {
                    page = (int)obj;
                }

                if (productFeaturedCollection.Count > 0)
                {
                    //заполняем список
                    for (int i = 0; i < top; i++)
                    {
                        page += 1;

                        if (page >= productFeaturedCollection.Count)
                        {
                            page = 0;
                        }

                        result.Add(productFeaturedCollection[page]);
                    }

                    UCCache.Max(PRODUCTFETURED_TOP_PAGE, page);
                }
            }
            else
            {
                if (productFeaturedCollection.Count > 0)
                {
                    for (int i = 0; i < top; i++)
                    {
                        result.Add(productFeaturedCollection[i]);
                    }
                }
            }

            return result;
        }

        public static ProductFeatured GetByProductFeaturedID(int ProductFeaturedID)
        {
            return SqlProductFeaturedProvider.GetByProductFeaturedID(ProductFeaturedID);
        }

        public static void DeleteProductFeatured(int ProductFeaturedID)
        {
            SqlProductFeaturedProvider.DeleteProductFeatured(ProductFeaturedID);

            UCCache.RemoveByPattern(PRODUCTFETURED_ALL_KEY);
        }

        public static ProductFeatured InsertProductFeatured(int ProductID, string Description, int DisplayOrder)
        {
            string description = "";
            if (Description.Length > 127)
                description = Description.Remove(127);
            else
                description = Description;

            ProductFeatured productFeatured = SqlProductFeaturedProvider.InsertProductFeatured(ProductID, description, DisplayOrder);

            UCCache.RemoveByPattern(PRODUCTFETURED_ALL_KEY);

            return productFeatured;
        }

        public static ProductFeatured UpdateProductFeatured(int ProductFeaturedID, int ProductID, string Description, int DisplayOrder)
        {
            string description = "";
            if (Description.Length > 127)
                description = Description.Remove(127);
            else
                description = Description;

            ProductFeatured productFeatured = SqlProductFeaturedProvider.UpdateProductFeatured(ProductFeaturedID, ProductID, description, DisplayOrder);

            UCCache.RemoveByPattern(PRODUCTFETURED_ALL_KEY);

            return productFeatured;
        }
    }
}
