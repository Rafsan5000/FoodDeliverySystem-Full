namespace FoodDeliverySystem.Model
{
    /// <summary>
    /// Entity class. One object = one row of the OrderDetails table, i.e.
    /// one food item inside one order.
    /// </summary>
    public class OrderDetail
    {
        public int     OrderDetailId { get; set; }
        public int     OrderId       { get; set; }
        public int     FoodId        { get; set; }
        public int     Quantity      { get; set; }
        public decimal Price         { get; set; }

        // Joined-in columns, used for display only.
        public string FoodName       { get; set; }
        public string RestaurantName { get; set; }

        public OrderDetail() { }

        public OrderDetail(int orderId, int foodId, int quantity, decimal price)
        {
            OrderId  = orderId;
            FoodId   = foodId;
            Quantity = quantity;
            Price    = price;
        }

        public decimal Subtotal
        {
            get { return Price * Quantity; }
        }
    }
}
