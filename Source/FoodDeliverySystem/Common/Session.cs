using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.Common
{
    /// <summary>
    /// Holds who is logged in right now. Static so every form can read it
    /// without passing the user object from form to form.
    ///
    /// This is what makes role based access work: after login we store the
    /// User here, and each dashboard reads Session.Role to decide what the
    /// user is allowed to see.
    /// </summary>
    public static class Session
    {
        public static User CurrentUser { get; set; }

        /// <summary>
        /// For a RestaurantAdmin this is their own restaurant.
        /// For an Employee this is the restaurant they work at.
        /// It stays 0 for SuperAdmin and Customer, who are not tied to one.
        /// </summary>
        public static int CurrentRestaurantId { get; set; }

        public static string CurrentRestaurantName { get; set; }

        public static bool IsLoggedIn
        {
            get { return CurrentUser != null; }
        }

        public static int UserId
        {
            get { return CurrentUser == null ? 0 : CurrentUser.UserId; }
        }

        public static string Role
        {
            get { return CurrentUser == null ? string.Empty : CurrentUser.Role; }
        }

        /// <summary>Called by every Log Out button.</summary>
        public static void Clear()
        {
            CurrentUser = null;
            CurrentRestaurantId = 0;
            CurrentRestaurantName = null;
        }
    }
}
