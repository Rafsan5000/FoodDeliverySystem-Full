using System;

namespace FoodDeliverySystem.Model
{
    /// <summary>
    /// Entity class. One object = one row of the Orders table.
    /// The old Order class had a ProductNames string holding every item name.
    /// That is gone: the items now live in OrderDetail objects.
    /// </summary>
    public class Order
    {
        public int      OrderId     { get; set; }
        public int      CustomerId  { get; set; }
        public DateTime OrderDate   { get; set; }
        public decimal  TotalAmount { get; set; }
        public string   OrderStatus { get; set; }

        // Joined-in columns, used for display only.
        public string CustomerName  { get; set; }
        public string CustomerPhone { get; set; }
        public string Address       { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }

        public Order() { }

        public Order(int customerId, decimal totalAmount, string orderStatus)
        {
            CustomerId  = customerId;
            TotalAmount = totalAmount;
            OrderStatus = orderStatus;
        }

        /// <summary>
        /// The five allowed values. Kept here so the Employee screen and the
        /// Admin screen always offer exactly the same list, and so it matches
        /// the CK_Orders_Status CHECK constraint in the database.
        /// </summary>
        public static string[] AllStatuses
        {
            get
            {
                return new string[]
                {
                    "Pending", "Accepted", "Preparing", "Completed", "Cancelled"
                };
            }
        }
    }
}
