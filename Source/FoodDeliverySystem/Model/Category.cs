namespace FoodDeliverySystem.Model
{
    /// <summary>Entity class. One object = one row of the Categories table.</summary>
    public class Category
    {
        public int    CategoryId   { get; set; }
        public string CategoryName { get; set; }
        public string Status       { get; set; }

        public Category() { }

        public Category(int categoryId, string categoryName)
        {
            CategoryId   = categoryId;
            CategoryName = categoryName;
        }

        /// <summary>ComboBoxes on the food screens display this.</summary>
        public override string ToString()
        {
            return CategoryName;
        }
    }
}
