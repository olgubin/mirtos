using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Caching;

namespace UC.DAL.SqlClient
{
    public class SqlParsingProvider : ParsingProvider
    {
        /***********************************
        * Каталог
        ************************************/

        /// <summary>
        /// Возвращает коллекцию всех каталогов
        /// </summary>
        public override List<ParsingCatalogDetails> GetCatalogs()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Parsing_GetCatalogs", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetParsingCatalogCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// возвращает каталог по его ID
        /// </summary>
        public override ParsingCatalogDetails GetCatalogByID(int catalogID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Parsing_GetCatalogByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CatalogID", SqlDbType.Int).Value = catalogID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetParsingCatalogFromReader(reader);
                else
                    return null;
            }
        }

        /// <summary>
        /// Удаляет каталог
        /// </summary>
        public override bool DeleteCatalog(int catalogID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Parsing_DeleteCatalog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CatalogID", SqlDbType.Int).Value = catalogID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Изменяет каталог
        /// </summary>
        public override bool UpdateCatalog(ParsingCatalogDetails catalog)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Parsing_UpdateCatalog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CatalogID", SqlDbType.Int).Value = catalog.ID;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = catalog.Title;
                cmd.Parameters.Add("@SiteProviderType", SqlDbType.NVarChar).Value = catalog.SiteProviderType;
                cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = catalog.UpdateDate;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Создает новый каталог
        /// </summary>
        public override int InsertCatalog(ParsingCatalogDetails catalog)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Parsing_InsertCatalog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = catalog.Title;
                cmd.Parameters.Add("@SiteProviderType", SqlDbType.NVarChar).Value = catalog.SiteProviderType;
                cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = catalog.UpdateDate;
                cmd.Parameters.Add("@CatalogID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@CatalogID"].Value;
            }
        }

        /// <summary>
        /// Изменяет дату обновления каталога
        /// </summary>
        public override bool RefreshCatalog(int catalogID, DateTime updateDate)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Parsing_RefreshCatalog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CatalogID", SqlDbType.Int).Value = catalogID;
                cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = updateDate;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /***********************************
        * Товары
        ************************************/

        /// <summary>
        /// Возвращает количество товаров в БД каталога в соответствии с фильтром
        /// </summary>
        public override int GetProductCount(int catalogID, int view)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Parsing_GetProductCountByCatalog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CatalogID", SqlDbType.Int).Value = catalogID;
                cmd.Parameters.Add("@View", SqlDbType.Int).Value = view;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// Получает товар из БД каталога по его ID
        /// </summary>
        public override ParsingProductDetails GetProductByID(int catalogID, int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Parsing_GetProductByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CatalogID", SqlDbType.Int).Value = catalogID;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetParsingProductFromReader(reader);
                else
                    return null;
            }
        }

        /// <summary>
        /// возвращает указанное количество отсортированных товаров из БД каталога в соответствии с фильтром
        /// </summary>
        public override List<ParsingProductDetails> GetProducts(int catalogID, string sortExpression, int pageIndex, int pageSize, int view)
        {
            string filter = "";
            if (view == 1) // измененные товары
            {
                filter = " and (IsNew = 1 or IsUpdated = 1 or IsDeleted = 1 or IsRestored = 1)";
            }

            if (view == 2) // товары c разными ценами
            {
                filter = " and UnitPrice <> (select isnull(UnitPrice,0) from tbh_Products where Productid=LinkId)";
            }

            if (view == 3) // новые товары
            {
                filter = " and IsNew = 1";
            }

            if (view == 4) // удаленные товары
            {
                filter = " and IsDeleted = 1";
            }

            if (view == 5) // восстановленные товары
            {
                filter = " and IsRestored = 1";
            }

            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                sortExpression = EnsureValidProductsSortExpression(sortExpression);
                int lowerBound = pageIndex * pageSize + 1;
                int upperBound = (pageIndex + 1) * pageSize;
                string sql = string.Format(@"SELECT * FROM
                (SELECT 
                ProductID,
                LinkID,
                URL,
                CatalogID,
                AddedDate,
                DepartmentTitle,
                Title,
                ShortDescription,
                LongDescription,
                SKU,
                UnitPrice,
                DiscountPercentage,
                UnitsInStock,
                SmallImageUrl,
                FullImageUrl,
                TotalRating,
                IsNew,
                IsUpdated,
                IsDeleted,
                IsRestored,
                Error,
                ROW_NUMBER() OVER (ORDER BY {0}) AS RowNum
                FROM sh_ParsingProducts 
                WHERE CatalogID = {1} {2}) CatalogProducts
                WHERE CatalogProducts.RowNum BETWEEN {3} AND {4}
                ORDER BY RowNum ASC",
                sortExpression, catalogID, filter, lowerBound, upperBound);
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                return GetParsingProductCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Удаление товара
        /// </summary>
        public override bool DeleteProduct(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Parsing_DeleteProduct", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Добавление нового товара
        /// </summary>
        public override int InsertProduct(ParsingProductDetails product)
        {
            object linkID = product.LinkID;
            if (product.LinkID == 0)
                linkID = DBNull.Value;

            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Parsing_InsertProduct", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LinkID", SqlDbType.Int).Value = linkID;
                cmd.Parameters.Add("@URL", SqlDbType.NVarChar).Value = product.Url;
                cmd.Parameters.Add("@CatalogID", SqlDbType.Int).Value = product.CatalogID;
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = product.AddedDate;
                cmd.Parameters.Add("@DepartmentTitle", SqlDbType.NVarChar).Value = product.DepartmentTitle;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = product.Title;
                cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar).Value = product.ShortDescription;
                cmd.Parameters.Add("@LongDescription", SqlDbType.NVarChar).Value = product.LongDescription;
                cmd.Parameters.Add("@SKU", SqlDbType.NVarChar).Value = product.SKU;
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Money).Value = product.UnitPrice;
                cmd.Parameters.Add("@DiscountPercentage", SqlDbType.Int).Value = product.DiscountPercentage;
                cmd.Parameters.Add("@UnitsInStock", SqlDbType.Int).Value = product.UnitsInStock;
                cmd.Parameters.Add("@SmallImageUrl", SqlDbType.NVarChar).Value = product.SmallImageUrl;
                cmd.Parameters.Add("@FullImageUrl", SqlDbType.NVarChar).Value = product.FullImageUrl;
                cmd.Parameters.Add("@TotalRating", SqlDbType.Int).Value = product.TotalRating;
                cmd.Parameters.Add("@IsNew", SqlDbType.Bit).Value = product.IsNew;
                cmd.Parameters.Add("@IsUpdated", SqlDbType.Bit).Value = product.IsUpdated;
                cmd.Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = product.IsDeleted;
                cmd.Parameters.Add("@IsRestored", SqlDbType.Bit).Value = product.IsRestored;
                cmd.Parameters.Add("@Error", SqlDbType.NVarChar).Value = product.Error;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@ProductID"].Value;
            }
        }

        /// <summary>
        /// Обновление товара
        /// </summary>
        public override bool UpdateProduct(ParsingProductDetails product)
        {
            object linkID = product.LinkID;
            if (product.LinkID == 0)
                linkID = DBNull.Value;

            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Parsing_UpdateProduct", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = product.ID;
                cmd.Parameters.Add("@LinkID", SqlDbType.Int).Value = linkID;
                cmd.Parameters.Add("@URL", SqlDbType.NVarChar).Value = product.Url;
                cmd.Parameters.Add("@CatalogID", SqlDbType.Int).Value = product.CatalogID;
                cmd.Parameters.Add("@DepartmentTitle", SqlDbType.NVarChar).Value = product.DepartmentTitle;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = product.Title;
                cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar).Value = product.ShortDescription;
                cmd.Parameters.Add("@LongDescription", SqlDbType.NVarChar).Value = product.LongDescription;
                cmd.Parameters.Add("@SKU", SqlDbType.NVarChar).Value = product.SKU;
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Money).Value = product.UnitPrice;
                cmd.Parameters.Add("@DiscountPercentage", SqlDbType.Int).Value = product.DiscountPercentage;
                cmd.Parameters.Add("@UnitsInStock", SqlDbType.Int).Value = product.UnitsInStock;
                cmd.Parameters.Add("@SmallImageUrl", SqlDbType.NVarChar).Value = product.SmallImageUrl;
                cmd.Parameters.Add("@FullImageUrl", SqlDbType.NVarChar).Value = product.FullImageUrl;
                cmd.Parameters.Add("@TotalRating", SqlDbType.Int).Value = product.TotalRating;
                cmd.Parameters.Add("@IsNew", SqlDbType.Bit).Value = product.IsNew;
                cmd.Parameters.Add("@IsUpdated", SqlDbType.Bit).Value = product.IsUpdated;
                cmd.Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = product.IsDeleted;
                cmd.Parameters.Add("@IsRestored", SqlDbType.Bit).Value = product.IsRestored;
                cmd.Parameters.Add("@Error", SqlDbType.NVarChar).Value = product.Error;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Добавление признака IsDeleted
        /// </summary>
        public override bool IsDeleted(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Parsing_IsDeleted", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Добавление признака IsRestored
        /// </summary>
        public override bool IsRestored(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Parsing_IsRestored", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Товар не обновлялся
        /// </summary>
        public override bool IsNoneUpdated(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sh_Parsing_IsNoneUpdated", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }
    }
}
