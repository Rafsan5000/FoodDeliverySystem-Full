using System.Data;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.Controller
{
    /// <summary>
    /// Controller for the Foods CRUD, stock and browse screens.
    /// Same class name as the original project's FoodController.
    ///
    /// Notice that the restaurant id is never taken from the form. It comes
    /// from Session, so a Restaurant Admin can only ever act on their own
    /// menu even if the UI were tampered with.
    /// </summary>
    public class FoodController
    {
        private readonly Foods foods = new Foods();

        /* ---------------- CREATE ---------------- */

        public bool AddFood(Food food, out string message)
        {
            message = string.Empty;

            food.RestaurantId = Session.CurrentRestaurantId;

            if (foods.FoodNameExists(food.RestaurantId, food.FoodName, 0))
            {
                message = "Your menu already has an item called '" + food.FoodName + "'.";
                return false;
            }

            food.Status = food.Stock > 0 ? "Available" : "Unavailable";

            int newId = foods.AddFood(food);

            message = "Food added with id " + newId + ".";
            return true;
        }

        /* ---------------- READ ---------------- */

        public DataTable GetMyMenu()
        {
            return foods.GetFoodsByRestaurant(Session.CurrentRestaurantId);
        }

        public DataTable GetAllFoods()
        {
            return foods.GetAllFoods();
        }

        public DataTable GetAvailableFoods()
        {
            return foods.GetAvailableFoods();
        }

        public Food GetFoodById(int foodId)
        {
            return foods.GetFoodById(foodId);
        }

        /// <summary>SEARCH - wired to the Search button on the browse screen.</summary>
        public DataTable SearchFood(string keyword)
        {
            return foods.SearchFood(keyword);
        }

        /// <summary>FILTER - wired to the category / price / in-stock controls.</summary>
        public DataTable FilterFood(int categoryId, decimal minPrice, decimal maxPrice,
                                    bool inStockOnly, string keyword)
        {
            // Guard against a reversed range typed by the user.
            if (maxPrice < minPrice)
            {
                decimal swap = minPrice;
                minPrice = maxPrice;
                maxPrice = swap;
            }

            return foods.FilterFood(categoryId, minPrice, maxPrice, inStockOnly, keyword);
        }

        public DataTable GetLowStock(int threshold)
        {
            return foods.GetLowStock(Session.CurrentRestaurantId, threshold);
        }

        public int CountMyFoods()
        {
            return foods.GetFoodCountByRestaurant(Session.CurrentRestaurantId);
        }

        public int CountAllFoods()
        {
            return foods.GetFoodCount();
        }

        /* ---------------- UPDATE ---------------- */

        public bool UpdateFood(Food food, out string message)
        {
            message = string.Empty;

            food.RestaurantId = Session.CurrentRestaurantId;

            if (foods.FoodNameExists(food.RestaurantId, food.FoodName, food.FoodId))
            {
                message = "Another item on your menu already has that name.";
                return false;
            }

            // Keep Status and Stock consistent - an item with no stock cannot
            // be "Available", whatever the form says.
            if (food.Stock == 0)
                food.Status = "Unavailable";

            int rows = foods.UpdateFood(food);

            if (rows == 0)
            {
                message = "That item does not belong to your restaurant.";
                return false;
            }

            message = "Food updated.";
            return true;
        }

        /// <summary>Stock management: restock an item.</summary>
        public bool AddStock(int foodId, int quantity, out string message)
        {
            message = string.Empty;

            if (quantity <= 0)
            {
                message = "Enter a quantity greater than zero.";
                return false;
            }

            Food food = foods.GetFoodById(foodId);

            if (food == null || food.RestaurantId != Session.CurrentRestaurantId)
            {
                message = "That item is not on your menu.";
                return false;
            }

            foods.AddStock(foodId, quantity);

            message = quantity + " added to '" + food.FoodName + "'. " +
                      "New stock: " + (food.Stock + quantity) + ".";
            return true;
        }

        /* ---------------- DELETE ---------------- */

        public bool DeleteFood(int foodId, out string message)
        {
            if (foods.HardDeleteFood(foodId))
            {
                message = "Food deleted (it was never ordered).";
                return true;
            }

            foods.DeleteFood(foodId, Session.CurrentRestaurantId);
            message = "This item appears in past orders, so it was marked " +
                      "Unavailable instead of deleted. Customers can no longer see it.";
            return true;
        }

        public bool RestoreFood(int foodId, out string message)
        {
            foods.RestoreFood(foodId, Session.CurrentRestaurantId);
            message = "Food is back on the menu.";
            return true;
        }
    }
}
