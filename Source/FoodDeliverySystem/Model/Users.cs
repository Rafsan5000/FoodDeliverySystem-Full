using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FoodDeliverySystem.Database;

namespace FoodDeliverySystem.Model
{
    /// <summary>
    /// Data-access class for the Users table. Every SQL statement that touches
    /// Users lives here and nowhere else.
    ///
    /// This class replaces four classes from the original project
    /// (Admins, Customers, Employees and LogIns), which all did the same job
    /// against four near-identical tables.
    ///
    /// Every query is parameterised. The user's typing is never pasted into
    /// the SQL string, so a value like  x' OR '1'='1  is treated as a plain
    /// piece of text and cannot change the meaning of the query.
    /// </summary>
    public class Users
    {
        private readonly SqlDbDataAccess sda = new SqlDbDataAccess();

        /* ==================================================================
           LOGIN
           ================================================================== */

        /// <summary>
        /// Checks email + password and returns the matching User, or null.
        /// Status = 'Active' is part of the WHERE clause, so an account the
        /// Super Admin has suspended simply cannot log in.
        /// </summary>
        public User Login(string email, string password)
        {
            string query =
                "SELECT UserId, Name, Email, Phone, Address, Role, Status, CreatedDate " +
                "FROM   Users " +
                "WHERE  Email = @Email AND Password = @Password AND Status = 'Active';";

            DataTable table = sda.ExecuteQuery(query,
                new SqlParameter("@Email",    email),
                new SqlParameter("@Password", password));

            if (table.Rows.Count == 0)
                return null;

            return MapRow(table.Rows[0]);
        }

        /// <summary>Used by ForgetPassword to confirm the account exists.</summary>
        public User GetByEmail(string email)
        {
            string query =
                "SELECT UserId, Name, Email, Phone, Address, Role, Status, CreatedDate " +
                "FROM   Users WHERE Email = @Email;";

            DataTable table = sda.ExecuteQuery(query, new SqlParameter("@Email", email));

            return table.Rows.Count == 0 ? null : MapRow(table.Rows[0]);
        }

        /* ==================================================================
           CREATE
           ================================================================== */

        /// <summary>
        /// Inserts a user and returns the new UserId.
        /// SCOPE_IDENTITY() gives back the value SQL Server generated for the
        /// IDENTITY column, which the caller needs straight away (for example
        /// to then insert an Employees row pointing at this user).
        /// </summary>
        public int AddUser(User user)
        {
            string query =
                "INSERT INTO Users (Name, Email, Password, Phone, Address, Role, Status, CreatedDate) " +
                "VALUES (@Name, @Email, @Password, @Phone, @Address, @Role, @Status, GETDATE()); " +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            object result = sda.ExecuteScalar(query,
                new SqlParameter("@Name",     user.Name),
                new SqlParameter("@Email",    user.Email),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Phone",    (object)user.Phone   ?? DBNull.Value),
                new SqlParameter("@Address",  (object)user.Address ?? DBNull.Value),
                new SqlParameter("@Role",     user.Role),
                new SqlParameter("@Status",   user.Status));

            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Duplicate checking. Called before AddUser so the user gets a clear
        /// message instead of a raw SQL error from the UQ_Users_Email
        /// constraint. The constraint is still there as the final safety net.
        /// </summary>
        public bool EmailExists(string email)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email;";

            object result = sda.ExecuteScalar(query, new SqlParameter("@Email", email));

            return Convert.ToInt32(result) > 0;
        }

        /* ==================================================================
           READ
           ================================================================== */

        public User GetUserById(int userId)
        {
            string query =
                "SELECT UserId, Name, Email, Phone, Address, Role, Status, CreatedDate " +
                "FROM   Users WHERE UserId = @UserId;";

            DataTable table = sda.ExecuteQuery(query, new SqlParameter("@UserId", userId));

            return table.Rows.Count == 0 ? null : MapRow(table.Rows[0]);
        }

        public List<User> GetAllUsers()
        {
            string query =
                "SELECT UserId, Name, Email, Phone, Address, Role, Status, CreatedDate " +
                "FROM   Users ORDER BY UserId;";

            return MapList(sda.ExecuteQuery(query));
        }

        /// <summary>Used to fill the "assign owner" combo boxes.</summary>
        public List<User> GetUsersByRole(string role)
        {
            string query =
                "SELECT UserId, Name, Email, Phone, Address, Role, Status, CreatedDate " +
                "FROM   Users WHERE Role = @Role AND Status = 'Active' ORDER BY Name;";

            return MapList(sda.ExecuteQuery(query, new SqlParameter("@Role", role)));
        }

        /// <summary>
        /// SEARCH + FILTER in one query, for the Super Admin's user list.
        ///
        /// The trick is  (@Role = 'All' OR Role = @Role).  When the combo box
        /// is on "All" the first half is true and the filter is ignored;
        /// otherwise the second half applies. That means one query handles
        /// every combination of filters instead of four different queries.
        /// </summary>
        public DataTable SearchUsers(string keyword, string role, string status)
        {
            string query =
                "SELECT UserId, Name, Email, Phone, Address, Role, Status, CreatedDate " +
                "FROM   Users " +
                "WHERE  (@Keyword = '' OR Name LIKE '%' + @Keyword + '%' " +
                "                     OR Email LIKE '%' + @Keyword + '%') " +
                "  AND  (@Role    = 'All' OR Role   = @Role) " +
                "  AND  (@Status  = 'All' OR Status = @Status) " +
                "ORDER BY UserId;";

            return sda.ExecuteQuery(query,
                new SqlParameter("@Keyword", keyword ?? string.Empty),
                new SqlParameter("@Role",    role    ?? "All"),
                new SqlParameter("@Status",  status  ?? "All"));
        }

        public int GetUserCount(string role)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Role = @Role AND Status = 'Active';";

            return Convert.ToInt32(sda.ExecuteScalar(query, new SqlParameter("@Role", role)));
        }

        /* ==================================================================
           UPDATE
           ================================================================== */

        /// <summary>Profile update. The password is handled separately.</summary>
        public int UpdateUser(User user)
        {
            string query =
                "UPDATE Users " +
                "SET    Name = @Name, Email = @Email, Phone = @Phone, Address = @Address " +
                "WHERE  UserId = @UserId;";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@Name",    user.Name),
                new SqlParameter("@Email",   user.Email),
                new SqlParameter("@Phone",   (object)user.Phone   ?? DBNull.Value),
                new SqlParameter("@Address", (object)user.Address ?? DBNull.Value),
                new SqlParameter("@UserId",  user.UserId));
        }

        /// <summary>Used by the Super Admin to change anyone's role.</summary>
        public int UpdateRole(int userId, string role)
        {
            string query = "UPDATE Users SET Role = @Role WHERE UserId = @UserId;";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@Role",   role),
                new SqlParameter("@UserId", userId));
        }

        public int UpdateStatus(int userId, string status)
        {
            string query = "UPDATE Users SET Status = @Status WHERE UserId = @UserId;";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@Status", status),
                new SqlParameter("@UserId", userId));
        }

        public int ChangePassword(int userId, string newPassword)
        {
            string query = "UPDATE Users SET Password = @Password WHERE UserId = @UserId;";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@Password", newPassword),
                new SqlParameter("@UserId",   userId));
        }

        public int ResetPasswordByEmail(string email, string newPassword)
        {
            string query = "UPDATE Users SET Password = @Password WHERE Email = @Email;";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@Password", newPassword),
                new SqlParameter("@Email",    email));
        }

        /* ==================================================================
           DELETE
           ================================================================== */

        /// <summary>
        /// STATUS BASED DELETE (soft delete). The row stays in the table and
        /// only Status changes to 'Inactive'.
        ///
        /// Why: a customer who has placed orders is referenced by
        /// Orders.CustomerId. A real DELETE would either fail on the foreign
        /// key or destroy the order history. Marking the row inactive keeps
        /// the reports correct while stopping the account from logging in,
        /// because Login() filters on Status = 'Active'.
        /// </summary>
        public int DeleteUser(int userId)
        {
            string query = "UPDATE Users SET Status = 'Inactive' WHERE UserId = @UserId;";

            return sda.ExecuteNonQuery(query, new SqlParameter("@UserId", userId));
        }

        /// <summary>
        /// Real DELETE. Only offered for a user who has never ordered and is
        /// not linked to anything else - the count check below proves it is
        /// safe before the row is removed.
        /// </summary>
        public bool HardDeleteUser(int userId)
        {
            string check =
                "SELECT (SELECT COUNT(*) FROM Orders      WHERE CustomerId = @UserId) + " +
                "       (SELECT COUNT(*) FROM Cart        WHERE CustomerId = @UserId) + " +
                "       (SELECT COUNT(*) FROM Employees   WHERE UserId     = @UserId) + " +
                "       (SELECT COUNT(*) FROM Restaurants WHERE OwnerId    = @UserId);";

            int references = Convert.ToInt32(
                sda.ExecuteScalar(check, new SqlParameter("@UserId", userId)));

            if (references > 0)
                return false;   // caller falls back to the soft delete

            sda.ExecuteNonQuery("DELETE FROM Users WHERE UserId = @UserId;",
                new SqlParameter("@UserId", userId));

            return true;
        }

        /* ==================================================================
           HELPERS - one place that turns a DataRow into a User object
           ================================================================== */

        private User MapRow(DataRow row)
        {
            return new User
            {
                UserId      = Convert.ToInt32(row["UserId"]),
                Name        = row["Name"].ToString(),
                Email       = row["Email"].ToString(),
                Phone       = row["Phone"]   == DBNull.Value ? "" : row["Phone"].ToString(),
                Address     = row["Address"] == DBNull.Value ? "" : row["Address"].ToString(),
                Role        = row["Role"].ToString(),
                Status      = row["Status"].ToString(),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"])
            };
        }

        private List<User> MapList(DataTable table)
        {
            List<User> list = new List<User>();

            foreach (DataRow row in table.Rows)
                list.Add(MapRow(row));

            return list;
        }
    }
}
