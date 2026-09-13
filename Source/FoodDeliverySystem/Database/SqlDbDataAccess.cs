using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FoodDeliverySystem.Database
{
    /// <summary>
    /// PROTECTED FILE - only Member 1 edits this.
    ///
    /// This is the ONLY class in the whole project that knows the connection
    /// string or opens a SqlConnection. Every Model class goes through it.
    /// That is what "separate database connection class" means in the
    /// scalability requirement: if the server name changes, or we later move
    /// to a different database, exactly one file changes.
    ///
    /// The original project had this same idea (Model/SqlDbDataAccess.cs with
    /// a GetQuery method). This version keeps the same role but adds the
    /// three execute helpers so no Model has to remember to close a
    /// connection - the using blocks do it automatically.
    /// </summary>
    public class SqlDbDataAccess
    {
        private readonly string connectionString;

        public SqlDbDataAccess()
        {
            // Read from App.config so the server name is not hard-coded in code.
            connectionString = ConfigurationManager
                .ConnectionStrings["RestaurantDB"].ConnectionString;
        }

        /// <summary>
        /// Returns a brand-new closed connection. Callers wrap it in using().
        /// </summary>
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Kept for compatibility with the original project's style: builds a
        /// SqlCommand attached to a fresh connection. Prefer the Execute*
        /// helpers below in new code.
        /// </summary>
        public SqlCommand GetQuery(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return new SqlCommand(query, connection);
        }

        /// <summary>
        /// Runs INSERT / UPDATE / DELETE. Returns how many rows changed.
        /// Use the return value to detect "nothing matched" situations.
        /// </summary>
        public int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Runs a query that returns one single value: COUNT(*), SUM(...),
        /// SCOPE_IDENTITY() and so on.
        /// </summary>
        public object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                connection.Open();
                return command.ExecuteScalar();
            }
        }

        /// <summary>
        /// Runs a SELECT and fills a DataTable. A DataTable can be bound
        /// straight to a DataGridView, which is how every list screen works.
        /// </summary>
        public DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                }
            }

            return table;
        }

        /// <summary>
        /// Opens a connection and starts a transaction. Checkout uses this so
        /// that the order, its details, the payment and the stock update all
        /// succeed together or all roll back together.
        /// </summary>
        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// Quick check used by LogInForm so the user sees a friendly message
        /// instead of a raw SqlException when SQL Server is not running.
        /// </summary>
        public bool TestConnection(out string message)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                }
                message = "Connected.";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
    }
}
