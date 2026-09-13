using System.Collections.Generic;
using System.Data;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.Controller
{
    /// <summary>
    /// Controller for food categories. Only the Super Admin edits these; the
    /// other roles just read the list to fill their combo boxes.
    /// </summary>
    public class CategoryController
    {
        private readonly Categories categories = new Categories();

        /* ---------------- CREATE ---------------- */

        public bool AddCategory(string categoryName, out string message)
        {
            message = string.Empty;

            categoryName = categoryName.Trim();

            if (categories.CategoryExists(categoryName, 0))
            {
                message = "A category called '" + categoryName + "' already exists.";
                return false;
            }

            categories.AddCategory(new Category
            {
                CategoryName = categoryName,
                Status       = "Active"
            });

            message = "Category '" + categoryName + "' added.";
            return true;
        }

        /* ---------------- READ ---------------- */

        public DataTable GetCategoriesWithCount()
        {
            return categories.GetCategoriesWithFoodCount();
        }

        public DataTable GetAllCategories()
        {
            return categories.GetAllCategories();
        }

        /// <summary>
        /// Fills a ComboBox. An "All categories" entry with id 0 is added at
        /// the top, which is what makes the FilterFood "0 means ignore"
        /// pattern work from the UI.
        /// </summary>
        public List<Category> GetCategoriesForFilter()
        {
            List<Category> list = new List<Category>();
            list.Add(new Category(0, "All categories"));
            list.AddRange(categories.GetActiveCategories());
            return list;
        }

        public List<Category> GetActiveCategories()
        {
            return categories.GetActiveCategories();
        }

        /* ---------------- UPDATE ---------------- */

        public bool UpdateCategory(Category category, out string message)
        {
            message = string.Empty;

            if (categories.CategoryExists(category.CategoryName, category.CategoryId))
            {
                message = "Another category already uses that name.";
                return false;
            }

            categories.UpdateCategory(category);
            message = "Category updated.";
            return true;
        }

        /* ---------------- DELETE ---------------- */

        public bool DeleteCategory(int categoryId, out string message)
        {
            if (categories.HardDeleteCategory(categoryId))
            {
                message = "Category deleted (no food was using it).";
                return true;
            }

            categories.DeleteCategory(categoryId);
            message = "Food items still use this category, so it was set to " +
                      "Inactive instead. It will no longer appear in dropdowns.";
            return true;
        }
    }
}
