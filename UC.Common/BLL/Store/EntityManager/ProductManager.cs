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
    public class ProductManager
    {
        private const string PRODUCTS = "UC.product";
        private const string ALL_KEY = ".all-{0}";
        private const string BY_ID_KEY = ".id-{0}";
        private const string BY_MANUFACTURERID_KEY = ".manufacturerid-{0}-{1}";
        private const string SALES_KEY = ".sales";
        private const string SALES_TOP = ".sales.top";

        /// <summary>
        /// Получить все товары
        /// </summary>
        /// <param name="showHidden">Отображать скрытые</param>
        /// <returns>Product collection</returns>
        public static ProductCollection GetAllProducts(bool visible)
        {
            ProductCollection productCollection = new ProductCollection();

            string key = string.Format(PRODUCTS + ALL_KEY, visible);
            object obj = UCCache.Get(key);
            if (obj != null)
            {
                productCollection = (ProductCollection)obj;

                return productCollection;
            }

            productCollection = SqlProductsProvider.GetAllProducts(visible);

            UCCache.Max(key, productCollection);

            return productCollection;
        }

        /// <summary>
        /// Получить все товары по производителю
        /// </summary>
        public static ProductCollection GetByManufacturerID(int ManufacturerID, bool visible)
        {
            ProductCollection productCollection = new ProductCollection();

            string key = string.Format(PRODUCTS + BY_MANUFACTURERID_KEY, ManufacturerID, visible);
            object obj = UCCache.Get(key);
            if (obj != null)
            {
                productCollection = (ProductCollection)obj;

                return productCollection;
            }

            productCollection = SqlProductsProvider.GetByManufacturerID(ManufacturerID, visible);

            UCCache.Max(key, productCollection);

            return productCollection;
        }

        /// <summary>
        /// Получает товар по идентификатору
        /// </summary>
        /// <param name="ProductID">ProductID</param>
        /// <returns>Product</returns>
        public static Product GetByProductID(int ProductID)
        {
            string key = string.Format(PRODUCTS + BY_ID_KEY, ProductID);
            object obj = UCCache.Get(key);
            if (obj != null)
            {
                return (Product)obj;
            }

            Product product = SqlProductsProvider.GetByProductID(ProductID);
            UCCache.Max(key, product);

            return product;
        }

        /// <summary>
        /// Возвращает товары со скидкой
        /// </summary>
        public static ProductCollection GetProductsSales()
        {
            string key = PRODUCTS + SALES_KEY;
            object obj = UCCache.Get(key);
            if (obj != null)
            {
                return (ProductCollection)obj;
            }

            ProductCollection productCollection = SqlProductsProvider.GetProductsSales();

            UCCache.Max(key, productCollection);

            return productCollection;
        }

        /// <summary>
        /// Возвращает товары со скидкой
        /// </summary>
        public static ProductCollection GetProductsTopSales(int top, bool rotate)
        {
            string key = PRODUCTS + SALES_TOP;

            ProductCollection productCollection = GetProductsSales();

            ProductCollection result = new ProductCollection();

            if (rotate)
            {
                int page = 0;

                object obj = UCCache.Get(key);

                if (obj != null)
                {
                    page = (int)obj;
                }

                if (productCollection.Count > 0)
                {
                    //заполняем список
                    for (int i = 0; i < top; i++)
                    {
                        page += 1;

                        if (page >= productCollection.Count)
                        {
                            page = 0;
                        }

                        result.Add(productCollection[page]);
                    }

                    UCCache.Max(key, page);
                }
            }
            else
            {
                if (productCollection.Count > 0)
                {
                    for (int i = 0; i < top; i++)
                    {
                        result.Add(productCollection[i]);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Возвращает количество товаров содержащих картинку
        /// </summary>
        public static int GetProductCountByImageUrl(string ImageUrl)
        {
            return SqlProductsProvider.GetProductCountByImageUrl(ImageUrl);
        }

        /// <summary>
        /// Изменяет видимость товара
        /// </summary>
        public static string GetProductLongDescription(int ProductID)
        {
            return SqlProductsProvider.GetProductLongDescription(ProductID);
        }

        /// <summary>
        /// Добавляет рейтинг товаров
        /// </summary>
        public static bool RateProduct(int ProductID, int rating)
        {
            UCCache.RemoveByPattern(PRODUCTS);

            return SqlProductsProvider.RateProduct(ProductID, rating);
        }

        /// <summary>
        /// Изменяет видимость товара
        /// </summary>
        public static bool ChangeVisible(int ProductID, bool visible)
        {
            bool ret = SqlProductsProvider.ChangeVisible(ProductID, visible);

            UCCache.RemoveByPattern(PRODUCTS);

            return ret;
        }

        /// <summary>
        /// Уменьшает количество товаров в магазине
        /// </summary>
        public static bool DecrementProductUnitsInStock(int ProductID, int quantity)
        {
            bool ret = SqlProductsProvider.DecrementProductUnitsInStock(ProductID, quantity);

            UCCache.RemoveByPattern(PRODUCTS);

            return ret;
        }

        /// <summary>
        /// Изменение цены товара
        /// </summary>
        public static bool ChangeUnitPriceProduct(int ProductID, decimal unitPrice)
        {
            bool ret = SqlProductsProvider.ChangeUnitPriceProduct(ProductID, unitPrice);

            UCCache.RemoveByPattern(PRODUCTS);

            return ret;
        }

        /// <summary>
        /// Изменение цены и скидки на товар
        /// </summary>
        public static bool ChangeUnitPriceAndDiscountPercentage(int ProductID, decimal unitPrice, int discountPercentage, int marginPercentage)
        {
            bool ret = SqlProductsProvider.ChangeUnitPriceAndDiscountPercentage(ProductID, unitPrice, discountPercentage, marginPercentage);

            UCCache.RemoveByPattern(PRODUCTS);

            return ret;
        }

        /// <summary>
        /// Привязка производителя к товару
        /// </summary>
        public static bool AssignProductManufacturer(int ProductID, int manufacturerID)
        {
            bool ret = SqlProductsProvider.AssignProductManufacturer(ProductID, manufacturerID);

            UCCache.RemoveByPattern(PRODUCTS);

            return ret;
        }

        /// <summary>
        /// Привязка валюты к товару
        /// </summary>
        public static bool AssignProductCurrency(int ProductID, int currencyID)
        {
            bool ret = SqlProductsProvider.AssignProductCurrency(ProductID, currencyID);

            UCCache.RemoveByPattern(PRODUCTS);

            return ret;
        }

        /// <summary>
        /// Обновление рисунков
        /// </summary>
        public static bool ChangeImageUrl(int ProductID, string smallImageUrl, string fullImageUrl)
        {
            bool ret = SqlProductsProvider.ChangeImageUrl(ProductID, smallImageUrl, fullImageUrl);

            UCCache.RemoveByPattern(PRODUCTS);

            return ret;
        }

        /// <summary>
        /// Добавление товара
        /// </summary>
        public static Product InsertProduct
            (
            //string Title,
            int ProductTypeID,
            string Model,
            string ShortDescription,
            string LongDescription,
            int ManufacturerID,
            string SKU,
            int CurrencyID,
            decimal UnitPrice,
            int DiscountPercentage,
            int MarginPercentage,
            int UnitsInStock,
            string SmallImageUrl,
            string FullImageUrl,
            bool Visible
            )
        {
            //Title = Helpers.ConvertNullToEmptyString(Title);
            Model = Helpers.ConvertNullToEmptyString(Model);
            ShortDescription = Helpers.ConvertNullToEmptyString(ShortDescription);
            LongDescription = Helpers.ConvertNullToEmptyString(LongDescription);
            SKU = Helpers.ConvertNullToEmptyString(SKU);
            SmallImageUrl = Helpers.ConvertNullToEmptyString(SmallImageUrl);
            FullImageUrl = Helpers.ConvertNullToEmptyString(FullImageUrl);

            Product product = SqlProductsProvider.InsertProduct
                (
                //Title.Trim(),
                ProductTypeID,
                Model.Trim(),
                ShortDescription.Trim(),
                LongDescription.Trim(),
                ManufacturerID,
                SKU.Trim(),
                CurrencyID,
                UnitPrice,
                DiscountPercentage,
                MarginPercentage,
                UnitsInStock,
                SmallImageUrl.Trim(),
                FullImageUrl.Trim(),
                Visible,
                BizObject.CurrentUserName,
                DateTime.Now
                );

            //Добавляем артикул если он не был задан
            if (String.IsNullOrEmpty(SKU))
            {
                string _sku = product.ProductID.ToString();
                for (int i = _sku.Length; i < 5; i++)
                {
                    _sku = "0" + _sku;
                }

                SqlProductsProvider.ChangeSKU(product.ProductID, _sku);
            }

            UCCache.RemoveByPattern(PRODUCTS);

            return GetByProductID(product.ProductID);
        }

        /// <summary>
        /// Обновляет товар
        /// </summary>
        public static Product UpdateProduct
            (
            int ProductID,
            //string Title,
            int ProductTypeID,
            string Model,
            string ShortDescription,
            string LongDescription,
            int ManufacturerID,
            string SKU,
            int CurrencyID,
            decimal UnitPrice,
            int DiscountPercentage,
            int MarginPercentage,
            int UnitsInStock,
            string SmallImageUrl,
            string FullImageUrl,
            bool Visible
            )
        {
            //Title = Helpers.ConvertNullToEmptyString(Title);
            Model = Helpers.ConvertNullToEmptyString(Model);
            ShortDescription = Helpers.ConvertNullToEmptyString(ShortDescription);
            LongDescription = Helpers.ConvertNullToEmptyString(LongDescription);
            SKU = Helpers.ConvertNullToEmptyString(SKU);
            SmallImageUrl = Helpers.ConvertNullToEmptyString(SmallImageUrl);
            FullImageUrl = Helpers.ConvertNullToEmptyString(FullImageUrl);

            Product product = SqlProductsProvider.UpdateProduct
                (
                ProductID,
                //Title.Trim(),
                ProductTypeID,
                Model.Trim(),
                ShortDescription.Trim(),
                LongDescription.Trim(),
                ManufacturerID,
                SKU.Trim(),
                CurrencyID,
                UnitPrice,
                DiscountPercentage,
                MarginPercentage,
                UnitsInStock,
                SmallImageUrl.Trim(),
                FullImageUrl.Trim(),
                Visible,
                BizObject.CurrentUserName,
                DateTime.Now
                );

            UCCache.RemoveByPattern(PRODUCTS);

            return product;
        }

        public static Product UpdateProductLongDescription
            (
            int ProductID,
            string LongDescription
            )
        {
            LongDescription = Helpers.ConvertNullToEmptyString(LongDescription);

            Product product = SqlProductsProvider.UpdateProductLongDescription
                (
                ProductID,
                LongDescription.Trim()
                );

            UCCache.RemoveByPattern(PRODUCTS);

            return product;
        }

        /// <summary>
        /// Удаление товара
        /// </summary>
        public static void DeleteProduct(int ProductID)
        {
            bool ret = SqlProductsProvider.DeleteProduct(ProductID);

            new RecordDeletedEvent("product", ProductID, null).Raise();

            UCCache.RemoveByPattern(PRODUCTS);
        }























        ///// <summary>
        ///// Sets a product rating
        ///// </summary>
        ///// <param name="ProductID">Product identifer</param>
        ///// <param name="Rating">Rating</param>
        //public static void SetProductRating(int ProductID, int Rating)
        //{
        //    if (NopContext.Current.User == null)
        //        return;

        //    if (Rating < 1 || Rating > 5)
        //        Rating = 1;
        //    ProductDBManager.SetProductRating(ProductID, NopContext.Current.User.CustomerID,
        //        Rating, DateTime.Now);

        //    if (NopContext.IsCachable)
        //    {
        //        string key = string.Format(PRODUCTS_BY_ID_KEY, ProductID);
        //        NopCache.Remove(key);
        //    }
        //}

        ///// <summary>
        ///// Searches products
        ///// </summary>
        ///// <param name="Keywords">Keywords</param>
        ///// <param name="SearchDescriptions">A value indicating whether to search in descriptions</param>
        ///// <param name="PageNumber">Page number</param>
        ///// <param name="PageSize">Page size</param>
        ///// <param name="TotalProducts">Total products found</param>
        ///// <returns>Product collection</returns>
        //public static ProductCollection Search(string Keywords, bool SearchDescriptions,
        //   int PageNumber, int PageSize, out int TotalProducts)
        //{
        //    if (String.IsNullOrEmpty(Keywords))
        //        throw new Exception(LocalizationManager.GetLocaleResourceString("Search.SearchTermCouldNotBeEmpty"));
        //    if (Keywords.Length < 3)
        //        throw new Exception(LocalizationManager.GetLocaleResourceString("Search.SearchTermMinimumLengthIs3Characters"));
        //    if (PageNumber < 1)
        //        PageNumber = 1;
        //    if (PageSize < 1)
        //        PageSize = 20;
        //    bool showHidden = NopContext.Current.IsAdmin;

        //    return ProductDBManager.Search(Keywords, SearchDescriptions,
        //   PageNumber, PageSize, showHidden, out  TotalProducts);
        //}






















        ///***********************************
        //* Static methods
        //************************************/

        ///// <summary>
        ///// Returns a collection with all products
        ///// </summary>
        //public static List<Product> GetProducts(bool onlyVisible)
        //{
        //    return GetProducts("", 0, BizObject.MAXROWS, onlyVisible);
        //}

        ///// <summary>
        ///// Returns a collection with all products for the specified store department
        ///// </summary>
        //public static List<Product> GetProducts(int departmentID, bool onlyVisible)
        //{
        //    return GetProducts(departmentID, 0, "", 0, BizObject.MAXROWS, onlyVisible);
        //}

        //public static List<Product> GetProducts(string sortExpression, int startRowIndex, int maximumRows, bool onlyVisible)
        //{
        //    if (sortExpression == null)
        //        sortExpression = "";

        //    List<Product> products = null;
        //    string key = "Store_Products_" + sortExpression + "_" + startRowIndex.ToString() + "_" + maximumRows.ToString() + "_" + onlyVisible.ToString();

        //    if (BaseStore.Settings.EnableCaching && BizObject.Cache[key] != null)
        //    {
        //        products = (List<Product>)BizObject.Cache[key];
        //    }
        //    else
        //    {
        //        List<ProductDetails> recordset = SiteProvider.Store.GetProducts(
        //           sortExpression, GetPageIndex(startRowIndex, maximumRows), maximumRows, onlyVisible);
        //        products = GetProductListFromProductDetailsList(recordset);
        //        BaseStore.CacheData(key, products);
        //    }
        //    return products;
        //}

        //public static List<Product> GetProducts(string searchWords, string sortExpression, int startRowIndex, int maximumRows)
        //{
        //    List<Product> products = null;
        //    string key = "Store_Products_" + searchWords.Replace(" ", "_").ToUpper() + "_" + sortExpression + "_" +
        //       startRowIndex.ToString() + "_" + maximumRows.ToString();

        //    if (BaseStore.Settings.EnableCaching && BizObject.Cache[key] != null)
        //    {
        //        products = (List<Product>)BizObject.Cache[key];
        //    }
        //    else
        //    {
        //        List<ProductDetails> recordset = SiteProvider.Store.GetProducts(searchWords,
        //           sortExpression, GetPageIndex(startRowIndex, maximumRows), maximumRows);
        //        products = GetProductListFromProductDetailsList(recordset);
        //        BaseStore.CacheData(key, products);
        //    }
        //    return products;
        //}

        ///// <summary>
        ///// Возвращает постранично отсортированный список товаров указанного раздела и производителя
        ///// </summary>
        //public static List<Product> GetProducts(int departmentID, int manufacturerID, string sortExpression, int startRowIndex, int maximumRows, bool onlyVisible)
        //{
        //    List<Product> products = null;
        //    string key = "Store_Products_" + departmentID.ToString() + "_" + manufacturerID.ToString() + "_" + sortExpression + "_" +
        //       startRowIndex.ToString() + "_" + maximumRows.ToString() + "_" + onlyVisible.ToString();

        //    if (BaseStore.Settings.EnableCaching && BizObject.Cache[key] != null)
        //    {
        //        products = (List<Product>)BizObject.Cache[key];
        //    }
        //    else
        //    {
        //        List<ProductDetails> recordset = SiteProvider.Store.GetProducts(departmentID, manufacturerID,
        //           sortExpression, GetPageIndex(startRowIndex, maximumRows), maximumRows, onlyVisible);
        //        products = GetProductListFromProductDetailsList(recordset);
        //        BaseStore.CacheData(key, products);
        //    }
        //    return products;
        //}

        ///// <summary>
        ///// Возвращает постранично отсортированный список товаров указанного раздела и производителя
        ///// </summary>
        //public static List<Product> GetProducts(int departmentID, int manufacturerID, string titleFilter, string sortExpression, int startRowIndex, int maximumRows, bool onlyVisible)
        //{
        //    List<Product> products = null;
        //    string key = "Store_Products_" + departmentID.ToString() + "_" + manufacturerID.ToString() + "_" + titleFilter + "_" + sortExpression + "_" +
        //       startRowIndex.ToString() + "_" + maximumRows.ToString() + "_" + onlyVisible.ToString();

        //    if (BaseStore.Settings.EnableCaching && BizObject.Cache[key] != null)
        //    {
        //        products = (List<Product>)BizObject.Cache[key];
        //    }
        //    else
        //    {
        //        List<ProductDetails> recordset = SiteProvider.Store.GetProducts(departmentID, manufacturerID, titleFilter,
        //           sortExpression, GetPageIndex(startRowIndex, maximumRows), maximumRows, onlyVisible);
        //        products = GetProductListFromProductDetailsList(recordset);
        //        BaseStore.CacheData(key, products);
        //    }
        //    return products;
        //}

        ///// <summary>
        ///// Returns the number of total products
        ///// </summary>
        //public static int GetProductCount(bool onlyVisible)
        //{
        //    int productCount = 0;
        //    string key = "Store_Product_Count" + "_" + onlyVisible.ToString();

        //    if (BaseStore.Settings.EnableCaching && BizObject.Cache[key] != null)
        //    {
        //        productCount = (int)BizObject.Cache[key];
        //    }
        //    else
        //    {
        //        productCount = SiteProvider.Store.GetProductCount(onlyVisible);
        //        BaseStore.CacheData(key, productCount);
        //    }
        //    return productCount;
        //}

        ///// <summary>
        ///// Returns the number of total products for the specified department
        ///// </summary>      
        //public static int GetProductCount(int departmentID, int manufacturerID, bool onlyVisible)
        //{
        //    int productCount = 0;
        //    string key = "Store_Product_Count_" + departmentID.ToString() + "_" + manufacturerID.ToString() + "_" + onlyVisible;

        //    if (BaseStore.Settings.EnableCaching && BizObject.Cache[key] != null)
        //    {
        //        productCount = (int)BizObject.Cache[key];
        //    }
        //    else
        //    {
        //        productCount = SiteProvider.Store.GetProductCount(departmentID, manufacturerID, onlyVisible);
        //        BaseStore.CacheData(key, productCount);
        //    }
        //    return productCount;
        //}

        ///// <summary>
        ///// Returns the number of total products for the specified department
        ///// </summary>      
        //public static int GetProductCount(int departmentID, int manufacturerID, string titleFilter, bool onlyVisible)
        //{
        //    int productCount = 0;
        //    string key = "Store_Product_Count_" + departmentID.ToString() + "_" + manufacturerID.ToString() + "_" + titleFilter + "_" + onlyVisible;

        //    if (BaseStore.Settings.EnableCaching && BizObject.Cache[key] != null)
        //    {
        //        productCount = (int)BizObject.Cache[key];
        //    }
        //    else
        //    {
        //        productCount = SiteProvider.Store.GetProductCount(departmentID, manufacturerID, titleFilter, onlyVisible);
        //        BaseStore.CacheData(key, productCount);
        //    }
        //    return productCount;
        //}

        ///// <summary>
        ///// Возвращает количество товаров найденных по ключевому слову 
        ///// </summary>      
        //public static int GetProductCount(string searchWords)
        //{
        //    int productCount = 0;
        //    string key = "Store_Product_Count_" + searchWords.Replace(" ", "_").ToUpper();

        //    if (BaseStore.Settings.EnableCaching && BizObject.Cache[key] != null)
        //    {
        //        productCount = (int)BizObject.Cache[key];
        //    }
        //    else
        //    {
        //        productCount = SiteProvider.Store.GetProductCount(searchWords);
        //        BaseStore.CacheData(key, productCount);
        //    }
        //    return productCount;
        //}

        ///// <summary>
        ///// Возвращает колиечство товаров со скидкой
        ///// </summary>
        //public static int GetProductCountSales()
        //{
        //    int productCount = 0;
        //    string key = "Store_Product_CountSales";

        //    if (BaseStore.Settings.EnableCaching && BizObject.Cache[key] != null)
        //    {
        //        productCount = (int)BizObject.Cache[key];
        //    }
        //    else
        //    {
        //        productCount = SiteProvider.Store.GetProductCountSales();
        //        BaseStore.CacheData(key, productCount);
        //    }
        //    return productCount;
        //}
    }
}