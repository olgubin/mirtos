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
            this.ID = id;  //������������� ������ � �� ��������, ��� ������������ ������ �� ����� 0 ��������������� ��� ��������� �� ������������� ������ �� ��������
            this.LinkID = linkID; //������������� ���������� ������ �� ����� ��
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
        /// ���������� ����� � ������� ���������� � �������� ���������
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
        * ����������� ������
        ************************************/

        /// <summary>
        /// ��������� �������
        /// </summary>
        public static void PurgeCache(string providerType)
        {
            BizObject.PurgeCacheItems("parsing_refreshproduct");
            BizObject.PurgeCacheItems("parsing_product");
        }

        /// <summary>
        /// ��������� �������
        /// </summary>
        public static void PurgeCache()
        {
            BizObject.PurgeCacheItems("parsing_product");
        }

        /******* ���������� ������� *******/

        /// <summary>
        /// ���������� ���������� ������� ��� ������������� �������� ���������� � �� � ��������� �������������
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
        /// ���������� ���������� ������� ��� ������������� �������� ���������� � ����� ��������
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

        /******* ��������� ������� *******/

        /// <summary>
        /// ���������� ��������� ���� ��������� ���������� ��������
        /// </summary>
        public static List<ParsingProduct> GetProducts(int catalogID)
        {
            return GetProducts(catalogID, "", 0, BizObject.MAXROWS, 0);
        }

        /// <summary>
        /// ���������� ��������� ���������� ���������� ��������� ���������� �������� ���������������
        /// � ������������ � ��������� ��������
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

            //������� ��� ��������� ������ � ������� ��
            List<Product> mainProducts = ProductManager.GetAllProducts(false);

            foreach (ParsingProduct product in products)
            {
                //..���� ������������ ������ ������ � ����
                int index = mainProducts.FindIndex(delegate(Product mainProduct) { return (mainProduct.ProductID == product.LinkID); });

                if (index >= 0)
                {
                    product.MainProduct = mainProducts[index];
                }
            }

            return products;
        }

        /// <summary>
        /// ���������� ��������� ���� ��������� ���������� �������� ����������� �� ��������
        /// </summary>
        public static List<ParsingProduct> GetProducts(int catalogID, string providerType)
        {
            return GetProducts(catalogID, providerType, "", 0, BizObject.MAXROWS);
        }

        /// <summary>
        /// ���������� ��������� ���������� ���������� ��������� ���������� �������� ����������� �� ��������
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

                //����� ��������������� ������� � ����, ������������ ������������
                products = ParsingProduct.CompareProducts(products, catalogID);

                BaseParsing.CacheData(key, products);
            }

            //�� ��������� ������ ������� ��������� ������ �������, ��������������� ��������� ��������
            List<ParsingProduct> result = new List<ParsingProduct>();

            for (int i = startRowIndex; i < (startRowIndex + maximumRows); i++)
            {
                if (i >= products.Count) { break; }
                result.Add(products[i]);
            }

            return result;
        }

        /// <summary>
        /// ���������� ����� �� �� �������� �� ��� ID
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
        /// ���������� ����� �� �� �������� �� ��� ID
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
                //�������� ������ ������� ��������
                List<ParsingProduct> products = GetProducts(catalogID, providerType);

                //���� � ������ ������ �����
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
        /// ���������� �������� ������ � ����������� � ��������� ����� ������ �������
        /// </summary>
        public static List<ParsingProduct> CompareProducts(List<ParsingProduct> products, int catalogID)
        {
            //����� ���� ����� �� ��������, ���� �������, �� ��������� ��� 
            List<ParsingProduct> oldProducts = ParsingProduct.GetProducts(catalogID);

            foreach (ParsingProduct product in products)
            {
                //..���� ������������ ������ � ����
                int index = oldProducts.FindIndex(delegate(ParsingProduct oldProduct) { return (oldProduct.SKU == product.SKU); });

                if (index >= 0)
                {
                    product.LinkID = oldProducts[index].LinkID;
                    product.LinkProduct = oldProducts[index];

                    //..���������� �����, ���� �� ���������, �� ��������� ��� ��� ����
                    //..���� �������, �� ��������� ������� isUpdated.
                    //..������� ������ ����� �� ������
                    if (!product.CompareTo(oldProducts[index]))
                    {
                        //..���� ����� ���������
                        product.IsUpdated = true;
                    }

                    //..���� ����� ��� ������, �� ������������� ������� ������������ isRestored
                    if (oldProducts[index].IsDeleted)
                    {
                        product.IsRestored = true;
                    }

                    oldProducts.RemoveAt(index);
                }
                else
                {
                    //..��������� ����� ����� isNew
                    product.IsNew = true;
                }
            }

            //..��� ���� ���������� � ������ ������ ������� ��������� � ����� ������ � ������������� ������� ������ isDeleted
            foreach (ParsingProduct item in oldProducts)
            {
                ParsingProduct deletedProduct = new ParsingProduct(products.Count, 0, "", 0, DateTime.Now, "", "", "", "", "", 0.0m, 0, 0, "", "", 0, false, false, true, false, "");

                deletedProduct.LinkProduct = item;

                products.Add(deletedProduct);
            }

            return products;
        }

        /// <summary>
        /// ��������� ��� ������ � �� ��������
        /// </summary>
        public static bool UpdateProductsAll(int catalogID, string providerType)
        {
            //���� ������� ��������� ������ � ��� ��������, �� ���������, ���� �����, �� ���������
            //..�������� ������ ������� � ����� ��������

            List<ParsingProduct> products = ParsingProduct.GetProducts(catalogID, providerType);

            foreach (ParsingProduct product in products)
            {
                //...���� ����� ���������
                if (product.IsNew)
                {
                    product.Insert();
                }

                //..���� ������� ���������
                if (product.IsUpdated)
                {
                    product.ID = product.LinkProduct.ID;
                    product.Update();
                }

                if (!product.IsNew & !product.IsUpdated)
                {
                    ParsingProduct.NoneUpdatedProduct(product.LinkProduct.ID);
                }


                //..���� ������ ���������
                if (product.IsDeleted)
                {
                    ParsingProduct.DeletedProduct(product.LinkProduct.ID);
                }

                //..���� ������������� ���������
                if (product.IsRestored)
                {
                    ParsingProduct.RestoredProduct(product.LinkProduct.ID);
                }
            }

            ParsingCatalog.RefreshCatalog(catalogID);

            return true;
        }

        /// <summary>
        /// ��������� ���� ���� ��������� �������
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
        /// ��������� ����� � �� ��������
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
        /// ��������� ����� ����� � �� ��������
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
        /// ������� ����� �� �� ��������
        /// </summary>
        public static bool DeleteProduct(int id)
        {
            bool ret = SiteProvider.Parsing.DeleteProduct(id);
            new RecordDeletedEvent("product", id, null).Raise();
            BizObject.PurgeCacheItems("parsing_product");
            return ret;
        }

        /// <summary>
        /// ���������� � ������ �������� IsDeleted
        /// </summary>
        public static bool DeletedProduct(int id)
        {
            bool ret = SiteProvider.Parsing.IsDeleted(id);
            BizObject.PurgeCacheItems("parsing_product_" + id.ToString());
            BizObject.PurgeCacheItems("parsing_products");
            return ret;
        }

        /// <summary>
        /// ���������� � ������ �������� IsRestored
        /// </summary>
        public static bool RestoredProduct(int id)
        {
            bool ret = SiteProvider.Parsing.IsRestored(id);
            BizObject.PurgeCacheItems("parsing_product_" + id.ToString());
            BizObject.PurgeCacheItems("parsing_products");
            return ret;
        }

        /// <summary>
        /// ������ ���� ������ ���� ����� �� ���������
        /// </summary>
        public static bool NoneUpdatedProduct(int id)
        {
            bool ret = SiteProvider.Parsing.IsNoneUpdated(id);
            BizObject.PurgeCacheItems("parsing_product_" + id.ToString());
            BizObject.PurgeCacheItems("parsing_products");
            return ret;
        }





        /// <summary>
        /// ��������� ������ ParsingProduct ����������� ������� �� ������� ParsingProductDetails
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
        /// ���������� ������ �������� ParsingProduct ����������� ������� �� ������ �������� ParsingProductDetails
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