using System;

namespace FoodDeliverySystem.Model
{
    /// <summary>
    /// Entity class. One object = one row of the Users table.
    /// It carries data only - no SQL. The matching data-access class is Users.
    /// This is the same "Food / Foods" pattern the original project used.
    ///
    /// OOP note for the viva: Name, Email and the rest are auto-implemented
    /// properties, so the fields behind them are private. That is
    /// encapsulation - a form can never reach in and change a field directly.
    /// </summary>
    public class User
    {
        public int      UserId      { get; set; }
        public string   Name        { get; set; }
        public string   Email       { get; set; }
        public string   Password    { get; set; }
        public string   Phone       { get; set; }
        public string   Address     { get; set; }
        public string   Role        { get; set; }
        public string   Status      { get; set; }
        public DateTime CreatedDate { get; set; }

        public User() { }

        public User(string name, string email, string password,
                    string phone, string address, string role, string status)
        {
            Name     = name;
            Email    = email;
            Password = password;
            Phone    = phone;
            Address  = address;
            Role     = role;
            Status   = status;
        }

        /// <summary>
        /// Overriding ToString lets us bind a List&lt;User&gt; straight to a
        /// ComboBox and have it display something readable.
        /// </summary>
        public override string ToString()
        {
            return Name + " (" + Email + ")";
        }
    }
}
