namespace FoodDeliverySystem.Model
{
    /// <summary>
    /// Entity class. One object = one row of the Foods table.
    /// Compared with the original Food class this gains RestaurantId and
    /// CategoryId, which is what lets a food item belong to a restaurant and
    /// be filtered by category.
    /// </summary>
    public class Food
    {
        public int     FoodId       { get; set; }
        public int     RestaurantId { get; set; }
        public int     CategoryId   { get; set; }
        public string  FoodName     { get; set; }
        public string  Description  { get; set; }
        public decimal Price        { get; set; }
        public int     Stock        { get; set; }
        public string  Status       { get; set; }

        // Joined-in columns, used for display only.
        public string  CategoryName   { get; set; }
        public string  RestaurantName { get; set; }

        public Food() { }

        public Food(int restaurantId, int categoryId, string foodName,
                    string description, decimal price, int stock, string status)
        {
            RestaurantId = restaurantId;
            CategoryId   = categoryId;
            FoodName     = foodName;
            Description  = description;
            Price        = price;
            Stock        = stock;
            Status       = status;
        }

        /// <summary>Business rule kept on the entity, not repeated in forms.</summary>
        public bool IsOrderable
        {
            get { return Status == "Available" && Stock > 0; }
        }

        public override string ToString()
        {
            return FoodName + " - " + Price.ToString("0.00") + " Tk";
        }
    }
}
