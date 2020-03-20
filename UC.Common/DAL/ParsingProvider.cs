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

namespace UC.DAL
{
    public abstract class ParsingProvider : DataAccess
    {
        static private ParsingProvider _instance = null;
        /// <summary>
        /// Возвращает ссылку на провайдера определенного в web.config
        /// </summary>
        static public ParsingProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (ParsingProvider)Activator.CreateInstance(
                       Type.GetType(Globals.Settings.Parsing.ProviderType));
                return _instance;
            }
        }

        public ParsingProvider()
        {
            this.ConnectionString = Globals.Settings.Parsing.ConnectionString;
            this.EnableCaching = Globals.Settings.Parsing.EnableCaching;
            this.CacheDuration = Globals.Settings.Parsing.CacheDuration;
        }

        /***********************************
        * Методы для работы с каталогами
        ************************************/

        public abstract List<ParsingCatalogDetails> GetCatalogs();
        public abstract ParsingCatalogDetails GetCatalogByID(int catalogID);
        public abstract bool DeleteCatalog(int catalogID);
        public abstract bool UpdateCatalog(ParsingCatalogDetails catalog);
        public abstract int InsertCatalog(ParsingCatalogDetails catalog);
        public abstract bool RefreshCatalog(int catalogID, DateTime updateDate);


        /// <summary>
        /// Возвращает коллекцию объектов ParsingCatalogDetails c данными полученными из DataReader
        /// </summary>
        protected virtual List<ParsingCatalogDetails> GetParsingCatalogCollectionFromReader(IDataReader reader)
        {
            List<ParsingCatalogDetails> catalogs = new List<ParsingCatalogDetails>();
            while (reader.Read())
                catalogs.Add(GetParsingCatalogFromReader(reader));
            return catalogs;
        }

        /// <summary>
        /// Возвращает ParsingCatalogDetails заполненный данными текущей записи DataReader'а
        /// </summary>
        protected virtual ParsingCatalogDetails GetParsingCatalogFromReader(IDataReader reader)
        {
            return new ParsingCatalogDetails(
               (int)reader["CatalogID"],
               reader["Title"].ToString(),
               reader["SiteProviderType"].ToString(),
               (DateTime)reader["UpdateDate"]);
        }

        /***********************************
        * Методы для работы с товарами
        ************************************/

        public abstract int GetProductCount(int catalogID, int view);
        public abstract List<ParsingProductDetails> GetProducts(int catalogID, string sortExpression, int pageIndex, int pageSize, int view);
        public abstract ParsingProductDetails GetProductByID(int catalogID, int productID);
        public abstract bool DeleteProduct(int productID);
        public abstract bool UpdateProduct(ParsingProductDetails product);
        public abstract int InsertProduct(ParsingProductDetails product);
        public abstract bool IsDeleted(int productID);
        public abstract bool IsRestored(int productID);
        public abstract bool IsNoneUpdated(int productID);

        /// <summary>
        /// Возвращает корректное выражение для сортировки
        /// </summary>
        protected virtual string EnsureValidProductsSortExpression(string sortExpression)
        {
            if (string.IsNullOrEmpty(sortExpression))
                return "Title ASC";

            string sortExpr = sortExpression.ToLower();
            if (!sortExpr.Equals("unitprice") && !sortExpr.Equals("unitprice asc") && !sortExpr.Equals("unitprice desc") &&
               !sortExpr.Equals("discountpercentage") && !sortExpr.Equals("discountpercentage asc") && !sortExpr.Equals("discountpercentage desc") &&
               !sortExpr.Equals("addeddate") && !sortExpr.Equals("addeddate asc") && !sortExpr.Equals("addeddate desc") &&
               !sortExpr.Equals("addedby") && !sortExpr.Equals("addedby asc") && !sortExpr.Equals("addedby desc") &&
               !sortExpr.Equals("unitsinstock") && !sortExpr.Equals("unitsinstock asc") && !sortExpr.Equals("unitsinstock desc") &&
               !sortExpr.Equals("totalrating") && !sortExpr.Equals("totalrating asc") && !sortExpr.Equals("totalrating desc") &&
               !sortExpr.Equals("departmenttitle") && !sortExpr.Equals("departmenttitle asc") && !sortExpr.Equals("departmenttitle desc") &&
               !sortExpr.Equals("title") && !sortExpr.Equals("title asc") && !sortExpr.Equals("title desc"))
            {
                sortExpr = "title asc";
            }
            if (!sortExpr.StartsWith("title"))
                sortExpr += ", title asc";
            return sortExpr;
        }

        /// <summary>
        /// Возвращает коллекцию объектов ParsingProductDetails c данными полученными из DataReader
        /// </summary>
        protected virtual List<ParsingProductDetails> GetParsingProductCollectionFromReader(IDataReader reader)
        {
            List<ParsingProductDetails> products = new List<ParsingProductDetails>();
            while (reader.Read())
                products.Add(GetParsingProductFromReader(reader));
            return products;
        }

        /// <summary>
        /// Возвращает ParsingProductDetails заполненный данными текущей записи DataReader'а
        /// </summary>
        protected virtual ParsingProductDetails GetParsingProductFromReader(IDataReader reader)
        {
            return new ParsingProductDetails(
               (int)reader["ProductID"],
               reader["LinkID"] == DBNull.Value ? 0 : (int)reader["LinkID"],
               reader["URL"].ToString(),
               (int)reader["CatalogID"],
               (DateTime)reader["AddedDate"],
               reader["DepartmentTitle"].ToString(),
               reader["Title"].ToString(),
               reader["ShortDescription"].ToString(),
               reader["LongDescription"].ToString(),
               reader["SKU"].ToString(),
               (decimal)reader["UnitPrice"],
               (int)reader["DiscountPercentage"],
               (int)reader["UnitsInStock"],
               reader["SmallImageUrl"].ToString(),
               reader["FullImageUrl"].ToString(),
               (int)reader["TotalRating"],
               (bool)reader["IsNew"],
               (bool)reader["IsUpdated"],
               (bool)reader["IsDeleted"],
               (bool)reader["IsRestored"],
               reader["Error"].ToString());
        }
    }
}
