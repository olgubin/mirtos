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
    public class SqlStoreProvider : StoreProvider
    {
        /// <summary>
        /// Returns a collection with all the order statuses
        /// </summary>
        public override List<OrderStatusDetails> GetOrderStatuses()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_GetOrderStatuses", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetOrderStatusCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Returns an existing order status with the specified ID
        /// </summary>
        public override OrderStatusDetails GetOrderStatusByID(int orderStatusID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_GetOrderStatusByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderStatusID", SqlDbType.Int).Value = orderStatusID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetOrderStatusFromReader(reader);
                else
                    return null;
            }
        }

        /// <summary>
        /// Deletes a order status
        /// </summary>
        public override bool DeleteOrderStatus(int orderStatusID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_DeleteOrderStatus", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderStatusID", SqlDbType.Int).Value = orderStatusID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Updates a order status
        /// </summary>
        public override bool UpdateOrderStatus(OrderStatusDetails orderStatus)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_UpdateOrderStatus", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderStatusID", SqlDbType.Int).Value = orderStatus.ID;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = orderStatus.Title;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Creates a new order status
        /// </summary>
        public override int InsertOrderStatus(OrderStatusDetails orderStatus)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_InsertOrderStatus", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = orderStatus.AddedDate;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = orderStatus.AddedBy;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = orderStatus.Title;
                cmd.Parameters.Add("@OrderStatusID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@OrderStatusID"].Value;
            }
        }

        /// <summary>
        /// Returns a collection with all the shipping methods
        /// </summary>
        public override List<ShippingMethodDetails> GetShippingMethods()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_GetShippingMethods", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetShippingMethodCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Returns an existing shipping method with the specified ID
        /// </summary>
        public override ShippingMethodDetails GetShippingMethodByID(int shippingMethodID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_GetShippingMethodByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ShippingMethodID", SqlDbType.Int).Value = shippingMethodID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetShippingMethodFromReader(reader);
                else
                    return null;
            }
        }

        /// <summary>
        /// Deletes a shipping method
        /// </summary>
        public override bool DeleteShippingMethod(int shippingMethodID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_DeleteShippingMethod", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ShippingMethodID", SqlDbType.Int).Value = shippingMethodID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Updates a shipping method
        /// </summary>
        public override bool UpdateShippingMethod(ShippingMethodDetails shippingMethod)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_UpdateShippingMethod", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ShippingMethodID", SqlDbType.Int).Value = shippingMethod.ID;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = shippingMethod.Title;
                cmd.Parameters.Add("@Price", SqlDbType.Money).Value = shippingMethod.Price;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Creates a new shipping method
        /// </summary>
        public override int InsertShippingMethod(ShippingMethodDetails shippingMethod)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_InsertShippingMethod", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = shippingMethod.AddedDate;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = shippingMethod.AddedBy;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = shippingMethod.Title;
                cmd.Parameters.Add("@Price", SqlDbType.Money).Value = shippingMethod.Price;
                cmd.Parameters.Add("@ShippingMethodID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@ShippingMethodID"].Value;
            }
        }

        /// <summary>
        /// Retrieves the list of orders for the specified customer
        /// </summary>
        public override List<OrderDetails> GetOrders(string addedBy)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_GetOrdersByCustomer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = addedBy;
                cn.Open();
                return GetOrderCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Retrieves the list of orders in the specified state, and within the specified date range
        /// </summary>
        public override List<OrderDetails> GetOrders(int statusID, DateTime fromDate, DateTime toDate)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_GetOrdersByStatus", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = statusID;
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = toDate;
                cn.Open();
                return GetOrderCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Retrieves the order with the specified ID
        /// </summary>
        public override OrderDetails GetOrderByID(int orderID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_GetOrderByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderID;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetOrderFromReader(reader);
                else
                    return null;
            }
        }

        /// <summary>
        /// Deletes an order
        /// </summary>
        public override bool DeleteOrder(int orderID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_DeleteOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Inserts a new order
        /// </summary>
        public override int InsertOrder(OrderDetails order)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_InsertOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = order.AddedDate;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = order.AddedBy;
                cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = order.StatusID;
                cmd.Parameters.Add("@ShippingMethod", SqlDbType.NVarChar).Value = order.ShippingMethod;
                cmd.Parameters.Add("@SubTotal", SqlDbType.Money).Value = order.SubTotal;
                cmd.Parameters.Add("@Shipping", SqlDbType.Money).Value = order.Shipping;
                cmd.Parameters.Add("@ShippingFirstName", SqlDbType.NVarChar).Value = order.ShippingFirstName;
                cmd.Parameters.Add("@ShippingLastName", SqlDbType.NVarChar).Value = order.ShippingLastName;
                cmd.Parameters.Add("@ShippingStreet", SqlDbType.NVarChar).Value = order.ShippingStreet;
                cmd.Parameters.Add("@ShippingPostalCode", SqlDbType.NVarChar).Value = order.ShippingPostalCode;
                cmd.Parameters.Add("@ShippingCity", SqlDbType.NVarChar).Value = order.ShippingCity;
                cmd.Parameters.Add("@ShippingState", SqlDbType.NVarChar).Value = order.ShippingState;
                cmd.Parameters.Add("@ShippingCountry", SqlDbType.NVarChar).Value = order.ShippingCountry;
                cmd.Parameters.Add("@CustomerEmail", SqlDbType.NVarChar).Value = order.CustomerEmail;
                cmd.Parameters.Add("@CustomerPhone", SqlDbType.NVarChar).Value = order.CustomerPhone;
                cmd.Parameters.Add("@CustomerFax", SqlDbType.NVarChar).Value = order.CustomerFax;
                cmd.Parameters.Add("@TransactionID", SqlDbType.NVarChar).Value = order.TransactionID;
                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@OrderID"].Value;
            }
        }

        /// <summary>
        /// Updates an existing order
        /// </summary>
        public override bool UpdateOrder(OrderDetails order)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                object shippedDate = order.ShippedDate;
                if (order.ShippedDate == DateTime.MinValue)
                    shippedDate = DBNull.Value;

                SqlCommand cmd = new SqlCommand("tbh_Store_UpdateOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = order.ID;
                cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = order.StatusID;
                cmd.Parameters.Add("@ShippedDate", SqlDbType.DateTime).Value = shippedDate;
                cmd.Parameters.Add("@TransactionID", SqlDbType.NVarChar).Value = order.TransactionID;
                cmd.Parameters.Add("@TrackingID", SqlDbType.NVarChar).Value = order.TrackingID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Get a collection with all order items for the specified order
        /// </summary>
        public override List<OrderItemDetails> GetOrderItems(int orderID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_GetOrderItems", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderID;
                cn.Open();
                return GetOrderItemCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Inserts a new order item
        /// </summary>
        public override int InsertOrderItem(OrderItemDetails orderItem)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Store_InsertOrderItem", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = orderItem.AddedDate;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = orderItem.AddedBy;
                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderItem.OrderID;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = orderItem.ProductID;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = orderItem.Title;
                cmd.Parameters.Add("@SKU", SqlDbType.NVarChar).Value = orderItem.SKU;
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Money).Value = orderItem.UnitPrice;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = orderItem.Quantity;
                cmd.Parameters.Add("@OrderItemID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@OrderItemID"].Value;
            }
        }
    }
}
