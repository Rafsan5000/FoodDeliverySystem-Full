using System;

namespace FoodDeliverySystem.Model
{
    /// <summary>Entity class. One object = one row of the Payments table.</summary>
    public class Payment
    {
        public int      PaymentId     { get; set; }
        public int      OrderId       { get; set; }
        public string   PaymentMethod { get; set; }
        public string   PaymentStatus { get; set; }
        public DateTime PaymentDate   { get; set; }

        public Payment() { }

        public Payment(int orderId, string paymentMethod, string paymentStatus)
        {
            OrderId       = orderId;
            PaymentMethod = paymentMethod;
            PaymentStatus = paymentStatus;
        }

        public static string[] Methods
        {
            get { return new string[] { "Cash on Delivery", "Card", "Mobile Banking" }; }
        }
    }
}
