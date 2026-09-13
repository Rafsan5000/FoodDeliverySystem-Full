using FoodDeliverySystem.Common;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.Controller
{
    /// <summary>
    /// Handles authentication and registration.
    ///
    /// The View never talks to the Model directly. LogInForm calls
    /// Authenticate(), this class asks the Model for the row, applies the
    /// business rules (is there a restaurant? which dashboard?) and fills in
    /// the Session. That keeps all the login logic in one testable place.
    ///
    /// Same class name as the original project's LogInController, so the
    /// report and the file list still line up.
    /// </summary>
    public class LogInController
    {
        private readonly Users users = new Users();
        private readonly Restaurants restaurants = new Restaurants();
        private readonly Employees employees = new Employees();

        /// <summary>
        /// Verifies the credentials and, if they are good, sets up Session.
        /// </summary>
        /// <returns>true when the user is now logged in.</returns>
        public bool Authenticate(string email, string password, out string message)
        {
            message = string.Empty;

            User user = users.Login(email.Trim(), password);

            if (user == null)
            {
                // Deliberately vague: telling an attacker which half was wrong
                // would let them work out which emails exist.
                message = "Wrong email or password, or the account is not active.";
                return false;
            }

            Session.CurrentUser = user;

            // A Restaurant Admin needs to know which restaurant is theirs.
            if (user.Role == "RestaurantAdmin")
            {
                Restaurant restaurant = restaurants.GetRestaurantByOwner(user.UserId);

                if (restaurant == null)
                {
                    Session.Clear();
                    message = "No restaurant is linked to this account yet. " +
                              "Please ask the Super Admin to create one.";
                    return false;
                }

                Session.CurrentRestaurantId   = restaurant.RestaurantId;
                Session.CurrentRestaurantName = restaurant.RestaurantName;
            }

            // An Employee needs to know which restaurant they work for.
            if (user.Role == "Employee")
            {
                Employee employee = employees.GetEmployeeByUserId(user.UserId);

                if (employee == null || employee.Status != "Active")
                {
                    Session.Clear();
                    message = "This employee account is not active at any restaurant.";
                    return false;
                }

                Session.CurrentRestaurantId = employee.RestaurantId;

                Restaurant restaurant = restaurants.GetRestaurantById(employee.RestaurantId);
                Session.CurrentRestaurantName = restaurant == null ? "" : restaurant.RestaurantName;
            }

            message = "Welcome, " + user.Name + ".";
            return true;
        }

        /// <summary>
        /// Customer self-registration. Always creates a Customer - a visitor
        /// can never make themselves an admin from the register screen.
        /// </summary>
        public bool Register(User user, out string message)
        {
            message = string.Empty;

            if (users.EmailExists(user.Email.Trim()))
            {
                message = "That email is already registered. Try logging in instead.";
                return false;
            }

            user.Role   = "Customer";
            user.Status = "Active";
            user.Email  = user.Email.Trim();

            int newId = users.AddUser(user);

            if (newId <= 0)
            {
                message = "Registration failed. Please try again.";
                return false;
            }

            message = "Account created. You can now log in with " + user.Email + ".";
            return true;
        }

        /// <summary>
        /// Password reset. Simplified for a desktop project: the user proves
        /// they own the account with their registered phone number.
        /// </summary>
        public bool ResetPassword(string email, string phone, string newPassword, out string message)
        {
            message = string.Empty;

            User user = users.GetByEmail(email.Trim());

            if (user == null)
            {
                message = "No account is registered with that email address.";
                return false;
            }

            if (user.Phone != phone.Trim())
            {
                message = "The phone number does not match the one on this account.";
                return false;
            }

            users.ResetPasswordByEmail(email.Trim(), newPassword);

            message = "Password updated. Please log in with your new password.";
            return true;
        }

        public void LogOut()
        {
            Session.Clear();
        }
    }
}
