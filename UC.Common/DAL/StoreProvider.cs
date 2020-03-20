using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;

namespace UC.DAL
{
    public abstract class StoreProvider : DataAccess
    {
        static private StoreProvider _instance = null;
        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>
        static public StoreProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (StoreProvider)Activator.CreateInstance(
                       Type.GetType(Globals.Settings.Store.ProviderType));
                return _instance;
            }
        }

        public StoreProvider()
        {
            this.ConnectionString = Globals.Settings.Store.ConnectionString;
            this.EnableCaching = Globals.Settings.Store.EnableCaching;
            this.CacheDuration = Globals.Settings.Store.CacheDuration;
        }

        // методы для работы со статусами
        public abstract List<OrderStatusDetails> GetOrderStatuses();
        public abstract OrderStatusDetails GetOrderStatusByID(int orderStatusID);
        public abstract bool DeleteOrderStatus(int orderStatusID);
        public abstract bool UpdateOrderStatus(OrderStatusDetails orderStatus);
        public abstract int InsertOrderStatus(OrderStatusDetails orderStatus);

        // меоды для работы с методами продаж
        public abstract List<ShippingMethodDetails> GetShippingMethods();
        public abstract ShippingMethodDetails GetShippingMethodByID(int orderStatusID);
        public abstract bool DeleteShippingMethod(int shippingMethodID);
        public abstract bool UpdateShippingMethod(ShippingMethodDetails shippingMethod);
        public abstract int InsertShippingMethod(ShippingMethodDetails shippingMethod);

        // методы для работы с заказами
        public abstract List<OrderDetails> GetOrders(int statusID, DateTime fromDate, DateTime toDate);
        public abstract List<OrderDetails> GetOrders(string addedBy);
        public abstract OrderDetails GetOrderByID(int orderID);
        public abstract bool DeleteOrder(int orderID);
        public abstract int InsertOrder(OrderDetails order);
        public abstract bool UpdateOrder(OrderDetails order);

        // методы для работы с элементами заказов
        public abstract List<OrderItemDetails> GetOrderItems(int orderID);
        public abstract int InsertOrderItem(OrderItemDetails orderItem);

        /// <summary>
        /// Возвращает выражение сортировки при поиске товаров
        /// </summary>
        protected virtual string EnsureValidSearchProductsSortExpression(string sortExpression)
        {
            if (string.IsNullOrEmpty(sortExpression))
                return "tbh_Products.Title ASC";

            string sortExpr = sortExpression.ToLower();
            if (!sortExpr.Equals("unitprice") && !sortExpr.Equals("unitprice asc") && !sortExpr.Equals("unitprice desc") &&
               !sortExpr.Equals("discountpercentage") && !sortExpr.Equals("discountpercentage asc") && !sortExpr.Equals("discountpercentage desc") &&
               !sortExpr.Equals("addeddate") && !sortExpr.Equals("addeddate asc") && !sortExpr.Equals("addeddate desc") &&
               !sortExpr.Equals("addedby") && !sortExpr.Equals("addedby asc") && !sortExpr.Equals("addedby desc") &&
               !sortExpr.Equals("unitsinstock") && !sortExpr.Equals("unitsinstock asc") && !sortExpr.Equals("unitsinstock desc") &&
               !sortExpr.Equals("totalrating") && !sortExpr.Equals("totalrating asc") && !sortExpr.Equals("totalrating desc") &&
               !sortExpr.Equals("title") && !sortExpr.Equals("title asc") && !sortExpr.Equals("title desc") &&
               !sortExpr.Equals("rank") && !sortExpr.Equals("rank asc") && !sortExpr.Equals("rank desc"))
            {
                sortExpr = "title asc";
            }
            if (!sortExpr.StartsWith("rank"))
            {
                if (!sortExpr.StartsWith("tbh_products"))
                    sortExpr = "tbh_products." + sortExpr;
            }
            if (!sortExpr.StartsWith("tbh_products.title"))
                sortExpr += ", tbh_products.title asc";
            return sortExpr;
        }

        protected virtual string EnsureValidProductsFilterExpression(int departmentID, int manufacturerID, string titleFilter, bool onlyVisible)
        {
            string filterExpression = @"";

            if (departmentID > 0)
            {
                filterExpression = @" tbh_Products.DepartmentID = " + departmentID.ToString();
            }

            if (manufacturerID > 0)
            {
                if (!String.IsNullOrEmpty(filterExpression))
                {
                    filterExpression = filterExpression + @" AND ";
                }
                filterExpression = @" tbh_Products.ManufacturerID = " + manufacturerID.ToString();
            }

            if (!String.IsNullOrEmpty(titleFilter))
            {
                if (!String.IsNullOrEmpty(filterExpression))
                {
                    filterExpression = filterExpression + @" AND ";
                }

                filterExpression = @" tbh_Products.Title LIKE N'%" + titleFilter + "%' ";
            }

            if (onlyVisible)
            {
                if (!String.IsNullOrEmpty(filterExpression))
                {
                    filterExpression = filterExpression + @" AND ";
                }

                filterExpression = @" tbh_Products.OnlyVisible = 1 ";
            }

            if (!String.IsNullOrEmpty(filterExpression))
            {
                filterExpression = @" WHERE " + filterExpression;
            }

            return filterExpression;
        }

        /// <summary>
        /// Returns a valid sort expression for the products
        /// </summary>
        protected virtual string EnsureValidProductsSortExpression(string sortExpression)
        {
            if (string.IsNullOrEmpty(sortExpression))
                return "tbh_Products.Title ASC";

            string sortExpr = sortExpression.ToLower();
            if (!sortExpr.Equals("unitprice") && !sortExpr.Equals("unitprice asc") && !sortExpr.Equals("unitprice desc") &&
               !sortExpr.Equals("discountpercentage") && !sortExpr.Equals("discountpercentage asc") && !sortExpr.Equals("discountpercentage desc") &&
               !sortExpr.Equals("addeddate") && !sortExpr.Equals("addeddate asc") && !sortExpr.Equals("addeddate desc") &&
               !sortExpr.Equals("addedby") && !sortExpr.Equals("addedby asc") && !sortExpr.Equals("addedby desc") &&
               !sortExpr.Equals("unitsinstock") && !sortExpr.Equals("unitsinstock asc") && !sortExpr.Equals("unitsinstock desc") &&
               !sortExpr.Equals("totalrating") && !sortExpr.Equals("totalrating asc") && !sortExpr.Equals("totalrating desc") &&
               !sortExpr.Equals("title") && !sortExpr.Equals("title asc") && !sortExpr.Equals("title desc") &&
               !sortExpr.Equals("manufacturertitle") && !sortExpr.Equals("manufacturertitle asc") && !sortExpr.Equals("manufacturertitle desc"))
            {
                sortExpr = "title asc";
            }

            if (!sortExpr.StartsWith("manufacturertitle"))
            {
                if (!sortExpr.StartsWith("tbh_products"))
                    sortExpr = "tbh_products." + sortExpr;
            }
            else
            {
                if (sortExpr.Equals("manufacturertitle desc"))
                    sortExpr = "sh_Manufacturers.Title desc";
                else
                    sortExpr = "sh_Manufacturers.Title";

            }

            if (!sortExpr.StartsWith("tbh_products.title"))
                sortExpr += ", tbh_products.title asc";
            return sortExpr;
        }

        /// <summary>
        /// Returns a new OrderStatusDetails instance filled with the DataReader's current record data
        /// </summary>
        protected virtual OrderStatusDetails GetOrderStatusFromReader(IDataReader reader)
        {
            return new OrderStatusDetails(
               (int)reader["OrderStatusID"],
               (DateTime)reader["AddedDate"],
               reader["AddedBy"].ToString(),
               reader["Title"].ToString());
        }

        /// <summary>
        /// Returns a collection of OrderStatusDetails objects with the data read from the input DataReader
        /// </summary>
        protected virtual List<OrderStatusDetails> GetOrderStatusCollectionFromReader(IDataReader reader)
        {
            List<OrderStatusDetails> orderStatuses = new List<OrderStatusDetails>();
            while (reader.Read())
                orderStatuses.Add(GetOrderStatusFromReader(reader));
            return orderStatuses;
        }

        /// <summary>
        /// Returns a new ShippingMethodDetails instance filled with the DataReader's current record data
        /// </summary>
        protected virtual ShippingMethodDetails GetShippingMethodFromReader(IDataReader reader)
        {
            return new ShippingMethodDetails(
               (int)reader["ShippingMethodID"],
               (DateTime)reader["AddedDate"],
               reader["AddedBy"].ToString(),
               reader["Title"].ToString(),
               (decimal)reader["Price"]);
        }

        /// <summary>
        /// Returns a collection of ShippingMethodDetails objects with the data read from the input DataReader
        /// </summary>
        protected virtual List<ShippingMethodDetails> GetShippingMethodCollectionFromReader(IDataReader reader)
        {
            List<ShippingMethodDetails> shippingMethods = new List<ShippingMethodDetails>();
            while (reader.Read())
                shippingMethods.Add(GetShippingMethodFromReader(reader));
            return shippingMethods;
        }

        /// <summary>
        /// Returns a new OrderItemDetails instance filled with the DataReader's current record data
        /// </summary>
        protected virtual OrderItemDetails GetOrderItemFromReader(IDataReader reader)
        {
            return new OrderItemDetails(
               (int)reader["OrderItemID"],
               (DateTime)reader["AddedDate"],
               reader["AddedBy"].ToString(),
               (int)reader["OrderID"],
               (int)reader["ProductID"],
               reader["Title"].ToString(),
               reader["SKU"].ToString(),
               (decimal)reader["UnitPrice"],
               (int)reader["Quantity"]);
        }

        /// <summary>
        /// Returns a collection of OrderItemDetails objects with the data read from the input DataReader
        /// </summary>
        protected virtual List<OrderItemDetails> GetOrderItemCollectionFromReader(IDataReader reader)
        {
            List<OrderItemDetails> orderItems = new List<OrderItemDetails>();
            while (reader.Read())
                orderItems.Add(GetOrderItemFromReader(reader));
            return orderItems;
        }

        /// <summary>
        /// Returns a new OrderDetails instance filled with the DataReader's current record data
        /// </summary>
        protected virtual OrderDetails GetOrderFromReader(IDataReader reader)
        {
            return new OrderDetails(
               (int)reader["OrderID"],
               (DateTime)reader["AddedDate"],
               reader["AddedBy"].ToString(),
               (int)reader["StatusID"],
               reader["StatusTitle"].ToString(),
               reader["ShippingMethod"].ToString(),
               (decimal)reader["SubTotal"],
               (decimal)reader["Shipping"],
               reader["ShippingFirstName"].ToString(),
               reader["ShippingLastName"].ToString(),
               reader["ShippingStreet"].ToString(),
               reader["ShippingPostalCode"].ToString(),
               reader["ShippingCity"].ToString(),
               reader["ShippingState"].ToString(),
               reader["ShippingCountry"].ToString(),
               reader["CustomerEmail"].ToString(),
               reader["CustomerPhone"].ToString(),
               reader["CustomerFax"].ToString(),
               (reader["ShippedDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ShippedDate"]),
               reader["TransactionID"].ToString(),
               reader["TrackingID"].ToString());
        }

        /// <summary>
        /// Returns a collection of OrderDetails objects with the data read from the input DataReader
        /// </summary>
        protected virtual List<OrderDetails> GetOrderCollectionFromReader(IDataReader reader)
        {
            List<OrderDetails> orders = new List<OrderDetails>();
            while (reader.Read())
                orders.Add(GetOrderFromReader(reader));
            return orders;
        }
    }
}
