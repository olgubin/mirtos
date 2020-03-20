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
using UC.DAL;
using UC.BLL.Store;

namespace UC.BLL.Parsing
{
    public class ParsingProduct : BaseParsing
    {
        private int _id = 0;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _linkID = 0;
        public int LinkID
        {
            get { return _linkID; }
            set { _linkID = value; }
        }

        private ParsingProduct _linkProduct = null;
        public ParsingProduct LinkProduct
        {
            get { return _linkProduct; }
            set { _linkProduct = value; }
        }

        private Product _mainProduct = null;
        public Product MainProduct
        {
            get { return _mainProduct; }
            set { _mainProduct = value; }
        }

        private string _url = "";
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private int _catalogID = 0;
        public int CatalogID
        {
            get { return _catalogID; }
            set { _catalogID = value; }
        }

        private DateTime _addedDate = DateTime.Now;
        public DateTime AddedDate
        {
            get { return _addedDate; }
            set { _addedDate = value; }
        }

        private string _departmentTitle = "";
        public string DepartmentTitle
        {
            get { return _departmentTitle; }
            set { _departmentTitle = value; }
        }

        private string _title = "";
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _shortDescription = "";
        public string ShortDescription
        {
            get { return _shortDescription; }
            set { _shortDescription = value; }
        }

        private string _longDescription = "";
        public string LongDescription
        {
            get { return _longDescription; }
            set { _longDescription = value; }
        }

        private string _sku = "";
        public string SKU
        {
            get { return _sku; }
            set { _sku = value; }
        }

        private decimal _unitPrice = 0.0m;
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        private int _discountPercentage = 0;
        public int DiscountPercentage
        {
            get { return _discountPercentage; }
            set { _discountPercentage = value; }
        }

        private int _unitsInStock = 0;
        public int UnitsInStock
        {
            get { return _unitsInStock; }
            set { _unitsInStock = value; }
        }

        private string _smallImageUrl = "";
        public string SmallImageUrl
        {
            get { return _smallImageUrl; }
            set { _smallImageUrl = value; }
        }

        private string _fullImageUrl = "";
        public string FullImageUrl
        {
            get { return _fullImageUrl; }
            set { _fullImageUrl = value; }
        }

        private int _totalRating = 0;
        public int TotalRating
        {
            get { return _totalRating; }
            set { _totalRating = value; }
        }

        private bool _isNew = false;
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }

        private bool _isDeleted = false;
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }

        private bool _isUpdated = false;
        public bool IsUpdated
        {
            get { return _isUpdated; }
            set { _isUpdated = value; }
        }

        private bool _isRestored = false;
        public bool IsRestored
        {
            get { return _isRestored; }
            set { _isRestored = value; }
        }

        private string _error = "";
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public ParsingProduct(int id, int linkID, string url, int catalogID, DateTime addedDate,
           string departmentTitle, string title, string shortDescription, string longDescription,
           string sku, decimal unitPrice, int discountPercentage, int unitsInStock,
           string smallImageUrl, string fullImageUrl, int totalRating,
           bool isNew, bool isUpdated, bool isDeleted, bool isRestored, string error)
        {
            this.ID = id;  //идентификатор товара в БД каталога, для обновленного товара он равен 0 устанавливается при сравнении на идентификатор товара из каталога
            this.LinkID = linkID; //идентификатор связанного товара из нашей БД
            this.Url = url;
            this.CatalogID = catalogID;
            this.AddedDate = addedDate;
            this.DepartmentTitle = departmentTitle;
            this.Title = title;
            this.ShortDescription = shortDescription;
            this.LongDescription = longDescription;
            this.SKU = sku;
            this.UnitPrice = unitPrice;
            this.DiscountPercentage = discountPercentage;
            this.UnitsInStock = unitsInStock;
            this.SmallImageUrl = smallImageUrl;
            this.FullImageUrl = fullImageUrl;
            this.TotalRating = totalRating;
            this.IsNew = isNew;
            this.IsDeleted = isDeleted;
            this.IsUpdated = isUpdated;
            this.IsRestored = isRestored;
            this.Error = error;
        }

        public bool Delete()
        {
            bool success = ParsingProduct.DeleteProduct(this.ID);
            if (success)
                this.ID = 0;
            return success;
        }

        public bool Update()
        {
            return ParsingProduct.UpdateProduct(this.ID, this.LinkID, this.Url, this.CatalogID, this.DepartmentTitle, this.Title,
                this.ShortDescription, this.LongDescription, this.SKU, this.UnitPrice, this.DiscountPercentage, this.UnitsInStock,
                this.SmallImageUrl, this.FullImageUrl, this.TotalRating, this.IsNew, this.IsUpdated, this.IsDeleted, this.IsRestored, this.Error);
        }

        public int Insert()
        {
            return ParsingProduct.InsertProduct(this.LinkID, this.Url, this.CatalogID, this.DepartmentTitle, this.Title,
                this.ShortDescription, this.LongDescription, this.SKU, this.UnitPrice, this.DiscountPercentage, this.UnitsInStock,
                this.SmallImageUrl, this.FullImageUrl, this.TotalRating, this.IsNew, this.IsUpdated, this.IsDeleted, this.IsRestored, this.Error);
        }

        /// <summary>
        /// Сравнивает товар с товаром переданным в качестве параметра
        /// </summary>
        public bool CompareTo(ParsingProduct product)
        {
            bool result = true;

            if (this.Title != product.Title)
                result = false;

            if (this.Url != product.Url)
                result = false;

            if (this.UnitPrice != product.UnitPrice)
                result = false;

            if (this.ShortDescription != product.ShortDescription)
                result = false;

            if (this.LongDescription != product.LongDescription)
                result = false;

            if (this.DepartmentTitle != product.DepartmentTitle)
                result = false;

            if (this.DiscountPercentage != product.DiscountPercentage)
                result = false;

            if (this.FullImageUrl != product.FullImageUrl)
                result = false;

            if (this.SmallImageUrl != product.SmallImageUrl)
                result = false;

            if (this.TotalRating != product.TotalRating)
                result = false;

            if (this.UnitsInStock != product.UnitsInStock)
                result = false;

            if (this.Error != product.Error)
                result = false;

            return result;
        }

        /***********************************
        * Статические методы
        ************************************/

        /// <summary>
        /// Обновляет каталог
        /// </summary>
        public static void PurgeCache(string providerType)
        {
            BizObject.PurgeCacheItems("parsing_refreshproduct");
            BizObject.PurgeCacheItems("parsing_product");
        }

        /// <summary>
        /// Обновляет каталог
        /// </summary>
        public static void PurgeCache()
        {
            BizObject.PurgeCacheItems("parsing_product");
        }

        /******* Количество товаров *******/

        /// <summary>
        /// Возвращает количество товаров для определенного каталога хранящееся в БД в требуемом представлении
        /// </summary>      
        public static int GetProductCount(int catalogID, int view)
        {
            int productCount = 0;
            string key = "Parsing_ProductCount_" + catalogID.ToString() + "_" + view;

            if (BaseParsing.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                productCount = (int)BizObject.Cache[key];
            }
            else
            {
                productCount = SiteProvider.Parsing.GetProductCount(catalogID, view);
                BaseParsing.CacheData(key, productCount);
            }
            return productCount;
        }

        /// <summary>
        /// Возвращает количество товаров для определенного каталога полученное с сайта каталога
        /// </summary>      
        public static int GetProductCount(int catalogID, string providerType)
        {
            int productCount = 0;
            string key = "Parsing_RefreshProductCount_" + providerType;

            if (BaseParsing.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                productCount = (int)BizObject.Cache[key];
            }
            else
            {
                List<ParsingProduct> products = GetProducts(catalogID, providerType);
                productCount = products.Count;
                BaseParsing.CacheData(key, productCount);
            }
            return productCount;
        }

        /******* Коллекция товаров *******/

        /// <summary>
        /// Возвращает коллекцию всех продуктов указанного каталога
        /// </summary>
        public static List<ParsingProduct> GetProducts(int catalogID)
        {
            return GetProducts(catalogID, "", 0, BizObject.MAXROWS, 0);
        }

        /// <summary>
        /// Возвращает коллекцию указанного количества продуктов указанного каталога отсортированных
        /// в соответствии с указанным фильтром
        /// </summary>
        public static List<ParsingProduct> GetProducts(int catalogID, string sortExpression, int startRowIndex, int maximumRows, int view)
        {
            List<ParsingProduct> products = null;
            string key = "Parsing_Products_" + catalogID.ToString() + "_" + sortExpression + "_" +
               startRowIndex.ToString() + "_" + maximumRows.ToString() + "_" + view;

            if (BaseParsing.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                products = (List<ParsingProduct>)BizObject.Cache[key];
            }
            else
            {
                List<ParsingProductDetails> recordset = SiteProvider.Parsing.GetProducts(catalogID,
                   sortExpression, GetPageIndex(startRowIndex, maximumRows), maximumRows, view);
                products = GetParsingProductListFromParsingProductDetailsList(recordset);

                BaseParsing.CacheData(key, products);
            }

            //находим все связанные товары и линкуем их
            List<Product> mainProducts = ProductManager.GetAllProducts(false);

            foreach (ParsingProduct product in products)
            {
                //..ищем соответствие нашему товару в базе
                int index = mainProducts.FindIndex(delegate(Product mainProduct) { return (mainProduct.ProductID == product.LinkID); });

                if (index >= 0)
                {
                    product.MainProduct = mainProducts[index];
                }
            }

            return products;
        }

        /// <summary>
        /// Возвращает коллекцию всех продуктов указанного каталога загруженных из каталога
        /// </summary>
        public static List<ParsingProduct> GetProducts(int catalogID, string providerType)
        {
            return GetProducts(catalogID, providerType, "", 0, BizObject.MAXROWS);
        }

        /// <summary>
        /// Возвращает коллекцию указанного количества продуктов указанного каталога загруженных из каталога
        /// </summary>
        public static List<ParsingProduct> GetProducts(int catalogID, string providerType, string sortExpression, int startRowIndex, int maximumRows)
        {
            List<ParsingProduct> products = null;
            string key = "Parsing_RefreshProducts_" + providerType;

            if (BaseParsing.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                products = (List<ParsingProduct>)BizObject.Cache[key];
            }
            else
            {
                List<ParsingProductDetails> recordset = SiteProvider.ParsingSite(providerType).GetProducts(catalogID);
                products = GetParsingProductListFromParsingProductDetailsList(recordset);

                //поиск соответствующих товаров в базе, установление соответствия
                products = ParsingProduct.CompareProducts(products, catalogID);

                BaseParsing.CacheData(key, products);
            }

            //из основного списка товаров формируем список товаров, соответствующий требуемой странице
            List<ParsingProduct> result = new List<ParsingProduct>();

            for (int i = startRowIndex; i < (startRowIndex + maximumRows); i++)
            {
                if (i >= products.Count) { break; }
                result.Add(products[i]);
            }

            return result;
        }

        /// <summary>
        /// Возвращает товар из БД каталога по его ID
        /// </summary>
        public static ParsingProduct GetProductByID(int catalogID, int productID)
        {
            ParsingProduct product = null;
            string key = "Parsing_Product_" + catalogID.ToString() + "_" + productID.ToString();

            if (BaseParsing.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                product = (ParsingProduct)BizObject.Cache[key];
            }
            else
            {
                product = GetParsingProductFromParsingProductDetails(SiteProvider.Parsing.GetProductByID(catalogID, productID));
                BaseParsing.CacheData(key, product);
            }

            return product;
        }

        /// <summary>
        /// Возвращает товар из БД каталога по его ID
        /// </summary>
        public static ParsingProduct GetProductByID(int catalogID, int productID, string providerType)
        {
            ParsingProduct product = new ParsingProduct(0, 0, "", 0, DateTime.Now, "", "", "", "", "", 0.0m, 0, 0, "", "", 0, false, false, false, false, "");

            string key = "Parsing_Product_" + providerType + "_" + productID.ToString();

            if (BaseParsing.Settings.EnableCaching && BizObject.Cache[key] != null)
            {
                product = (ParsingProduct)BizObject.Cache[key];
            }
            else
            {
                //получаем список товаров каталога
                List<ParsingProduct> products = GetProducts(catalogID, providerType);

                //ищем в списке нужный товар
                //int index = products.BinarySearch(product);
                //products.Contains(
                int index = products.FindIndex(delegate(ParsingProduct item) { return (item.ID == productID); });

                if (index >= 0)
                {
                    product = products[index];
                }

                BaseParsing.CacheData(key, product);
            }
            return product;
        }

        /// <summary>
        /// Сравнивает каталоги старый и обновленный и формирует общий список товаров
        /// </summary>
        public static List<ParsingProduct> CompareProducts(List<ParsingProduct> products, int catalogID)
        {
            //здесь ищем товар из каталога, если находим, то добавляем его 
            List<ParsingProduct> oldProducts = ParsingProduct.GetProducts(catalogID);

            foreach (ParsingProduct product in products)
            {
                //..ищем соответствие товару в базе
                int index = oldProducts.FindIndex(delegate(ParsingProduct oldProduct) { return (oldProduct.SKU == product.SKU); });

                if (index >= 0)
                {
                    product.LinkID = oldProducts[index].LinkID;
                    product.LinkProduct = oldProducts[index];

                    //..сравниваем товар, если не изменился, то оставляем все как есть
                    //..если изменен, то указываем признак isUpdated.
                    //..удаляем старый товар из списка
                    if (!product.CompareTo(oldProducts[index]))
                    {
                        //..если товар изменился
                        product.IsUpdated = true;
                    }

                    //..если товар был удален, то устанавливаем признак восстановлен isRestored
                    if (oldProducts[index].IsDeleted)
                    {
                        product.IsRestored = true;
                    }

                    oldProducts.RemoveAt(index);
                }
                else
                {
                    //..добавляем новый товар isNew
                    product.IsNew = true;
                }
            }

            //..для всех оставшихся в старом списке товаров добавляем в общий список и устанавливаем признак удален isDeleted
            foreach (ParsingProduct item in oldProducts)
            {
                ParsingProduct deletedProduct = new ParsingProduct(products.Count, 0, "", 0, DateTime.Now, "", "", "", "", "", 0.0m, 0, 0, "", "", 0, false, false, true, false, "");

                deletedProduct.LinkProduct = item;

                products.Add(deletedProduct);
            }

            return products;
        }

        /// <summary>
        /// Обновляет все товары в БД каталога
        /// </summary>
        public static bool UpdateProductsAll(int catalogID, string providerType)
        {
            //Если найдены связанные товары и они изменены, то обновляем, если новые, то добавляем
            //..получаем список товаров с сайта каталога

            List<ParsingProduct> products = ParsingProduct.GetProducts(catalogID, providerType);

            foreach (ParsingProduct product in products)
            {
                //...если новый добавляем
                if (product.IsNew)
                {
                    product.Insert();
                }

                //..если изменен обновляем
                if (product.IsUpdated)
                {
                    product.ID = product.LinkProduct.ID;
                    product.Update();
                }

                if (!product.IsNew & !product.IsUpdated)
                {
                    ParsingProduct.NoneUpdatedProduct(product.LinkProduct.ID);
                }


                //..если удален обновляем
                if (product.IsDeleted)
                {
                    ParsingProduct.DeletedProduct(product.LinkProduct.ID);
                }

                //..если восставновлен обновляем
                if (product.IsRestored)
                {
                    ParsingProduct.RestoredProduct(product.LinkProduct.ID);
                }
            }

            ParsingCatalog.RefreshCatalog(catalogID);

            return true;
        }

        /// <summary>
        /// Обновляет цены всех связанных товаров
        /// </summary>
        public static bool ChangeUnitPriceProductsAll(int catalogID)
        {
            List<ParsingProduct> products = ParsingProduct.GetProducts(catalogID);

            try
            {
                foreach (ParsingProduct product in products)
                {
                    if (product.LinkID != 0)
                        ProductManager.ChangeUnitPriceProduct(product.LinkID, product.UnitPrice);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Обновляет товар в БД каталога
        /// </summary>
        public static bool UpdateProduct(int id, int linkID, string url, int catalogID,
           string departmentTitle, string title, string shortDescription, string longDescription,
           string sku, decimal unitPrice, int discountPercentage, int unitsInStock,
           string smallImageUrl, string fullImageUrl, int totalRating,
           bool isNew, bool isUpdated, bool isDeleted, bool isRestored, string error)
        {
            url = BizObject.ConvertNullToEmptyString(url);
            departmentTitle = BizObject.ConvertNullToEmptyString(departmentTitle);
            title = BizObject.ConvertNullToEmptyString(title);
            shortDescription = BizObject.ConvertNullToEmptyString(shortDescription);
            longDescription = BizObject.ConvertNullToEmptyString(longDescription);
            sku = BizObject.ConvertNullToEmptyString(sku);
            smallImageUrl = BizObject.ConvertNullToEmptyString(smallImageUrl);
            fullImageUrl = BizObject.ConvertNullToEmptyString(fullImageUrl);
            error = BizObject.ConvertNullToEmptyString(error);

            ParsingProductDetails record = new ParsingProductDetails(id, linkID, url, catalogID, DateTime.Now, departmentTitle, title,
               shortDescription, longDescription, sku, unitPrice, discountPercentage, unitsInStock,
               smallImageUrl, fullImageUrl, totalRating, isNew, isUpdated, isDeleted, isRestored, error);

            bool ret = SiteProvider.Parsing.UpdateProduct(record);

            BizObject.PurgeCacheItems("parsing_product_" + id.ToString());
            BizObject.PurgeCacheItems("parsing_products");
            return ret;
        }

        /// <summary>
        /// Добавляет новый товар в БД каталога
        /// </summary>
        public static int InsertProduct(int linkID, string url, int catalogID,
           string departmentTitle, string title, string shortDescription, string longDescription,
           string sku, decimal unitPrice, int discountPercentage, int unitsInStock,
           string smallImageUrl, string fullImageUrl, int totalRating,
           bool isNew, bool isUpdated, bool isDeleted, bool isRestored, string error)
        {
            url = BizObject.ConvertNullToEmptyString(url);
            departmentTitle = BizObject.ConvertNullToEmptyString(departmentTitle);
            title = BizObject.ConvertNullToEmptyString(title);
            shortDescription = BizObject.ConvertNullToEmptyString(shortDescription);
            longDescription = BizObject.ConvertNullToEmptyString(longDescription);
            sku = BizObject.ConvertNullToEmptyString(sku);
            smallImageUrl = BizObject.ConvertNullToEmptyString(smallImageUrl);
            fullImageUrl = BizObject.ConvertNullToEmptyString(fullImageUrl);
            error = BizObject.ConvertNullToEmptyString(error);

            ParsingProductDetails record = new ParsingProductDetails(0, linkID, url, catalogID, DateTime.Now, departmentTitle, title,
               shortDescription, longDescription, sku, unitPrice, discountPercentage, unitsInStock,
               smallImageUrl, fullImageUrl, totalRating, isNew, isUpdated, isDeleted, isRestored, error);

            int ret = SiteProvider.Parsing.InsertProduct(record);

            BizObject.PurgeCacheItems("parsing_product");
            return ret;
        }

        /// <summary>
        /// Удаляет товар из БД каталога
        /// </summary>
        public static bool DeleteProduct(int id)
        {
            bool ret = SiteProvider.Parsing.DeleteProduct(id);
            new RecordDeletedEvent("product", id, null).Raise();
            BizObject.PurgeCacheItems("parsing_product");
            return ret;
        }

        /// <summary>
        /// Добавление к товару свойства IsDeleted
        /// </summary>
        public static bool DeletedProduct(int id)
        {
            bool ret = SiteProvider.Parsing.IsDeleted(id);
            BizObject.PurgeCacheItems("parsing_product_" + id.ToString());
            BizObject.PurgeCacheItems("parsing_products");
            return ret;
        }

        /// <summary>
        /// Добавление к товару свойства IsRestored
        /// </summary>
        public static bool RestoredProduct(int id)
        {
            bool ret = SiteProvider.Parsing.IsRestored(id);
            BizObject.PurgeCacheItems("parsing_product_" + id.ToString());
            BizObject.PurgeCacheItems("parsing_products");
            return ret;
        }

        /// <summary>
        /// Снятие всех флагов если товар не изменялся
        /// </summary>
        public static bool NoneUpdatedProduct(int id)
        {
            bool ret = SiteProvider.Parsing.IsNoneUpdated(id);
            BizObject.PurgeCacheItems("parsing_product_" + id.ToString());
            BizObject.PurgeCacheItems("parsing_products");
            return ret;
        }





        /// <summary>
        /// Возвращет объект ParsingProduct заполненный данными из объекта ParsingProductDetails
        /// </summary>
        private static ParsingProduct GetParsingProductFromParsingProductDetails(ParsingProductDetails record)
        {
            if (record == null)
                return null;
            else
            {
                return new ParsingProduct(record.ID, record.LinkID, record.Url,
                   record.CatalogID, record.AddedDate, record.DepartmentTitle, record.Title,
                   record.ShortDescription, record.LongDescription, record.SKU, record.UnitPrice,
                   record.DiscountPercentage, record.UnitsInStock, record.SmallImageUrl, record.FullImageUrl, record.TotalRating,
                   record.IsNew, record.IsUpdated, record.IsDeleted, record.IsRestored, record.Error);
            }
        }

        /// <summary>
        /// Возвращает список объектов ParsingProduct заполненный данными из списка объектов ParsingProductDetails
        /// </summary>
        private static List<ParsingProduct> GetParsingProductListFromParsingProductDetailsList(List<ParsingProductDetails> recordset)
        {
            List<ParsingProduct> products = new List<ParsingProduct>();
            foreach (ParsingProductDetails record in recordset)
                products.Add(GetParsingProductFromParsingProductDetails(record));
            return products;
        }
    }
}