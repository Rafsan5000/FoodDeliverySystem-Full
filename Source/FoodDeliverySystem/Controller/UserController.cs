using System.Collections.Generic;
using System.Data;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.Controller
{
    /// <summary>
    /// Controller for the Users CRUD screen. Used mainly by the Super Admin.
    /// It sits between the form and the Users model class and holds the rules
    /// that are about "what is allowed", not "how do I write SQL".
    /// </summary>
    public class UserController
    {
        private readonly Users users = new Users();

        /* ---------------- CREATE ---------------- */

        public bool AddUser(User user, out string message)
        {
            message = string.Empty;

            if (users.EmailExists(user.Email))
            {
                message = "A user with that email already exists.";
                return false;
            }

            users.AddUser(user);
            message = "User added successfully.";
            return true;
        }

        /* ---------------- READ ---------------- */

        public DataTable SearchUsers(string keyword, string role, string status)
        {
            return users.SearchUsers(keyword, role, status);
        }

        public User GetUserById(int userId)
        {
            return users.GetUserById(userId);
        }

        public List<User> GetUsersByRole(string role)
        {
            return users.GetUsersByRole(role);
        }

        public int CountByRole(string role)
        {
            return users.GetUserCount(role);
        }

        /* ---------------- UPDATE ---------------- */

        public bool UpdateUser(User user, out string message)
        {
            message = string.Empty;

            // Duplicate check that ignores the user's own current row.
            User existing = users.GetByEmail(user.Email);

            if (existing != null && existing.UserId != user.UserId)
            {
                message = "That email is already used by another account.";
                return false;
            }

            message = users.UpdateUser(user) > 0
                ? "Profile updated."
                : "Nothing was updated.";

            return true;
        }

        public bool UpdateRole(int userId, string role, out string message)
        {
            users.UpdateRole(userId, role);
            message = "Role changed to " + role + ".";
            return true;
        }

        /// <summary>Approve / suspend, used by the Super Admin's user list.</summary>
        public bool UpdateStatus(int userId, string status, out string message)
        {
            users.UpdateStatus(userId, status);
            message = "Account status set to " + status + ".";
            return true;
        }

        public bool ChangePassword(int userId, string oldPassword, string newPassword,
                                   out string message)
        {
            message = string.Empty;

            User user = users.GetUserById(userId);

            if (user == null)
            {
                message = "Account not found.";
                return false;
            }

            // Re-authenticate with the old password before changing it.
            if (users.Login(user.Email, oldPassword) == null)
            {
                message = "Your current password is not correct.";
                return false;
            }

            users.ChangePassword(userId, newPassword);
            message = "Password changed successfully.";
            return true;
        }

        /* ---------------- DELETE ---------------- */

        /// <summary>
        /// Tries a real delete first; if the user is referenced anywhere it
        /// falls back to the soft delete. The caller does not have to know
        /// which one happened, only that the account is now gone from use.
        /// </summary>
        public bool DeleteUser(int userId, out string message)
        {
            if (users.HardDeleteUser(userId))
            {
                message = "User removed completely (the account had no history).";
                return true;
            }

            users.DeleteUser(userId);
            message = "User has order history, so the account was deactivated " +
                      "instead of deleted. The records stay intact.";
            return true;
        }
    }
}
