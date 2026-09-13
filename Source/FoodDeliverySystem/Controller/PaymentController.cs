using System.Data;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.Controller
{
    /// <summary>Controller for the Payments table.</summary>
    public class PaymentController
    {
        private readonly Payments payments = new Payments();

        public Payment GetPaymentByOrder(int orderId)
        {
            return payments.GetPaymentByOrder(orderId);
        }

        public DataTable GetPaymentSummary()
        {
            return payments.GetPaymentSummary();
        }

        public DataTable GetPendingPayments()
        {
            return payments.GetPendingPayments();
        }

        /// <summary>
        /// Used when a rider returns with cash. Marking a payment Paid is a
        /// one-way step: it must not be undone from the UI.
        /// </summary>
        public bool MarkAsPaid(int orderId, out string message)
        {
            message = string.Empty;

            Payment payment = payments.GetPaymentByOrder(orderId);

            if (payment == null)
            {
                message = "No payment record exists for that order.";
                return false;
            }

            if (payment.PaymentStatus == "Paid")
            {
                message = "That order is already marked as paid.";
                return false;
            }

            payments.UpdatePaymentStatus(orderId, "Paid");
            message = "Payment for order " + orderId + " recorded as Paid.";
            return true;
        }
    }
}
