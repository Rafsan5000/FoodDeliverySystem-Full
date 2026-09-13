using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FoodDeliverySystem.Database;

namespace FoodDeliverySystem.Model
{
    /// <summary>
    /// Data-access class for the Categories table. Categories are owned by
    /// the Super Admin so every restaurant chooses from the same controlled
    /// list, which is what makes "filter by category" work across the whole
    /// platform.
    /// </summary>
    public class Categories
    {
        private readonly SqlDbDataAccess sda = new SqlDbDataAccess();

        /* ---------------- CREATE ---------------- */

        public int AddCategory(Category category)
        {
            string query =
                "INSERT INTO Categories (CategoryName, Status) VALUES (@CategoryName, @Status); " +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            return Convert.ToInt32(sda.ExecuteScalar(query,
                new SqlParameter("@CategoryName", category.CategoryName),
                new SqlParameter("@Status",       category.Status)));
        }

        /// <summary>Duplicate checking before the UQ_Categories_Name constraint fires.</summary>
        public bool CategoryExists(string categoryName, int excludeId)
        {
            string query =
                "SELECT COUNT(*) FROM Categories " +
                "WHERE  CategoryName = @CategoryName AND CategoryId <> @ExcludeId;";

            return Convert.ToInt32(sda.ExecuteScalar(query,
                new SqlParameter("@CategoryName", categoryName),
                new SqlParameter("@ExcludeId",    excludeId))) > 0;
        }

        /* ---------------- READ ---------------- */

        /// <summary>
        /// GROUP BY query. A LEFT JOIN is used so a category with no food yet
        /// still appears with a count of zero; an INNER JOIN would hide it.
        /// </summary>
        public DataTable GetCategoriesWithFoodCount()
        {
            string query =
                "SELECT c.CategoryId, c.CategoryName, c.Status, " +
                "       COUNT(f.FoodId) AS TotalFoods " +
                "FROM   Categories c LEFT JOIN Foods f ON c.CategoryId = f.CategoryId " +
                "GROUP  BY c.CategoryId, c.CategoryName, c.Status " +
                "ORDER  BY c.CategoryId;";

            return sda.ExecuteQuery(query);
        }

        public DataTable GetAllCategories()
        {
            return sda.ExecuteQuery(
                "SELECT CategoryId, CategoryName, Status FROM Categories ORDER BY CategoryId;");
        }

        /// <summary>Fills the category ComboBox on the food screens.</summary>
        public List<Category> GetActiveCategories()
        {
            string query =
                "SELECT CategoryId, CategoryName, Status FROM Categories " +
                "WHERE  Status = 'Active' ORDER BY CategoryName;";

            DataTable table = sda.ExecuteQuery(query);
            List<Category> list = new List<Category>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new Category
                {
                    CategoryId   = Convert.ToInt32(row["CategoryId"]),
                    CategoryName = row["CategoryName"].ToString(),
                    Status       = row["Status"].ToString()
                });
            }

            return list;
        }

        /* ---------------- UPDATE ---------------- */

        public int UpdateCategory(Category category)
        {
            string query =
                "UPDATE Categories SET CategoryName = @CategoryName, Status = @Status " +
                "WHERE  CategoryId = @CategoryId;";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@CategoryName", category.CategoryName),
                new SqlParameter("@Status",       category.Status),
                new SqlParameter("@CategoryId",   category.CategoryId));
        }

        /* ---------------- DELETE ---------------- */

        /// <summary>
        /// STATUS BASED DELETE. Foods.CategoryId points here, so deleting the
        /// row would break the foreign key. Marking it Inactive removes it
        /// from the dropdowns while existing food items keep their category.
        /// </summary>
        public int DeleteCategory(int categoryId)
        {
            return sda.ExecuteNonQuery(
                "UPDATE Categories SET Status = 'Inactive' WHERE CategoryId = @CategoryId;",
                new SqlParameter("@CategoryId", categoryId));
        }

        /// <summary>Real DELETE, only when no food uses the category.</summary>
        public bool HardDeleteCategory(int categoryId)
        {
            int used = Convert.ToInt32(sda.ExecuteScalar(
                "SELECT COUNT(*) FROM Foods WHERE CategoryId = @CategoryId;",
                new SqlParameter("@CategoryId", categoryId)));

            if (used > 0)
                return false;

            sda.ExecuteNonQuery("DELETE FROM Categories WHERE CategoryId = @CategoryId;",
                new SqlParameter("@CategoryId", categoryId));

            return true;
        }
    }
}
