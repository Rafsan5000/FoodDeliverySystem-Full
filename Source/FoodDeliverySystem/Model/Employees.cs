using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FoodDeliverySystem.Database;

namespace FoodDeliverySystem.Model
{
    /// <summary>
    /// Data-access class for the Employees table.
    ///
    /// The original project had one Employee table holding login details and
    /// job details together. Now the login half lives in Users and this table
    /// holds only the employment record, linked by UserId. Adding an employee
    /// therefore writes two rows, which is why AddEmployeeWithUser uses a
    /// transaction.
    /// </summary>
    public class Employees
    {
        private readonly SqlDbDataAccess sda = new SqlDbDataAccess();

        /* ---------------- CREATE ---------------- */

        /// <summary>
        /// Creates the Users row and the Employees row together.
        ///
        /// TRANSACTION: if the second INSERT fails, the first one is rolled
        /// back. Without it we could end up with a user account that is not
        /// an employee of anything - a half-created record.
        /// </summary>
        public int AddEmployeeWithUser(User user, Employee employee)
        {
            using (SqlConnection connection = sda.OpenConnection())
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    string insertUser =
                        "INSERT INTO Users (Name, Email, Password, Phone, Address, Role, Status, CreatedDate) " +
                        "VALUES (@Name, @Email, @Password, @Phone, @Address, 'Employee', 'Active', GETDATE()); " +
                        "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int newUserId;

                    using (SqlCommand command = new SqlCommand(insertUser, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Name",     user.Name);
                        command.Parameters.AddWithValue("@Email",    user.Email);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.Parameters.AddWithValue("@Phone",    (object)user.Phone   ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Address",  (object)user.Address ?? DBNull.Value);

                        newUserId = Convert.ToInt32(command.ExecuteScalar());
                    }

                    string insertEmployee =
                        "INSERT INTO Employees (UserId, RestaurantId, Position, JoiningDate, Status) " +
                        "VALUES (@UserId, @RestaurantId, @Position, @JoiningDate, 'Active'); " +
                        "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int newEmployeeId;

                    using (SqlCommand command = new SqlCommand(insertEmployee, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@UserId",       newUserId);
                        command.Parameters.AddWithValue("@RestaurantId", employee.RestaurantId);
                        command.Parameters.AddWithValue("@Position",     (object)employee.Position ?? DBNull.Value);
                        command.Parameters.AddWithValue("@JoiningDate",  employee.JoiningDate);

                        newEmployeeId = Convert.ToInt32(command.ExecuteScalar());
                    }

                    transaction.Commit();
                    return newEmployeeId;
                }
                catch
                {
                    transaction.Rollback();
                    throw;      // the Controller/View layer shows the message
                }
            }
        }

        /* ---------------- READ ---------------- */

        /// <summary>
        /// JOIN QUERY across three tables. Employees holds only ID numbers, so
        /// Users supplies the name/email/phone and Restaurants supplies the
        /// restaurant name.
        /// </summary>
        public DataTable GetEmployeesByRestaurant(int restaurantId)
        {
            string query =
                "SELECT e.EmployeeId, u.Name, u.Email, u.Phone, " +
                "       e.Position, e.JoiningDate, e.Status, r.RestaurantName " +
                "FROM   Employees   e " +
                "       INNER JOIN Users       u ON e.UserId       = u.UserId " +
                "       INNER JOIN Restaurants r ON e.RestaurantId = r.RestaurantId " +
                "WHERE  e.RestaurantId = @RestaurantId " +
                "ORDER  BY e.EmployeeId;";

            return sda.ExecuteQuery(query, new SqlParameter("@RestaurantId", restaurantId));
        }

        public DataTable GetAllEmployees()
        {
            string query =
                "SELECT e.EmployeeId, u.Name, u.Email, u.Phone, " +
                "       e.Position, e.JoiningDate, e.Status, r.RestaurantName " +
                "FROM   Employees   e " +
                "       INNER JOIN Users       u ON e.UserId       = u.UserId " +
                "       INNER JOIN Restaurants r ON e.RestaurantId = r.RestaurantId " +
                "ORDER  BY e.EmployeeId;";

            return sda.ExecuteQuery(query);
        }

        public Employee GetEmployeeById(int employeeId)
        {
            string query =
                "SELECT e.EmployeeId, e.UserId, e.RestaurantId, e.Position, " +
                "       e.JoiningDate, e.Status, u.Name, u.Email, u.Phone " +
                "FROM   Employees e INNER JOIN Users u ON e.UserId = u.UserId " +
                "WHERE  e.EmployeeId = @EmployeeId;";

            DataTable table = sda.ExecuteQuery(query, new SqlParameter("@EmployeeId", employeeId));

            return table.Rows.Count == 0 ? null : MapRow(table.Rows[0]);
        }

        /// <summary>
        /// Called right after an Employee logs in, so the app knows which
        /// restaurant's orders to show them.
        /// </summary>
        public Employee GetEmployeeByUserId(int userId)
        {
            string query =
                "SELECT e.EmployeeId, e.UserId, e.RestaurantId, e.Position, " +
                "       e.JoiningDate, e.Status, u.Name, u.Email, u.Phone " +
                "FROM   Employees e INNER JOIN Users u ON e.UserId = u.UserId " +
                "WHERE  e.UserId = @UserId;";

            DataTable table = sda.ExecuteQuery(query, new SqlParameter("@UserId", userId));

            return table.Rows.Count == 0 ? null : MapRow(table.Rows[0]);
        }

        public int GetEmployeeCount(int restaurantId)
        {
            string query =
                "SELECT COUNT(*) FROM Employees " +
                "WHERE  Status = 'Active' AND (@RestaurantId = 0 OR RestaurantId = @RestaurantId);";

            return Convert.ToInt32(sda.ExecuteScalar(query,
                new SqlParameter("@RestaurantId", restaurantId)));
        }

        /* ---------------- UPDATE ---------------- */

        public int UpdateEmployee(Employee employee)
        {
            string query =
                "UPDATE Employees SET Position = @Position, Status = @Status " +
                "WHERE  EmployeeId = @EmployeeId AND RestaurantId = @RestaurantId;";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@Position",     (object)employee.Position ?? DBNull.Value),
                new SqlParameter("@Status",       employee.Status),
                new SqlParameter("@EmployeeId",   employee.EmployeeId),
                new SqlParameter("@RestaurantId", employee.RestaurantId));
        }

        /* ---------------- DELETE ---------------- */

        /// <summary>
        /// STATUS BASED DELETE, done in a transaction because it has to touch
        /// two tables: the employment record is closed and the login account
        /// is deactivated so the person can no longer sign in.
        /// </summary>
        public void DeleteEmployee(int employeeId)
        {
            using (SqlConnection connection = sda.OpenConnection())
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    int userId;

                    using (SqlCommand command = new SqlCommand(
                        "SELECT UserId FROM Employees WHERE EmployeeId = @EmployeeId;",
                        connection, transaction))
                    {
                        command.Parameters.AddWithValue("@EmployeeId", employeeId);
                        userId = Convert.ToInt32(command.ExecuteScalar());
                    }

                    using (SqlCommand command = new SqlCommand(
                        "UPDATE Employees SET Status = 'Inactive' WHERE EmployeeId = @EmployeeId;",
                        connection, transaction))
                    {
                        command.Parameters.AddWithValue("@EmployeeId", employeeId);
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(
                        "UPDATE Users SET Status = 'Inactive' WHERE UserId = @UserId;",
                        connection, transaction))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /* ---------------- HELPERS ---------------- */

        private Employee MapRow(DataRow row)
        {
            return new Employee
            {
                EmployeeId   = Convert.ToInt32(row["EmployeeId"]),
                UserId       = Convert.ToInt32(row["UserId"]),
                RestaurantId = Convert.ToInt32(row["RestaurantId"]),
                Position     = row["Position"] == DBNull.Value ? "" : row["Position"].ToString(),
                JoiningDate  = Convert.ToDateTime(row["JoiningDate"]),
                Status       = row["Status"].ToString(),
                Name         = row["Name"].ToString(),
                Email        = row["Email"].ToString(),
                Phone        = row["Phone"] == DBNull.Value ? "" : row["Phone"].ToString()
            };
        }
    }
}
