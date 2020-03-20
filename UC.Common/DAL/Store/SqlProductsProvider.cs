using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using UC.BLL.Store;

namespace UC.DAL.Store
{
    internal class SqlProductsProvider: DataAccess
    {
        public static ProductCollection GetAllProducts(bool visible)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductGet", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Visible", SqlDbType.Bit).Value = visible;
                cn.Open();
                return GetProductCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static ProductCollection GetByManufacturerID(int manufacturerID, bool visible)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductGetByManufacturerID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = manufacturerID;
                cmd.Parameters.Add("@Visible", SqlDbType.Bit).Value = visible;
                cn.Open();
                return GetProductCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static ProductCollection GetSearch(string searchWords)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductsGetSearch", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@searchWords", SqlDbType.NVarChar).Value = searchWords;
                cn.Open();
                return GetProductCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static Product GetByProductID(int ProductID)
        {
            if (ProductID == 0)
                return null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductGetByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetProductFromReader(reader);
                else
                    return null;
            }
        }

        /// <summary>
        /// ѕолучает все товары со скидкой
        /// </summary>
        public static ProductCollection GetProductsSales()
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductGetSales", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetProductCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// ¬озвращает количество товаров содержащих картинку
        /// </summary>
        public static int GetProductCountByImageUrl(string imageUrl)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductGetCountByImageUrl", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = imageUrl;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// ¬озвращает полное описание товара
        /// </summary>
        public static string GetProductLongDescription(int productID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductGetLongDescription", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cn.Open();
                return (string)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// »зменение цены на единицу товара
        /// </summary>
        public static bool ChangeUnitPriceProduct(int productID, decimal unitPrice)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductChangeUnitPrice", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cmd.Parameters.Add("@unitPrice", SqlDbType.Money).Value = unitPrice;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// »зменение цены и скидки на товар
        /// </summary>
        public static bool ChangeUnitPriceAndDiscountPercentage(int productID, decimal unitPrice, int discountPercentage, int marginPercentage)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductChangeUnitPriceAndDiscountPercentage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cmd.Parameters.Add("@unitPrice", SqlDbType.Money).Value = unitPrice;
                cmd.Parameters.Add("@discountPercentage", SqlDbType.Money).Value = discountPercentage;
                cmd.Parameters.Add("@marginPercentage", SqlDbType.Money).Value = marginPercentage;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// »зменение артикул товара
        /// </summary>
        public static bool ChangeSKU(int productID, string sku)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductChangeSKU", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cmd.Parameters.Add("@SKU", SqlDbType.NVarChar).Value = sku;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Inserts a vote for the specified product
        /// </summary>
        public static bool RateProduct(int productID, int rating)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductInsertVote", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cmd.Parameters.Add("@Rating", SqlDbType.Int).Value = rating;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// »змен€ет видимость товара
        /// </summary>
        public static bool ChangeVisible(int productID, bool visible)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductChangeVisible", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cmd.Parameters.Add("@Visible", SqlDbType.Bit).Value = visible;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// »зменение цены на единицу товара
        /// </summary>
        public static bool ChangeImageUrl(int productID, string smallImageUrl, string fullImageUrl)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductChangeImageUrl", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cmd.Parameters.Add("@smallImageUrl", SqlDbType.NVarChar).Value = smallImageUrl;
                cmd.Parameters.Add("@fullImageUrl", SqlDbType.NVarChar).Value = fullImageUrl;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Ќазначение производител€ товару
        /// </summary>
        public static bool AssignProductManufacturer(int productID, int manufacturerID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductAssignManufacturer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = manufacturerID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Ќазначение валюты товару
        /// </summary>
        public static bool AssignProductCurrency(int productID, int currencyID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductAssignCurrency", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cmd.Parameters.Add("@CurrencyID", SqlDbType.Int).Value = currencyID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// ”меньшает количество товара
        /// </summary>
        public static bool DecrementProductUnitsInStock(int productID, int quantity)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductDecrementUnitsInStock", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

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
            bool Visible,
            string AddedBy,
            DateTime AddedDate
            )
        {
            Product product = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Title;
                cmd.Parameters.Add("@ProductTypeID", SqlDbType.Int).Value = ProductTypeID;
                cmd.Parameters.Add("@Model", SqlDbType.NVarChar).Value = Model;
                cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar).Value = ShortDescription;
                cmd.Parameters.Add("@LongDescription", SqlDbType.NVarChar).Value = LongDescription;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = ManufacturerID;
                cmd.Parameters.Add("@SKU", SqlDbType.NVarChar).Value = SKU;
                cmd.Parameters.Add("@CurrencyID", SqlDbType.Int).Value = CurrencyID;
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = UnitPrice;
                cmd.Parameters.Add("@DiscountPercentage", SqlDbType.Int).Value = DiscountPercentage;
                cmd.Parameters.Add("@MarginPercentage", SqlDbType.Int).Value = MarginPercentage;
                cmd.Parameters.Add("@UnitsInStock", SqlDbType.Int).Value = UnitsInStock;
                cmd.Parameters.Add("@SmallImageUrl", SqlDbType.NVarChar).Value = SmallImageUrl;
                cmd.Parameters.Add("@FullImageUrl", SqlDbType.NVarChar).Value = FullImageUrl;
                cmd.Parameters.Add("@Visible", SqlDbType.Bit).Value = Visible;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = AddedBy;
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = AddedDate;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                if (ret > 0)
                {
                    int ProductID = (int)cmd.Parameters["@ProductID"].Value;
                    product = GetByProductID(ProductID);
                }
                return product;
            }
        }

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
            bool Visible,
            string AddedBy,
            DateTime AddedDate
            )
        {
            Product product = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value= ProductID;
                //cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Title;
                cmd.Parameters.Add("@ProductTypeID", SqlDbType.Int).Value = ProductTypeID;
                cmd.Parameters.Add("@Model", SqlDbType.NVarChar).Value = Model;
                cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar).Value = ShortDescription;
                cmd.Parameters.Add("@LongDescription", SqlDbType.NVarChar).Value = LongDescription;
                cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = ManufacturerID;
                cmd.Parameters.Add("@SKU", SqlDbType.NVarChar).Value = SKU;
                cmd.Parameters.Add("@CurrencyID", SqlDbType.Int).Value = CurrencyID;
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = UnitPrice;
                cmd.Parameters.Add("@DiscountPercentage", SqlDbType.Int).Value = DiscountPercentage;
                cmd.Parameters.Add("@MarginPercentage", SqlDbType.Int).Value = MarginPercentage;
                cmd.Parameters.Add("@UnitsInStock", SqlDbType.Int).Value = UnitsInStock;
                cmd.Parameters.Add("@SmallImageUrl", SqlDbType.NVarChar).Value = SmallImageUrl;
                cmd.Parameters.Add("@FullImageUrl", SqlDbType.NVarChar).Value = FullImageUrl;
                cmd.Parameters.Add("@Visible", SqlDbType.NVarChar).Value = Visible;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = AddedBy;
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = AddedDate;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    product = GetByProductID(ProductID);

                return product;
            }
        }

        public static Product UpdateProductLongDescription
            (
            int ProductID,
            string LongDescription
            )
        {
            Product product = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductUpdateLongDescription", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                cmd.Parameters.Add("@LongDescription", SqlDbType.NVarChar).Value = LongDescription;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                if (ret > 0)
                    product = GetByProductID(ProductID);

                return product;
            }
        }

        public static bool DeleteProduct(int ProductID)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// ¬озвращает коллекцию товаров из ридера
        /// </summary>
        public static ProductCollection GetProductCollectionFromReader(IDataReader reader)
        {
            ProductCollection productCollection = new ProductCollection();

            while (reader.Read())
                productCollection.Add(GetProductFromReader(reader));

            return productCollection;
        }

        /// <summary>
        /// ¬озвращает товар из текущей записи ридера
        /// </summary>
        public static Product GetProductFromReader(IDataReader reader)
        {
            Product product = new Product();
            product.ProductID = GetInt(reader, "ProductID");
            //product.Title = GetString(reader, "Title");
            product.ProductTypeID = GetInt(reader, "ProductTypeID");
            product.Model = GetString(reader, "Model");
            product.ShortDescription = GetString(reader, "ShortDescription");
            product.ManufacturerID = GetInt(reader, "ManufacturerID");
            product.SKU = GetString(reader, "SKU");
            product.CurrencyID = GetInt(reader, "CurrencyID");
            product.UnitPrice = GetDecimal(reader, "UnitPrice");
            product.DiscountPercentage = GetInt(reader, "DiscountPercentage");
            product.MarginPercentage = GetInt(reader, "MarginPercentage");
            product.UnitsInStock = GetInt(reader, "UnitsInStock");
            product.SmallImageUrl = GetString(reader, "SmallImageUrl");
            product.FullImageUrl = GetString(reader, "FullImageUrl");
            product.Votes = GetInt(reader, "Votes");
            product.TotalRating = GetInt(reader, "TotalRating");
            product.Visible = GetBoolean(reader, "Visible");
            product.AddedBy = GetString(reader, "AddedBy");
            product.AddedDate = GetDateTime(reader, "AddedDate");

            return product;
        }





























        ///// <summary>
        ///// Retrieves all products
        ///// </summary>
        //public override List<ProductDetails> GetProducts(string sortExpression, int pageIndex, int pageSize, bool onlyVisible)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("sh_Store_GetProducts", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        sortExpression = EnsureValidProductsSortExpression(sortExpression);
        //        int lowerBound = pageIndex * pageSize + 1;
        //        int upperBound = (pageIndex + 1) * pageSize;
        //        cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
        //        cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
        //        cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
        //        cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = onlyVisible;
        //        cn.Open();
        //        return GetProductCollectionFromReader(ExecuteReader(cmd), false);
        //    }
        //}

        ///// <summary>
        ///// ѕолучает все продукты найденные по поисковому запросу
        ///// </summary>
        //public override List<ProductDetails> GetProducts(string searchWords, string sortExpression, int pageIndex, int pageSize)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("tbh_Store_SearchProducts", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        sortExpression = EnsureValidSearchProductsSortExpression(sortExpression);
        //        int lowerBound = pageIndex * pageSize + 1;
        //        int upperBound = (pageIndex + 1) * pageSize;
        //        cmd.Parameters.Add("@searchWords", SqlDbType.NVarChar).Value = Helpers.ConvertToFullTextSearchString(searchWords);
        //        cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
        //        cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
        //        cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
        //        cn.Open();
        //        return GetProductCollectionFromReader(ExecuteReader(cmd), false);
        //    }
        //}

        ///// <summary>
        ///// ¬озвращает товары указанного раздела
        ///// </summary>
        //public override List<ProductDetails> GetProducts(int departmentID, int manufacturerID, string sortExpression, int pageIndex, int pageSize, bool onlyVisible)
        //{
        //    if (departmentID <= 0 & manufacturerID > 0)
        //    {
        //        return GetProductsByManufacturer(manufacturerID, sortExpression, pageIndex, pageSize, onlyVisible);
        //    }

        //    if (departmentID > 0 & manufacturerID <= 0)
        //    {
        //        return GetProductsByDepartment(departmentID, sortExpression, pageIndex, pageSize, onlyVisible);
        //    }

        //    if (departmentID <= 0 & manufacturerID <= 0)
        //    {
        //        return GetProducts(sortExpression, pageIndex, pageSize, onlyVisible);
        //    }

        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("sh_Store_GetProductsByDepartmentByManufacturer", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        sortExpression = EnsureValidProductsSortExpression(sortExpression);
        //        int lowerBound = pageIndex * pageSize + 1;
        //        int upperBound = (pageIndex + 1) * pageSize;
        //        cmd.Parameters.Add("@departmentID", SqlDbType.Int).Value = departmentID;
        //        cmd.Parameters.Add("@manufacturerID", SqlDbType.Int).Value = manufacturerID;
        //        cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
        //        cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
        //        cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
        //        cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = onlyVisible;
        //        cn.Open();
        //        return GetProductCollectionFromReader(ExecuteReader(cmd), false);
        //    }
        //}

        ///// <summary>
        ///// ¬озвращает отфильтрованный список товаров
        ///// </summary>
        //public override List<ProductDetails> GetProducts(int departmentID, int manufacturerID, string titleFilter, string sortExpression, int pageIndex, int pageSize, bool onlyVisible)
        //{
        //    string filterExpression = EnsureValidProductsFilterExpression(departmentID, manufacturerID, titleFilter, onlyVisible);

        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("sh_Store_GetProductsByFilter", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        sortExpression = EnsureValidProductsSortExpression(sortExpression);
        //        int lowerBound = pageIndex * pageSize + 1;
        //        int upperBound = (pageIndex + 1) * pageSize;
        //        cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
        //        cmd.Parameters.Add("@filterExpression", SqlDbType.NVarChar).Value = filterExpression;
        //        cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
        //        cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
        //        cn.Open();
        //        return GetProductCollectionFromReader(ExecuteReader(cmd), false);
        //    }
        //}

        ///// <summary>
        ///// ¬озвращает товары указанного раздела
        ///// </summary>
        //public override List<ProductDetails> GetProductsByDepartment(int departmentID, string sortExpression, int pageIndex, int pageSize, bool onlyVisible)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("sh_Store_GetProductsByDepartment", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        sortExpression = EnsureValidProductsSortExpression(sortExpression);
        //        int lowerBound = pageIndex * pageSize + 1;
        //        int upperBound = (pageIndex + 1) * pageSize;
        //        cmd.Parameters.Add("@departmentID", SqlDbType.Int).Value = departmentID;
        //        cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
        //        cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
        //        cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
        //        cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = onlyVisible;
        //        cn.Open();
        //        return GetProductCollectionFromReader(ExecuteReader(cmd), false);
        //    }
        //}

        ///// <summary>
        ///// ¬озвращает товары указанного производител€
        ///// </summary>
        //public override List<ProductDetails> GetProductsByManufacturer(int manufacturerID, string sortExpression, int pageIndex, int pageSize, bool onlyVisible)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("sh_Store_GetProductsByManufacturer", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        sortExpression = EnsureValidProductsSortExpression(sortExpression);
        //        int lowerBound = pageIndex * pageSize + 1;
        //        int upperBound = (pageIndex + 1) * pageSize;
        //        cmd.Parameters.Add("@manufacturerID", SqlDbType.Int).Value = manufacturerID;
        //        cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
        //        cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
        //        cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
        //        cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = onlyVisible;
        //        cn.Open();
        //        return GetProductCollectionFromReader(ExecuteReader(cmd), false);
        //    }
        //}

        ///// <summary>
        ///// ѕолучает все товары со скидкой
        ///// </summary>
        //public override List<ProductDetails> GetProductsSales(string sortExpression, int pageIndex, int pageSize)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("tbh_Store_GetProductsSales", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        sortExpression = EnsureValidProductsSortExpression(sortExpression);
        //        int lowerBound = pageIndex * pageSize + 1;
        //        int upperBound = (pageIndex + 1) * pageSize;
        //        cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
        //        cmd.Parameters.Add("@lowerBound", SqlDbType.Int).Value = lowerBound;
        //        cmd.Parameters.Add("@upperBound", SqlDbType.Int).Value = upperBound;
        //        cn.Open();
        //        return GetProductCollectionFromReader(ExecuteReader(cmd), false);
        //    }
        //}

        ///// <summary>
        ///// Returns the total number of products
        ///// </summary>
        //public override int GetProductCount(bool onlyVisible)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("tbh_Store_GetProductCount", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@Visible", SqlDbType.Bit).Value = onlyVisible;
        //        cn.Open();
        //        return (int)ExecuteScalar(cmd);
        //    }
        //}

        ///// <summary>
        ///// ¬озвращает общее количество товаров указанного раздела указанного производител€
        ///// </summary>
        //public override int GetProductCount(int departmentID, int manufacturerID, bool onlyVisible)
        //{
        //    if (departmentID <= 0 & manufacturerID > 0)
        //    {
        //        return GetProductCountByManufacturer(manufacturerID, onlyVisible);
        //    }

        //    if (departmentID > 0 & manufacturerID <= 0)
        //    {
        //        return GetProductCountByDepartment(departmentID, onlyVisible);
        //    }

        //    if (departmentID <= 0 & manufacturerID <= 0)
        //    {
        //        return GetProductCount(onlyVisible);
        //    }

        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("sh_Store_GetProductCountByDepartmentByManufacturer", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;
        //        cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = manufacturerID;
        //        cmd.Parameters.Add("@Visible", SqlDbType.Bit).Value = onlyVisible;
        //        cn.Open();
        //        return (int)ExecuteScalar(cmd);
        //    }
        //}

        ///// <summary>
        ///// ¬озвращает общее количество отфильтрованных товаров указанного раздела указанного производител€
        ///// </summary>
        //public override int GetProductCount(int departmentID, int manufacturerID, string titleFilter, bool onlyVisible)
        //{
        //    string filterExpression = EnsureValidProductsFilterExpression(departmentID, manufacturerID, titleFilter, onlyVisible);

        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("sh_Store_GetProductCountByFilter", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@FilterExpression", SqlDbType.NVarChar).Value = filterExpression;
        //        cn.Open();
        //        return (int)ExecuteScalar(cmd);
        //    }
        //}

        ///// <summary>
        ///// ¬озвращает общее количество товаров указанного раздела
        ///// </summary>
        //public override int GetProductCountByDepartment(int departmentID, bool onlyVisible)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("sh_Store_GetProductCountByDepartment", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;
        //        cmd.Parameters.Add("@Visible", SqlDbType.Bit).Value = onlyVisible;
        //        cn.Open();
        //        return (int)ExecuteScalar(cmd);
        //    }
        //}

        ///// <summary>
        ///// ¬озвращает общее количество товаров указанного производител€
        ///// </summary>
        //public override int GetProductCountByManufacturer(int manufacturerID, bool onlyVisible)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("sh_Store_GetProductCountByManufacturer", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@ManufacturerID", SqlDbType.Int).Value = manufacturerID;
        //        cmd.Parameters.Add("@Visible", SqlDbType.Bit).Value = onlyVisible;
        //        cn.Open();
        //        return (int)ExecuteScalar(cmd);
        //    }
        //}

        ///// <summary>
        ///// ¬озвращает количество товаров найденных по поисковому запросу
        ///// </summary>
        //public override int GetProductCount(string searchWords)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("tbh_Store_GetProductCountBySearchWords", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@SearchWords", SqlDbType.NVarChar).Value = Helpers.ConvertToFullTextSearchString(searchWords);
        //        cn.Open();
        //        return (int)ExecuteScalar(cmd);
        //    }
        //}

        ///// <summary>
        ///// ¬озвращает количество товароы со скидкой
        ///// </summary>
        //public override int GetProductCountSales()
        //{
        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("tbh_Store_GetProductCountSales", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        return (int)ExecuteScalar(cmd);
        //    }
        //}
    }
}
