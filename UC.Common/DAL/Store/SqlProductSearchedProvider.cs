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
    internal class SqlProductSearchedProvider: DataAccess
    {
        public static ProductSearchedCollection GetSearch(string searchWords)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_Store_ProductsGetSearch", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@searchWords", SqlDbType.NVarChar).Value = searchWords;
                cn.Open();
                return GetProductSearchedCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Возвращает коллекцию товаров из ридера
        /// </summary>
        public static ProductSearchedCollection GetProductSearchedCollectionFromReader(IDataReader reader)
        {
            ProductSearchedCollection productSearchedCollection = new ProductSearchedCollection();

            while (reader.Read())
                productSearchedCollection.Add(GetProductSearchedFromReader(reader));

            return productSearchedCollection;
        }

        /// <summary>
        /// Возвращает товар из текущей записи ридера
        /// </summary>
        public static ProductSearched GetProductSearchedFromReader(IDataReader reader)
        {
            ProductSearched productSearched = new ProductSearched();
            productSearched.ProductID = GetInt(reader, "ProductID");
            productSearched.Rank = GetInt(reader, "Rank");

            return productSearched;
        }
    }
}
