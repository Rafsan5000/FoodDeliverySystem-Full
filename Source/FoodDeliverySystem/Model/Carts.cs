using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FoodDeliverySystem.Database;

namespace FoodDeliverySystem.Model
{
    /// <summary>
    /// Data-access class for the Cart table. Completely new - the original
    /// project jumped straight from the food list to an order, so a customer
    /// could not collect several items before paying.
    /// </summary>
    public class Carts
    {
        private readonly SqlDbDataAccess sda = new SqlDbDataAccess();

        /* ---------------- CREATE / UPDATE ---------------- */

        /// <summary>
        /// Add to cart. If the customer already has that food in their cart
        /// we increase the quantity instead of inserting a second row, which
        /// is what the UQ_Cart_Cust_Food UNIQUE constraint requires.
        ///
        /// The IF EXISTS ... ELSE runs inside SQL Server as one statement, so
        /// there is no gap between the check and the write.
        /// </summary>
        public int AddOrUpdate(int customerId, int foodId, int quantity)
        {
            string query =
                "IF EXISTS (SELECT 1 FROM Cart WHERE CustomerId = @CustomerId AND FoodId = @FoodId) " +
                "    UPDATE Cart SET Quantity = Quantity + @Quantity " +
                "    WHERE  CustomerId = @CustomerId AND FoodId = @FoodId; " +
                "ELSE " +
                "    INSERT INTO Cart (CustomerId, FoodId, Quantity, AddedDate) " +
                "    VALUES (@CustomerId, @FoodId, @Quantity, GETDATE());";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@CustomerId", customerId),
                new SqlParameter("@FoodId",     foodId),
                new SqlParameter("@Quantity",   quantity));
        }

        public int UpdateQuantity(int cartId, int quantity)
        {
            string query = "UPDATE Cart SET Quantity = @Quantity WHERE CartId = @CartId;";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@Quantity", quantity),
                new SqlParameter("@CartId",   cartId));
        }

        /* ---------------- READ ---------------- */

        /// <summary>
        /// JOIN QUERY that builds the cart screen. Cart itself stores only
        /// FoodId and Quantity; the price and the name come from Foods, and
        /// the subtotal is worked out by SQL Server.
        /// </summary>
        public DataTable GetCartByCustomer(int customerId)
        {
            string query =
                "SELECT ct.CartId, ct.FoodId, f.FoodName, r.RestaurantName, " +
                "       f.Price, ct.Quantity, f.Stock, " +
                "       (ct.Quantity * f.Price) AS Subtotal " +
                "FROM   Cart ct " +
                "       INNER JOIN Foods       f ON ct.FoodId       = f.FoodId " +
                "       INNER JOIN Restaurants r ON f.RestaurantId  = r.RestaurantId " +
                "WHERE  ct.CustomerId = @CustomerId " +
                "ORDER  BY ct.CartId;";

            return sda.ExecuteQuery(query, new SqlParameter("@CustomerId", customerId));
        }

        public List<CartItem> GetCartItems(int customerId)
        {
            DataTable table = GetCartByCustomer(customerId);
            List<CartItem> list = new List<CartItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new CartItem
                {
                    CartId         = Convert.ToInt32(row["CartId"]),
                    CustomerId     = customerId,
                    FoodId         = Convert.ToInt32(row["FoodId"]),
                    FoodName       = row["FoodName"].ToString(),
                    RestaurantName = row["RestaurantName"].ToString(),
                    Price          = Convert.ToDecimal(row["Price"]),
                    Quantity       = Convert.ToInt32(row["Quantity"]),
                    Stock          = Convert.ToInt32(row["Stock"])
                });
            }

            return list;
        }

        /// <summary>
        /// Aggregate query for the cart total. ISNULL turns the NULL that SUM
        /// returns for an empty cart into 0, so the UI never shows a blank.
        /// </summary>
        public decimal GetCartTotal(int customerId)
        {
            string query =
                "SELECT ISNULL(SUM(ct.Quantity * f.Price), 0) " +
                "FROM   Cart ct INNER JOIN Foods f ON ct.FoodId = f.FoodId " +
                "WHERE  ct.CustomerId = @CustomerId;";

            return Convert.ToDecimal(sda.ExecuteScalar(query,
                new SqlParameter("@CustomerId", customerId)));
        }

        public int GetCartCount(int customerId)
        {
            return Convert.ToInt32(sda.ExecuteScalar(
                "SELECT COUNT(*) FROM Cart WHERE CustomerId = @CustomerId;",
                new SqlParameter("@CustomerId", customerId)));
        }

        /* ---------------- DELETE ---------------- */

        /// <summary>
        /// A real DELETE is correct here. The cart is working data, nothing
        /// references it, and once the order is placed the rows have no
        /// historical value - OrderDetails is the permanent record.
        /// </summary>
        public int RemoveItem(int cartId)
        {
            return sda.ExecuteNonQuery("DELETE FROM Cart WHERE CartId = @CartId;",
                new SqlParameter("@CartId", cartId));
        }

        public int ClearCart(int customerId)
        {
            return sda.ExecuteNonQuery("DELETE FROM Cart WHERE CustomerId = @CustomerId;",
                new SqlParameter("@CustomerId", customerId));
        }

        /// <summary>Overload used inside the checkout transaction.</summary>
        public void ClearCart(SqlConnection connection, SqlTransaction transaction, int customerId)
        {
            using (SqlCommand command = new SqlCommand(
                "DELETE FROM Cart WHERE CustomerId = @CustomerId;", connection, transaction))
            {
                command.Parameters.AddWithValue("@CustomerId", customerId);
                command.ExecuteNonQuery();
            }
        }
    }
}
