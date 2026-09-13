using System;

namespace FoodDeliverySystem.Model
{
    /// <summary>Entity class. One object = one row of the Cart table.</summary>
    public class CartItem
    {
        public int      CartId     { get; set; }
        public int      CustomerId { get; set; }
        public int      FoodId     { get; set; }
        public int      Quantity   { get; set; }
        public DateTime AddedDate  { get; set; }

        // Joined-in columns, used for display only.
        public string  FoodName       { get; set; }
        public decimal Price          { get; set; }
        public int     Stock          { get; set; }
        public string  RestaurantName { get; set; }

        public CartItem() { }

        public CartItem(int customerId, int foodId, int quantity)
        {
            CustomerId = customerId;
            FoodId     = foodId;
            Quantity   = quantity;
        }

        /// <summary>
        /// Calculated in C# rather than stored in the database, because a
        /// value you can work out from other columns should not be a column.
        /// </summary>
        public decimal Subtotal
        {
            get { return Price * Quantity; }
        }
    }
}
