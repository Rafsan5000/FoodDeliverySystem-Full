using System;

namespace FoodDeliverySystem.Model
{
    /// <summary>Entity class. One object = one row of the Employees table.</summary>
    public class Employee
    {
        public int      EmployeeId   { get; set; }
        public int      UserId       { get; set; }
        public int      RestaurantId { get; set; }
        public string   Position     { get; set; }
        public DateTime JoiningDate  { get; set; }
        public string   Status       { get; set; }

        // Joined-in columns, used for display only.
        public string   Name           { get; set; }
        public string   Email          { get; set; }
        public string   Phone          { get; set; }
        public string   RestaurantName { get; set; }

        public Employee() { }

        public override string ToString()
        {
            return Name + " - " + Position;
        }
    }
}
