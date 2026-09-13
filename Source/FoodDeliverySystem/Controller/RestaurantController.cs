using System.Collections.Generic;
using System.Data;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.Controller
{
    /// <summary>
    /// Controller for restaurant profiles. The Super Admin creates and
    /// suspends restaurants; the Restaurant Admin edits only their own.
    /// </summary>
    public class RestaurantController
    {
        private readonly Restaurants restaurants = new Restaurants();
        private readonly Users users = new Users();

        /* ---------------- CREATE ---------------- */

        /// <summary>
        /// Creates a restaurant for an existing user and promotes that user to
        /// RestaurantAdmin at the same time, so the two can never disagree.
        /// </summary>
        public bool AddRestaurant(Restaurant restaurant, out string message)
        {
            message = string.Empty;

            User owner = users.GetUserById(restaurant.OwnerId);

            if (owner == null)
            {
                message = "Please choose a valid owner.";
                return false;
            }

            if (restaurants.GetRestaurantByOwner(restaurant.OwnerId) != null)
            {
                message = owner.Name + " already owns a restaurant. " +
                          "One owner manages one restaurant in this system.";
                return false;
            }

            restaurant.Status = "Active";
            restaurants.AddRestaurant(restaurant);

            if (owner.Role != "RestaurantAdmin")
                users.UpdateRole(owner.UserId, "RestaurantAdmin");

            message = "Restaurant created and " + owner.Name +
                      " is now a Restaurant Admin.";
            return true;
        }

        /* ---------------- READ ---------------- */

        public DataTable GetAllRestaurants()
        {
            return restaurants.GetAllRestaurants();
        }

        public List<Restaurant> GetActiveRestaurants()
        {
            return restaurants.GetActiveRestaurants();
        }

        public Restaurant GetMyRestaurant()
        {
            return restaurants.GetRestaurantById(Session.CurrentRestaurantId);
        }

        public int CountRestaurants()
        {
            return restaurants.GetRestaurantCount();
        }

        /* ---------------- UPDATE ---------------- */

        public bool UpdateMyRestaurant(Restaurant restaurant, out string message)
        {
            message = string.Empty;

            // Force the id from Session so the form cannot point at someone else.
            restaurant.RestaurantId = Session.CurrentRestaurantId;

            restaurants.UpdateRestaurant(restaurant);

            Session.CurrentRestaurantName = restaurant.RestaurantName;

            message = "Restaurant profile saved.";
            return true;
        }

        public bool UpdateStatus(int restaurantId, string status, out string message)
        {
            restaurants.UpdateStatus(restaurantId, status);

            message = status == "Active"
                ? "Restaurant approved. Its menu is now visible to customers."
                : "Restaurant set to " + status + ". Its menu is hidden from customers.";

            return true;
        }

        /* ---------------- DELETE ---------------- */

        public bool DeleteRestaurant(int restaurantId, out string message)
        {
            restaurants.DeleteRestaurant(restaurantId);
            message = "Restaurant deactivated. Its order history is kept.";
            return true;
        }
    }
}
