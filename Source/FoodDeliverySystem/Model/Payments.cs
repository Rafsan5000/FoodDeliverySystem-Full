using System;
using System.Data;
using System.Data.SqlClient;
using FoodDeliverySystem.Database;

namespace FoodDeliverySystem.Model
{
    /// <summary>
    /// Data-access class for the Payments table.
    ///
    /// In the original database PaymentMethod and PaymentStatus were two
    /// columns inside Orders. Splitting them out means a failed payment can
    /// be retried, and the payment date is recorded separately from the order
    /// date, which is what actually happens with cash on delivery.
    /// </summary>
    public class Payments
    {
        private readonly SqlDbDataAccess sda = new SqlDbDataAccess();

        /* ---------------- CREATE ---------------- */

        public int AddPayment(Payment payment)
        {
            string query =
                "INSERT INTO Payments (OrderId, PaymentMethod, PaymentStatus, PaymentDate) " +
                "VALUES (@OrderId, @PaymentMethod, @PaymentStatus, GETDATE()); " +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            return Convert.ToInt32(sda.ExecuteScalar(query,
                new SqlParameter("@OrderId",       payment.OrderId),
                new SqlParameter("@PaymentMethod", payment.PaymentMethod),
                new SqlParameter("@PaymentStatus", payment.PaymentStatus)));
        }

        /* ---------------- READ ---------------- */

        public Payment GetPaymentByOrder(int orderId)
        {
            string query =
                "SELECT PaymentId, OrderId, PaymentMethod, PaymentStatus, PaymentDate " +
                "FROM   Payments WHERE OrderId = @OrderId;";

            DataTable table = sda.ExecuteQuery(query, new SqlParameter("@OrderId", orderId));

            if (table.Rows.Count == 0)
                return null;

            DataRow row = table.Rows[0];

            return new Payment
            {
                PaymentId     = Convert.ToInt32(row["PaymentId"]),
                OrderId       = Convert.ToInt32(row["OrderId"]),
                PaymentMethod = row["PaymentMethod"].ToString(),
                PaymentStatus = row["PaymentStatus"].ToString(),
                PaymentDate   = Convert.ToDateTime(row["PaymentDate"])
            };
        }

        /// <summary>
        /// GROUP BY QUERY. How much money came in through each payment
        /// method - a report for the Super Admin.
        /// </summary>
        public DataTable GetPaymentSummary()
        {
            string query =
                "SELECT p.PaymentMethod, p.PaymentStatus, " +
                "       COUNT(*)             AS TotalPayments, " +
                "       SUM(o.TotalAmount)   AS TotalAmount " +
                "FROM   Payments p INNER JOIN Orders o ON p.OrderId = o.OrderId " +
                "GROUP  BY p.PaymentMethod, p.PaymentStatus " +
                "ORDER  BY p.PaymentMethod;";

            return sda.ExecuteQuery(query);
        }

        public DataTable GetPendingPayments()
        {
            string query =
                "SELECT p.PaymentId, p.OrderId, u.Name AS CustomerName, " +
                "       o.TotalAmount, p.PaymentMethod, p.PaymentDate " +
                "FROM   Payments p " +
                "       INNER JOIN Orders o ON p.OrderId    = o.OrderId " +
                "       INNER JOIN Users  u ON o.CustomerId = u.UserId " +
                "WHERE  p.PaymentStatus = 'Pending' " +
                "ORDER  BY p.PaymentDate;";

            return sda.ExecuteQuery(query);
        }

        /* ---------------- UPDATE ---------------- */

        /// <summary>
        /// Marks a cash-on-delivery payment as collected. Used by the
        /// Employee when the rider comes back with the money.
        /// </summary>
        public int UpdatePaymentStatus(int orderId, string status)
        {
            string query =
                "UPDATE Payments SET PaymentStatus = @Status, PaymentDate = GETDATE() " +
                "WHERE  OrderId = @OrderId;";

            return sda.ExecuteNonQuery(query,
                new SqlParameter("@Status",  status),
                new SqlParameter("@OrderId", orderId));
        }
    }
}
