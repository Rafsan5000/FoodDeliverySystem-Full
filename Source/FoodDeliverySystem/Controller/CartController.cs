using System.Collections.Generic;
using System.Data;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.Controller
{
    /// <summary>
    /// Controller for the shopping cart. All the "can I add this?" rules live
    /// here so both the browse screen and the cart screen behave the same.
    /// </summary>
    public class CartController
    {
        private readonly Carts carts = new Carts();
        private readonly Foods foods = new Foods();

        /* ---------------- CREATE ---------------- */

        public bool AddToCart(int foodId, int quantity, out string message)
        {
            message = string.Empty;

            if (quantity <= 0)
            {
                message = "Quantity must be at least 1.";
                return false;
            }

            Food food = foods.GetFoodById(foodId);

            if (food == null)
            {
                message = "That food item no longer exists.";
                return false;
            }

            // Business rule expressed on the entity itself.
            if (!food.IsOrderable)
            {
                message = "'" + food.FoodName + "' is not available right now.";
                return false;
            }

            if (quantity > food.Stock)
            {
                message = "Only " + food.Stock + " of '" + food.FoodName + "' are left.";
                return false;
            }

            carts.AddOrUpdate(Session.UserId, foodId, quantity);

            message = quantity + " x " + food.FoodName + " added to your cart.";
            return true;
        }

        /* ---------------- READ ---------------- */

        public DataTable GetMyCart()
        {
            return carts.GetCartByCustomer(Session.UserId);
        }

        public List<CartItem> GetMyCartItems()
        {
            return carts.GetCartItems(Session.UserId);
        }

        public decimal GetMyCartTotal()
        {
            return carts.GetCartTotal(Session.UserId);
        }

        public int GetMyCartCount()
        {
            return carts.GetCartCount(Session.UserId);
        }

        /* ---------------- UPDATE ---------------- */

        public bool UpdateQuantity(int cartId, int foodId, int quantity, out string message)
        {
            message = string.Empty;

            if (quantity <= 0)
            {
                message = "Quantity must be at least 1. Use Remove to take the item out.";
                return false;
            }

            Food food = foods.GetFoodById(foodId);

            if (food != null && quantity > food.Stock)
            {
                message = "Only " + food.Stock + " left in stock.";
                return false;
            }

            carts.UpdateQuantity(cartId, quantity);
            message = "Quantity updated.";
            return true;
        }

        /* ---------------- DELETE ---------------- */

        public bool RemoveItem(int cartId, out string message)
        {
            carts.RemoveItem(cartId);
            message = "Item removed from your cart.";
            return true;
        }

        public bool ClearCart(out string message)
        {
            carts.ClearCart(Session.UserId);
            message = "Cart cleared.";
            return true;
        }
    }
}
