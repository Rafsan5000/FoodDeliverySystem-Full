using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FoodDeliverySystem.Database;

namespace FoodDeliverySystem.Model
{
    /// <summary>
    /// Data-access class for the Restaurants table. This table is new: the
    /// original project assumed a single restaurant, so food items had no
    /// owner. Adding it is what turns the app into a delivery platform.
    /// </summary>
    public class Restaurants
    {
        private readonly SqlDbDataAccess sda = new SqlDbDataAccess();

        /* ---------------- CREATE ---------------- */

        public int AddRestaurant(Restaurant restaurant)
        {
            string query =
                "INSERT INTO Restaurants (OwnerId, RestaurantName, Address, Phone, Status) " +
                "VALUES (@OwnerId, @RestaurantName, @Address, @Phone, @Status); " +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            object result = sda.ExecuteScalar(query,
                new SqlParameter("@OwnerId",        restaurant.OwnerId),
                new SqlParameter("@RestaurantName", restaurant.RestaurantName),
                new SqlParameter("@Address",        (object)restaurant.Address ?? DBNull.Value),
                new SqlParameter("@Phone",          (object)restaurant.Phone   ?? DBNull.Value),
                new SqlParameter("@Status",         restaurant.Status));

            return Convert.ToInt32(result);
        }

        /* ---------------- READ ---------------- */

        /// <summary>
        /// JOIN QUERY. Restaurants stores only OwnerId, so the join to Users
        /// turns that number into a readable owner name for the grid.
        /// </summary>
        public DataTable GetAllRestaurants()
        {
            string query =
                "SELECT r.RestaurantId, r.RestaurantName, u.Name AS OwnerName, " +
                "       r.Address, r.Phone, r.Status " +
                "FROM   Restaurants r INNER JOIN Users u ON r.OwnerId = u.UserId " +
                "ORDER BY r.RestaurantId;";

            return sda.ExecuteQuery(query);
        }

        /// <summary>
        /// Looks up the restaurant belonging to the logged-in Restaurant
        /// Admin. Called right after login so Session.CurrentRestaurantId can
        /// be filled in.
        /// </summary>
        public Restaurant GetRestaurantByOwner(int ownerId)
        {
            string query =
                "SELECT RestaurantId, OwnerId, RestaurantName, Address, Phone, Status " +
                "FROM   Restaurants WHERE OwnerId = @OwnerId;";

            DataTable table = sda.ExecuteQuery(query, new SqlParameter("@OwnerId", ownerId));

            return table.Rows.Count == 0 ? null : MapRow(table.Rows[0]);
        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            string query =
                "SELECT RestaurantId, OwnerId, RestaurantName, Address, Phone, Status " +
                "FROM   Restaurants WHERE RestaurantId = @RestaurantId;";

            DataTable table = sda.ExecuteQuery(query,
                new SqlParameter("@RestaurantId", restaurantId));

            return table.Rows.Count == 0 ? null : MapRow(table.Rows[0]);
        }

        public List<Restaurant> GetActiveRestaurants()
        {
            string query =
                "SELECT RestaurantId, OwnerId, RestaurantName, Address, Phone, Status " +
                "FROM   Restaurants WHERE Status = 'Active' ORDER BY RestaurantName;";

            DataTable table = sda.ExecuteQuery(query);
            List<Restaurant> list = new List<Restaurant>();

            foreach (DataRow row in table.Rows)
                list.Add(MapRow(row));

            return list;
        }

        public int GetRestaurantCount()
        {
            return Convert.ToInt32(
                sda.ExecuteScalar("SELECT COUNT(*) FROM Restaurants WHERE Status = 'Active';"));
        }

        /* ---------------- UPDATE ---------------- */

        public int UpdateRestaurant(Restaurant restaurant)
        {
            string query =
                "UPDATE Restaurants " +
                "SET    RestaurantName = @RestaurantName, Address = @Address, Phone = @Phone " +
                "WHERE  RestaurantId = @RestaurantId;";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@RestaurantName", restaurant.RestaurantName),
                new SqlParameter("@Address",        (object)restaurant.Address ?? DBNull.Value),
                new SqlParameter("@Phone",          (object)restaurant.Phone   ?? DBNull.Value),
                new SqlParameter("@RestaurantId",   restaurant.RestaurantId));
        }

        /// <summary>Super Admin approves or suspends a restaurant.</summary>
        public int UpdateStatus(int restaurantId, string status)
        {
            string query = "UPDATE Restaurants SET Status = @Status WHERE RestaurantId = @RestaurantId;";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@Status",       status),
                new SqlParameter("@RestaurantId", restaurantId));
        }

        /* ---------------- DELETE ---------------- */

        /// <summary>
        /// STATUS BASED DELETE. Setting the restaurant to 'Inactive' hides its
        /// whole menu from customers in one step, because every customer food
        /// query has "AND r.Status = 'Active'" in its WHERE clause.
        /// </summary>
        public int DeleteRestaurant(int restaurantId)
        {
            string query = "UPDATE Restaurants SET Status = 'Inactive' WHERE RestaurantId = @RestaurantId;";

            return sda.ExecuteNonQuery(query, new SqlParameter("@RestaurantId", restaurantId));
        }

        /* ---------------- HELPERS ---------------- */

        private Restaurant MapRow(DataRow row)
        {
            return new Restaurant
            {
                RestaurantId   = Convert.ToInt32(row["RestaurantId"]),
                OwnerId        = Convert.ToInt32(row["OwnerId"]),
                RestaurantName = row["RestaurantName"].ToString(),
                Address        = row["Address"] == DBNull.Value ? "" : row["Address"].ToString(),
                Phone          = row["Phone"]   == DBNull.Value ? "" : row["Phone"].ToString(),
                Status         = row["Status"].ToString()
            };
        }
    }
}
