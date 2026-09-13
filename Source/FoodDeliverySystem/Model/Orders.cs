using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FoodDeliverySystem.Database;

namespace FoodDeliverySystem.Model
{
    /// <summary>
    /// Data-access class for the Orders table, plus the checkout process and
    /// the reporting queries that read across Orders / OrderDetails / Foods.
    /// </summary>
    public class Orders
    {
        private readonly SqlDbDataAccess sda = new SqlDbDataAccess();

        /* ==================================================================
           CHECKOUT - the most important method in the project
           ================================================================== */

        /// <summary>
        /// Turns the customer's cart into a real order.
        ///
        /// Five things have to happen, and either all of them happen or none
        /// of them do, so the whole method runs inside ONE transaction:
        ///
        ///   1. INSERT one row into Orders          (the order header)
        ///   2. INSERT one row per item into OrderDetails
        ///   3. UPDATE Foods to reduce the stock
        ///   4. INSERT one row into Payments
        ///   5. DELETE the customer's cart rows
        ///
        /// If step 3 finds that another customer took the last item while
        /// this one was checking out, we roll back: the order disappears, the
        /// stock is untouched and the cart is still there for the customer to
        /// fix. Without a transaction we would be left with an order for food
        /// that does not exist.
        /// </summary>
        /// <returns>The new OrderId, or 0 when the checkout was refused.</returns>
        public int PlaceOrder(int customerId, List<CartItem> items,
                              string paymentMethod, string deliveryAddress,
                              out string message)
        {
            message = string.Empty;

            if (items == null || items.Count == 0)
            {
                message = "Your cart is empty.";
                return 0;
            }

            decimal total = 0;
            foreach (CartItem item in items)
                total += item.Price * item.Quantity;

            using (SqlConnection connection = sda.OpenConnection())
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    /* --- 1. the order header ------------------------------ */
                    int orderId;

                    string insertOrder =
                        "INSERT INTO Orders (CustomerId, OrderDate, TotalAmount, OrderStatus) " +
                        "VALUES (@CustomerId, GETDATE(), @TotalAmount, 'Pending'); " +
                        "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    using (SqlCommand command = new SqlCommand(insertOrder, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@CustomerId",  customerId);
                        command.Parameters.AddWithValue("@TotalAmount", total);
                        orderId = Convert.ToInt32(command.ExecuteScalar());
                    }

                    /* --- 2 and 3. the items, and the stock ---------------- */
                    foreach (CartItem item in items)
                    {
                        string insertDetail =
                            "INSERT INTO OrderDetails (OrderId, FoodId, Quantity, Price) " +
                            "VALUES (@OrderId, @FoodId, @Quantity, @Price);";

                        using (SqlCommand command = new SqlCommand(insertDetail, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@OrderId",  orderId);
                            command.Parameters.AddWithValue("@FoodId",   item.FoodId);
                            command.Parameters.AddWithValue("@Quantity", item.Quantity);
                            command.Parameters.AddWithValue("@Price",    item.Price);
                            command.ExecuteNonQuery();
                        }

                        // The WHERE clause contains "AND Stock >= @Quantity",
                        // so this returns 0 rows when stock ran out.
                        string reduceStock =
                            "UPDATE Foods SET Stock = Stock - @Quantity " +
                            "WHERE  FoodId = @FoodId AND Stock >= @Quantity;";

                        using (SqlCommand command = new SqlCommand(reduceStock, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Quantity", item.Quantity);
                            command.Parameters.AddWithValue("@FoodId",   item.FoodId);

                            if (command.ExecuteNonQuery() == 0)
                            {
                                transaction.Rollback();
                                message = "Sorry, '" + item.FoodName +
                                          "' does not have enough stock any more. " +
                                          "Please reduce the quantity and try again.";
                                return 0;
                            }
                        }
                    }

                    /* --- 4. the payment record --------------------------- */
                    string insertPayment =
                        "INSERT INTO Payments (OrderId, PaymentMethod, PaymentStatus, PaymentDate) " +
                        "VALUES (@OrderId, @PaymentMethod, @PaymentStatus, GETDATE());";

                    using (SqlCommand command = new SqlCommand(insertPayment, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@OrderId",       orderId);
                        command.Parameters.AddWithValue("@PaymentMethod", paymentMethod);

                        // Cash on delivery is not paid yet; the other two are.
                        command.Parameters.AddWithValue("@PaymentStatus",
                            paymentMethod == "Cash on Delivery" ? "Pending" : "Paid");

                        command.ExecuteNonQuery();
                    }

                    /* --- 5. empty the cart ------------------------------- */
                    using (SqlCommand command = new SqlCommand(
                        "DELETE FROM Cart WHERE CustomerId = @CustomerId;", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customerId);
                        command.ExecuteNonQuery();
                    }

                    // Nothing failed, so make all five changes permanent.
                    transaction.Commit();

                    message = "Order placed successfully. Your order number is " + orderId + ".";
                    return orderId;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /* ==================================================================
           READ
           ================================================================== */

        /// <summary>
        /// JOIN QUERY for the customer's order history. The LEFT JOIN on
        /// Payments is deliberate: an order should still appear in the list
        /// even if the payment row is somehow missing.
        /// </summary>
        public DataTable GetOrdersByCustomer(int customerId)
        {
            string query =
                "SELECT o.OrderId, o.OrderDate, o.TotalAmount, o.OrderStatus, " +
                "       p.PaymentMethod, p.PaymentStatus " +
                "FROM   Orders o LEFT JOIN Payments p ON o.OrderId = p.OrderId " +
                "WHERE  o.CustomerId = @CustomerId " +
                "ORDER  BY o.OrderDate DESC;";

            return sda.ExecuteQuery(query, new SqlParameter("@CustomerId", customerId));
        }

        /// <summary>
        /// Every order in the platform - the Super Admin's view. Joins Users
        /// so the grid shows the customer's name.
        /// </summary>
        public DataTable GetAllOrders(string statusFilter)
        {
            string query =
                "SELECT o.OrderId, u.Name AS CustomerName, u.Phone, " +
                "       o.OrderDate, o.TotalAmount, o.OrderStatus, " +
                "       p.PaymentMethod, p.PaymentStatus " +
                "FROM   Orders o " +
                "       INNER JOIN Users    u ON o.CustomerId = u.UserId " +
                "       LEFT  JOIN Payments p ON o.OrderId    = p.OrderId " +
                "WHERE  (@Status = 'All' OR o.OrderStatus = @Status) " +
                "ORDER  BY o.OrderDate DESC;";

            return sda.ExecuteQuery(query, new SqlParameter("@Status", statusFilter ?? "All"));
        }

        /// <summary>
        /// Orders that contain at least one item from this restaurant - what
        /// the Restaurant Admin and the Employee see.
        ///
        /// SELECT DISTINCT is needed because the join to OrderDetails produces
        /// one row per item; without it an order with three items from this
        /// restaurant would appear three times.
        /// </summary>
        public DataTable GetOrdersByRestaurant(int restaurantId, string statusFilter)
        {
            string query =
                "SELECT DISTINCT o.OrderId, u.Name AS CustomerName, u.Phone, u.Address, " +
                "       o.OrderDate, o.TotalAmount, o.OrderStatus " +
                "FROM   Orders       o " +
                "       INNER JOIN Users        u  ON o.CustomerId = u.UserId " +
                "       INNER JOIN OrderDetails od ON o.OrderId    = od.OrderId " +
                "       INNER JOIN Foods        f  ON od.FoodId    = f.FoodId " +
                "WHERE  f.RestaurantId = @RestaurantId " +
                "  AND  (@Status = 'All' OR o.OrderStatus = @Status) " +
                "ORDER  BY o.OrderDate DESC;";

            return sda.ExecuteQuery(query,
                new SqlParameter("@RestaurantId", restaurantId),
                new SqlParameter("@Status",       statusFilter ?? "All"));
        }

        public Order GetOrderById(int orderId)
        {
            string query =
                "SELECT o.OrderId, o.CustomerId, o.OrderDate, o.TotalAmount, o.OrderStatus, " +
                "       u.Name AS CustomerName, u.Phone, u.Address, " +
                "       p.PaymentMethod, p.PaymentStatus " +
                "FROM   Orders o " +
                "       INNER JOIN Users    u ON o.CustomerId = u.UserId " +
                "       LEFT  JOIN Payments p ON o.OrderId    = p.OrderId " +
                "WHERE  o.OrderId = @OrderId;";

            DataTable table = sda.ExecuteQuery(query, new SqlParameter("@OrderId", orderId));

            if (table.Rows.Count == 0)
                return null;

            DataRow row = table.Rows[0];

            return new Order
            {
                OrderId       = Convert.ToInt32(row["OrderId"]),
                CustomerId    = Convert.ToInt32(row["CustomerId"]),
                OrderDate     = Convert.ToDateTime(row["OrderDate"]),
                TotalAmount   = Convert.ToDecimal(row["TotalAmount"]),
                OrderStatus   = row["OrderStatus"].ToString(),
                CustomerName  = row["CustomerName"].ToString(),
                CustomerPhone = row["Phone"]   == DBNull.Value ? "" : row["Phone"].ToString(),
                Address       = row["Address"] == DBNull.Value ? "" : row["Address"].ToString(),
                PaymentMethod = row["PaymentMethod"] == DBNull.Value ? "" : row["PaymentMethod"].ToString(),
                PaymentStatus = row["PaymentStatus"] == DBNull.Value ? "" : row["PaymentStatus"].ToString()
            };
        }

        /* ==================================================================
           REPORT QUERIES - GROUP BY and aggregates
           ================================================================== */

        /// <summary>
        /// GROUP BY QUERY. Sales per restaurant for the Super Admin.
        ///
        /// Four tables are joined so that an OrderDetails row can be traced
        /// back to the restaurant that sold it. COUNT(DISTINCT o.OrderId) is
        /// used rather than COUNT(*) because the join has already multiplied
        /// each order by its number of items.
        /// </summary>
        public DataTable GetSalesPerRestaurant()
        {
            string query =
                "SELECT r.RestaurantName, " +
                "       COUNT(DISTINCT o.OrderId)   AS TotalOrders, " +
                "       SUM(od.Quantity)            AS ItemsSold, " +
                "       SUM(od.Quantity * od.Price) AS TotalSales " +
                "FROM   Restaurants  r " +
                "       INNER JOIN Foods        f  ON r.RestaurantId = f.RestaurantId " +
                "       INNER JOIN OrderDetails od ON f.FoodId       = od.FoodId " +
                "       INNER JOIN Orders       o  ON od.OrderId     = o.OrderId " +
                "WHERE  o.OrderStatus <> 'Cancelled' " +
                "GROUP  BY r.RestaurantName " +
                "ORDER  BY TotalSales DESC;";

            return sda.ExecuteQuery(query);
        }

        /// <summary>
        /// GROUP BY + HAVING. Best-selling items, for the Restaurant Admin's
        /// report screen. HAVING filters on the aggregate, which is exactly
        /// what WHERE cannot do.
        /// </summary>
        public DataTable GetBestSellingFoods(int restaurantId, int minUnits)
        {
            string query =
                "SELECT f.FoodName, c.CategoryName, " +
                "       SUM(od.Quantity)            AS UnitsSold, " +
                "       SUM(od.Quantity * od.Price) AS Revenue " +
                "FROM   OrderDetails od " +
                "       INNER JOIN Foods      f ON od.FoodId     = f.FoodId " +
                "       INNER JOIN Categories c ON f.CategoryId  = c.CategoryId " +
                "       INNER JOIN Orders     o ON od.OrderId    = o.OrderId " +
                "WHERE  o.OrderStatus <> 'Cancelled' " +
                "  AND  (@RestaurantId = 0 OR f.RestaurantId = @RestaurantId) " +
                "GROUP  BY f.FoodName, c.CategoryName " +
                "HAVING SUM(od.Quantity) >= @MinUnits " +
                "ORDER  BY UnitsSold DESC;";

            return sda.ExecuteQuery(query,
                new SqlParameter("@RestaurantId", restaurantId),
                new SqlParameter("@MinUnits",     minUnits));
        }

        /// <summary>GROUP BY on the status column - the dashboard breakdown.</summary>
        public DataTable GetOrderStatusSummary(int restaurantId)
        {
            string query =
                "SELECT o.OrderStatus, COUNT(DISTINCT o.OrderId) AS TotalOrders, " +
                "       SUM(od.Quantity * od.Price) AS Amount " +
                "FROM   Orders o " +
                "       INNER JOIN OrderDetails od ON o.OrderId = od.OrderId " +
                "       INNER JOIN Foods        f  ON od.FoodId = f.FoodId " +
                "WHERE  (@RestaurantId = 0 OR f.RestaurantId = @RestaurantId) " +
                "GROUP  BY o.OrderStatus;";

            return sda.ExecuteQuery(query, new SqlParameter("@RestaurantId", restaurantId));
        }

        /// <summary>GROUP BY on a date - daily sales, newest first.</summary>
        public DataTable GetDailySales(int restaurantId)
        {
            string query =
                "SELECT CAST(o.OrderDate AS DATE)   AS SaleDate, " +
                "       COUNT(DISTINCT o.OrderId)   AS TotalOrders, " +
                "       SUM(od.Quantity * od.Price) AS TotalSales " +
                "FROM   Orders o " +
                "       INNER JOIN OrderDetails od ON o.OrderId = od.OrderId " +
                "       INNER JOIN Foods        f  ON od.FoodId = f.FoodId " +
                "WHERE  o.OrderStatus <> 'Cancelled' " +
                "  AND  (@RestaurantId = 0 OR f.RestaurantId = @RestaurantId) " +
                "GROUP  BY CAST(o.OrderDate AS DATE) " +
                "ORDER  BY SaleDate DESC;";

            return sda.ExecuteQuery(query, new SqlParameter("@RestaurantId", restaurantId));
        }

        public int GetOrderCount(string status)
        {
            string query =
                "SELECT COUNT(*) FROM Orders WHERE (@Status = 'All' OR OrderStatus = @Status);";

            return Convert.ToInt32(sda.ExecuteScalar(query,
                new SqlParameter("@Status", status ?? "All")));
        }

        public decimal GetTotalRevenue()
        {
            return Convert.ToDecimal(sda.ExecuteScalar(
                "SELECT ISNULL(SUM(TotalAmount), 0) FROM Orders WHERE OrderStatus <> 'Cancelled';"));
        }

        public decimal GetRevenueByRestaurant(int restaurantId)
        {
            string query =
                "SELECT ISNULL(SUM(od.Quantity * od.Price), 0) " +
                "FROM   OrderDetails od " +
                "       INNER JOIN Foods  f ON od.FoodId  = f.FoodId " +
                "       INNER JOIN Orders o ON od.OrderId = o.OrderId " +
                "WHERE  f.RestaurantId = @RestaurantId AND o.OrderStatus <> 'Cancelled';";

            return Convert.ToDecimal(sda.ExecuteScalar(query,
                new SqlParameter("@RestaurantId", restaurantId)));
        }

        /* ==================================================================
           UPDATE
           ================================================================== */

        /// <summary>
        /// The order-status workflow, used by the Employee and the Restaurant
        /// Admin. A finished order cannot be moved again - that rule is in
        /// the WHERE clause, so it holds no matter which screen calls it.
        /// </summary>
        public int UpdateOrderStatus(int orderId, string newStatus)
        {
            string query =
                "UPDATE Orders SET OrderStatus = @Status " +
                "WHERE  OrderId = @OrderId " +
                "  AND  OrderStatus NOT IN ('Completed', 'Cancelled');";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@Status",  newStatus),
                new SqlParameter("@OrderId", orderId));
        }

        /* ==================================================================
           DELETE
           ================================================================== */

        /// <summary>
        /// STATUS BASED DELETE. Cancelling an order keeps the row (and its
        /// OrderDetails) so the sales history stays honest, and the stock is
        /// handed back to the restaurant in the same transaction.
        /// Only an order that has not been cooked yet may be cancelled.
        /// </summary>
        public bool CancelOrder(int orderId, out string message)
        {
            message = string.Empty;

            using (SqlConnection connection = sda.OpenConnection())
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    string status;

                    using (SqlCommand command = new SqlCommand(
                        "SELECT OrderStatus FROM Orders WHERE OrderId = @OrderId;",
                        connection, transaction))
                    {
                        command.Parameters.AddWithValue("@OrderId", orderId);
                        object result = command.ExecuteScalar();

                        if (result == null)
                        {
                            transaction.Rollback();
                            message = "That order no longer exists.";
                            return false;
                        }

                        status = result.ToString();
                    }

                    if (status == "Completed" || status == "Cancelled")
                    {
                        transaction.Rollback();
                        message = "An order that is already " + status + " cannot be cancelled.";
                        return false;
                    }

                    // Put the stock back.
                    string restoreStock =
                        "UPDATE f SET f.Stock = f.Stock + od.Quantity " +
                        "FROM   Foods f INNER JOIN OrderDetails od ON f.FoodId = od.FoodId " +
                        "WHERE  od.OrderId = @OrderId;";

                    using (SqlCommand command = new SqlCommand(restoreStock, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@OrderId", orderId);
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(
                        "UPDATE Orders SET OrderStatus = 'Cancelled' WHERE OrderId = @OrderId;",
                        connection, transaction))
                    {
                        command.Parameters.AddWithValue("@OrderId", orderId);
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(
                        "UPDATE Payments SET PaymentStatus = 'Failed' WHERE OrderId = @OrderId;",
                        connection, transaction))
                    {
                        command.Parameters.AddWithValue("@OrderId", orderId);
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    message = "Order " + orderId + " has been cancelled and the stock returned.";
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Real DELETE, Super Admin only. Child rows must go first because of
        /// the foreign keys: Payments and OrderDetails point at Orders.
        /// </summary>
        public void HardDeleteOrder(int orderId)
        {
            using (SqlConnection connection = sda.OpenConnection())
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    string[] statements =
                    {
                        "DELETE FROM Payments     WHERE OrderId = @OrderId;",
                        "DELETE FROM OrderDetails WHERE OrderId = @OrderId;",
                        "DELETE FROM Orders       WHERE OrderId = @OrderId;"
                    };

                    foreach (string statement in statements)
                    {
                        using (SqlCommand command = new SqlCommand(statement, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@OrderId", orderId);
                            command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
