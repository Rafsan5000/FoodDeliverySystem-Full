namespace FoodDeliverySystem.Model
{
    /// <summary>Entity class. One object = one row of the Restaurants table.</summary>
    public class Restaurant
    {
        public int    RestaurantId   { get; set; }
        public int    OwnerId        { get; set; }
        public string RestaurantName { get; set; }
        public string Address        { get; set; }
        public string Phone          { get; set; }
        public string Status         { get; set; }

        /// <summary>
        /// Filled in by the JOIN in Restaurants.GetAllRestaurants so the grid
        /// can show the owner's name instead of a bare OwnerId number.
        /// It is not a column of the Restaurants table.
        /// </summary>
        public string OwnerName      { get; set; }

        public Restaurant() { }

        public override string ToString()
        {
            return RestaurantName;
        }
    }
}
