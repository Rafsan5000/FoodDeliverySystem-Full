using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FoodDeliverySystem.Database;

namespace FoodDeliverySystem.Model
{
    /// <summary>
    /// Data-access class for the OrderDetails table.
    ///
    /// This table is the fix for the biggest normalisation problem in the
    /// original database, where Orders.ProductNames held every food name of
    /// an order inside one text column. That made it impossible to ask "how
    /// many burgers did we sell?" without string searching. Now each item is
    /// its own row and every report is a simple SUM.
    /// </summary>
    public class OrderDetails
    {
        private readonly SqlDbDataAccess sda = new SqlDbDataAccess();

        /* ---------------- CREATE ---------------- */

        /// <summary>
        /// Used only when adding an item to an order outside checkout.
        /// Normal checkout inserts these rows inside Orders.PlaceOrder so
        /// they share its transaction.
        /// </summary>
        public int AddOrderDetail(OrderDetail detail)
        {
            string query =
                "INSERT INTO OrderDetails (OrderId, FoodId, Quantity, Price) " +
                "VALUES (@OrderId, @FoodId, @Quantity, @Price);";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@OrderId",  detail.OrderId),
                new SqlParameter("@FoodId",   detail.FoodId),
                new SqlParameter("@Quantity", detail.Quantity),
                new SqlParameter("@Price",    detail.Price));
        }

        /* ---------------- READ ---------------- */

        /// <summary>
        /// JOIN QUERY that builds the invoice. Subtotal is calculated by SQL
        /// Server rather than stored, because a value you can derive from
        /// other columns should not be a column of its own.
        /// </summary>
        public DataTable GetInvoiceByOrder(int orderId)
        {
            string query =
                "SELECT od.OrderDetailId, f.FoodName, r.RestaurantName, " +
                "       od.Quantity, od.Price, " +
                "       (od.Quantity * od.Price) AS Subtotal " +
                "FROM   OrderDetails od " +
                "       INNER JOIN Foods       f ON od.FoodId      = f.FoodId " +
                "       INNER JOIN Restaurants r ON f.RestaurantId = r.RestaurantId " +
                "WHERE  od.OrderId = @OrderId " +
                "ORDER  BY od.OrderDetailId;";

            return sda.ExecuteQuery(query, new SqlParameter("@OrderId", orderId));
        }

        public List<OrderDetail> GetDetailsByOrder(int orderId)
        {
            DataTable table = GetInvoiceByOrder(orderId);
            List<OrderDetail> list = new List<OrderDetail>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new OrderDetail
                {
                    OrderDetailId  = Convert.ToInt32(row["OrderDetailId"]),
                    OrderId        = orderId,
                    FoodName       = row["FoodName"].ToString(),
                    RestaurantName = row["RestaurantName"].ToString(),
                    Quantity       = Convert.ToInt32(row["Quantity"]),
                    Price          = Convert.ToDecimal(row["Price"])
                });
            }

            return list;
        }

        /// <summary>
        /// The same invoice, but limited to one restaurant's items. An order
        /// can contain food from two restaurants, and each kitchen should
        /// only see the part it has to cook.
        /// </summary>
        public DataTable GetOrderItemsForRestaurant(int orderId, int restaurantId)
        {
            string query =
                "SELECT od.OrderDetailId, f.FoodName, od.Quantity, od.Price, " +
                "       (od.Quantity * od.Price) AS Subtotal " +
                "FROM   OrderDetails od INNER JOIN Foods f ON od.FoodId = f.FoodId " +
                "WHERE  od.OrderId = @OrderId AND f.RestaurantId = @RestaurantId " +
                "ORDER  BY od.OrderDetailId;";

            return sda.ExecuteQuery(query,
                new SqlParameter("@OrderId",      orderId),
                new SqlParameter("@RestaurantId", restaurantId));
        }

        /// <summary>Aggregate used to double-check an invoice total.</summary>
        public decimal GetOrderTotal(int orderId)
        {
            string query =
                "SELECT ISNULL(SUM(Quantity * Price), 0) FROM OrderDetails WHERE OrderId = @OrderId;";

            return Convert.ToDecimal(sda.ExecuteScalar(query,
                new SqlParameter("@OrderId", orderId)));
        }

        public int GetItemCount(int orderId)
        {
            return Convert.ToInt32(sda.ExecuteScalar(
                "SELECT ISNULL(SUM(Quantity), 0) FROM OrderDetails WHERE OrderId = @OrderId;",
                new SqlParameter("@OrderId", orderId)));
        }

        /* ---------------- UPDATE / DELETE ---------------- */

        public int UpdateQuantity(int orderDetailId, int quantity)
        {
            string query =
                "UPDATE OrderDetails SET Quantity = @Quantity WHERE OrderDetailId = @OrderDetailId;";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@Quantity",      quantity),
                new SqlParameter("@OrderDetailId", orderDetailId));
        }

        /// <summary>
        /// Removing a line from an order that has not been accepted yet.
        /// A real DELETE is correct here because an order line has no children
        /// of its own; the order header keeps the history.
        /// </summary>
        public int DeleteOrderDetail(int orderDetailId)
        {
            return sda.ExecuteNonQuery(
                "DELETE FROM OrderDetails WHERE OrderDetailId = @OrderDetailId;",
                new SqlParameter("@OrderDetailId", orderDetailId));
        }
    }
}
