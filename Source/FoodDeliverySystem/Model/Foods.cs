using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FoodDeliverySystem.Database;

namespace FoodDeliverySystem.Model
{
    /// <summary>
    /// Data-access class for the Foods table. Upgraded from the original
    /// Foods class: every SELECT now joins Restaurants and Categories so the
    /// grids can show names instead of ID numbers, and search / filter /
    /// low-stock queries have been added.
    /// </summary>
    public class Foods
    {
        private readonly SqlDbDataAccess sda = new SqlDbDataAccess();

        /// <summary>
        /// The SELECT list is written once here and reused by every read
        /// method below, so the column names in the grid never drift apart
        /// between screens.
        /// </summary>
        private const string SelectBase =
            "SELECT f.FoodId, f.RestaurantId, f.CategoryId, f.FoodName, f.Description, " +
            "       f.Price, f.Stock, f.Status, " +
            "       c.CategoryName, r.RestaurantName " +
            "FROM   Foods f " +
            "       INNER JOIN Categories  c ON f.CategoryId   = c.CategoryId " +
            "       INNER JOIN Restaurants r ON f.RestaurantId = r.RestaurantId ";

        /* ==================================================================
           CREATE
           ================================================================== */

        public int AddFood(Food food)
        {
            string query =
                "INSERT INTO Foods (RestaurantId, CategoryId, FoodName, Description, Price, Stock, Status) " +
                "VALUES (@RestaurantId, @CategoryId, @FoodName, @Description, @Price, @Stock, @Status); " +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            object result = sda.ExecuteScalar(query,
                new SqlParameter("@RestaurantId", food.RestaurantId),
                new SqlParameter("@CategoryId",   food.CategoryId),
                new SqlParameter("@FoodName",     food.FoodName),
                new SqlParameter("@Description",  (object)food.Description ?? DBNull.Value),
                new SqlParameter("@Price",        food.Price),
                new SqlParameter("@Stock",        food.Stock),
                new SqlParameter("@Status",       food.Status));

            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Duplicate checking: the same restaurant may not list the same food
        /// name twice. A different restaurant may, which is why RestaurantId
        /// is part of the WHERE clause.
        /// The @ExcludeId parameter lets the Update screen reuse this method -
        /// a row is allowed to keep its own name.
        /// </summary>
        public bool FoodNameExists(int restaurantId, string foodName, int excludeFoodId)
        {
            string query =
                "SELECT COUNT(*) FROM Foods " +
                "WHERE  RestaurantId = @RestaurantId " +
                "  AND  FoodName     = @FoodName " +
                "  AND  FoodId      <> @ExcludeId;";

            object result = sda.ExecuteScalar(query,
                new SqlParameter("@RestaurantId", restaurantId),
                new SqlParameter("@FoodName",     foodName),
                new SqlParameter("@ExcludeId",    excludeFoodId));

            return Convert.ToInt32(result) > 0;
        }

        /* ==================================================================
           READ
           ================================================================== */

        public Food GetFoodById(int foodId)
        {
            DataTable table = sda.ExecuteQuery(SelectBase + "WHERE f.FoodId = @FoodId;",
                new SqlParameter("@FoodId", foodId));

            return table.Rows.Count == 0 ? null : MapRow(table.Rows[0]);
        }

        /// <summary>Every food in the system - the Super Admin's view.</summary>
        public DataTable GetAllFoods()
        {
            return sda.ExecuteQuery(SelectBase + "ORDER BY f.FoodId;");
        }

        /// <summary>
        /// One restaurant's menu. This single WHERE clause is the whole of
        /// data isolation between restaurants: a Restaurant Admin only ever
        /// passes their own Session.CurrentRestaurantId, so they physically
        /// cannot load another restaurant's rows.
        /// </summary>
        public DataTable GetFoodsByRestaurant(int restaurantId)
        {
            return sda.ExecuteQuery(SelectBase + "WHERE f.RestaurantId = @RestaurantId ORDER BY f.FoodId;",
                new SqlParameter("@RestaurantId", restaurantId));
        }

        public List<Food> GetFoodListByRestaurant(int restaurantId)
        {
            DataTable table = GetFoodsByRestaurant(restaurantId);
            List<Food> list = new List<Food>();

            foreach (DataRow row in table.Rows)
                list.Add(MapRow(row));

            return list;
        }

        /// <summary>
        /// SEARCH QUERY. The keyword is a parameter and the % wildcards are
        /// added by SQL Server with the + operator, never by C# string
        /// concatenation. That keeps it safe from SQL injection.
        /// </summary>
        public DataTable SearchFood(string keyword)
        {
            string query = SelectBase +
                "WHERE  f.Status   = 'Available' " +
                "  AND  r.Status   = 'Active' " +
                "  AND  (f.FoodName    LIKE '%' + @Keyword + '%' " +
                "    OR  f.Description LIKE '%' + @Keyword + '%' " +
                "    OR  r.RestaurantName LIKE '%' + @Keyword + '%') " +
                "ORDER BY f.FoodName;";

            return sda.ExecuteQuery(query, new SqlParameter("@Keyword", keyword ?? string.Empty));
        }

        /// <summary>
        /// FILTER QUERY for the customer's browse screen. Category, price
        /// range and in-stock-only are combined into one statement using the
        /// same "0 means ignore this filter" idea as SearchUsers.
        /// </summary>
        public DataTable FilterFood(int categoryId, decimal minPrice, decimal maxPrice,
                                    bool inStockOnly, string keyword)
        {
            string query = SelectBase +
                "WHERE  f.Status = 'Available' " +
                "  AND  r.Status = 'Active' " +
                "  AND  (@CategoryId = 0 OR f.CategoryId = @CategoryId) " +
                "  AND  f.Price BETWEEN @MinPrice AND @MaxPrice " +
                "  AND  (@InStockOnly = 0 OR f.Stock > 0) " +
                "  AND  (@Keyword = '' OR f.FoodName LIKE '%' + @Keyword + '%') " +
                "ORDER BY f.Price;";

            return sda.ExecuteQuery(query,
                new SqlParameter("@CategoryId",  categoryId),
                new SqlParameter("@MinPrice",    minPrice),
                new SqlParameter("@MaxPrice",    maxPrice),
                new SqlParameter("@InStockOnly", inStockOnly ? 1 : 0),
                new SqlParameter("@Keyword",     keyword ?? string.Empty));
        }

        /// <summary>Browse screen default: everything a customer may order.</summary>
        public DataTable GetAvailableFoods()
        {
            return sda.ExecuteQuery(SelectBase +
                "WHERE f.Status = 'Available' AND r.Status = 'Active' ORDER BY r.RestaurantName, f.FoodName;");
        }

        /// <summary>
        /// LOW STOCK report for the Restaurant Admin's stock screen.
        /// </summary>
        public DataTable GetLowStock(int restaurantId, int threshold)
        {
            string query =
                "SELECT f.FoodId, f.FoodName, f.Stock, f.Price, c.CategoryName " +
                "FROM   Foods f INNER JOIN Categories c ON f.CategoryId = c.CategoryId " +
                "WHERE  f.RestaurantId = @RestaurantId AND f.Stock <= @Threshold " +
                "ORDER BY f.Stock;";

            return sda.ExecuteQuery(query,
                new SqlParameter("@RestaurantId", restaurantId),
                new SqlParameter("@Threshold",    threshold));
        }

        public int GetFoodCount()
        {
            return Convert.ToInt32(
                sda.ExecuteScalar("SELECT COUNT(*) FROM Foods WHERE Status = 'Available';"));
        }

        public int GetFoodCountByRestaurant(int restaurantId)
        {
            return Convert.ToInt32(sda.ExecuteScalar(
                "SELECT COUNT(*) FROM Foods WHERE RestaurantId = @RestaurantId;",
                new SqlParameter("@RestaurantId", restaurantId)));
        }

        /* ==================================================================
           UPDATE
           ================================================================== */

        public int UpdateFood(Food food)
        {
            string query =
                "UPDATE Foods " +
                "SET    CategoryId  = @CategoryId, " +
                "       FoodName    = @FoodName, " +
                "       Description = @Description, " +
                "       Price       = @Price, " +
                "       Stock       = @Stock, " +
                "       Status      = @Status " +
                "WHERE  FoodId = @FoodId AND RestaurantId = @RestaurantId;";

            // RestaurantId is in the WHERE clause as well as FoodId. Even if a
            // wrong FoodId were somehow passed, one restaurant can never edit
            // another restaurant's row.
            return sda.ExecuteNonQuery(query,
                new SqlParameter("@CategoryId",   food.CategoryId),
                new SqlParameter("@FoodName",     food.FoodName),
                new SqlParameter("@Description",  (object)food.Description ?? DBNull.Value),
                new SqlParameter("@Price",        food.Price),
                new SqlParameter("@Stock",        food.Stock),
                new SqlParameter("@Status",       food.Status),
                new SqlParameter("@FoodId",       food.FoodId),
                new SqlParameter("@RestaurantId", food.RestaurantId));
        }

        /// <summary>Stock management: add newly cooked / delivered stock.</summary>
        public int AddStock(int foodId, int quantity)
        {
            string query =
                "UPDATE Foods SET Stock = Stock + @Quantity, " +
                "       Status = CASE WHEN Stock + @Quantity > 0 THEN 'Available' ELSE Status END " +
                "WHERE  FoodId = @FoodId;";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@Quantity", quantity),
                new SqlParameter("@FoodId",   foodId));
        }

        /// <summary>
        /// Called during checkout, inside the order transaction.
        ///
        /// The "AND Stock >= @Quantity" is the important part: if two
        /// customers check out the last item at the same moment, the second
        /// UPDATE matches no rows and returns 0, so the code knows to stop.
        /// The database, not the C# code, decides who got the last item.
        /// </summary>
        public bool DecreaseStock(SqlConnection connection, SqlTransaction transaction,
                                  int foodId, int quantity)
        {
            string query =
                "UPDATE Foods SET Stock = Stock - @Quantity " +
                "WHERE  FoodId = @FoodId AND Stock >= @Quantity;";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@FoodId",   foodId);

                return command.ExecuteNonQuery() == 1;
            }
        }

        /* ==================================================================
           DELETE
           ================================================================== */

        /// <summary>
        /// STATUS BASED DELETE. A food item that appears in OrderDetails can
        /// never be removed without losing order history, so it is marked
        /// 'Unavailable' instead. It disappears from the customer's browse
        /// screen because every customer query filters on Status.
        /// </summary>
        public int DeleteFood(int foodId, int restaurantId)
        {
            string query =
                "UPDATE Foods SET Status = 'Unavailable' " +
                "WHERE  FoodId = @FoodId AND RestaurantId = @RestaurantId;";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@FoodId",       foodId),
                new SqlParameter("@RestaurantId", restaurantId));
        }

        /// <summary>Puts a previously removed item back on the menu.</summary>
        public int RestoreFood(int foodId, int restaurantId)
        {
            string query =
                "UPDATE Foods SET Status = 'Available' " +
                "WHERE  FoodId = @FoodId AND RestaurantId = @RestaurantId;";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@FoodId",       foodId),
                new SqlParameter("@RestaurantId", restaurantId));
        }

        /// <summary>
        /// Real DELETE, allowed only when the item was never ordered and is
        /// not sitting in anybody's cart.
        /// </summary>
        public bool HardDeleteFood(int foodId)
        {
            string check =
                "SELECT (SELECT COUNT(*) FROM OrderDetails WHERE FoodId = @FoodId) + " +
                "       (SELECT COUNT(*) FROM Cart         WHERE FoodId = @FoodId);";

            int references = Convert.ToInt32(
                sda.ExecuteScalar(check, new SqlParameter("@FoodId", foodId)));

            if (references > 0)
                return false;

            sda.ExecuteNonQuery("DELETE FROM Foods WHERE FoodId = @FoodId;",
                new SqlParameter("@FoodId", foodId));

            return true;
        }

        /* ==================================================================
           HELPERS
           ================================================================== */

        private Food MapRow(DataRow row)
        {
            return new Food
            {
                FoodId         = Convert.ToInt32(row["FoodId"]),
                RestaurantId   = Convert.ToInt32(row["RestaurantId"]),
                CategoryId     = Convert.ToInt32(row["CategoryId"]),
                FoodName       = row["FoodName"].ToString(),
                Description    = row["Description"] == DBNull.Value ? "" : row["Description"].ToString(),
                Price          = Convert.ToDecimal(row["Price"]),
                Stock          = Convert.ToInt32(row["Stock"]),
                Status         = row["Status"].ToString(),
                CategoryName   = row["CategoryName"].ToString(),
                RestaurantName = row["RestaurantName"].ToString()
            };
        }
    }
}
