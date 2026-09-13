using System;
using System.Data;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.Controller
{
    /// <summary>
    /// Controller for employee records. Same class name as the original
    /// project's EmployeeController, but it now works against the split
    /// Users + Employees design.
    /// </summary>
    public class EmployeeController
    {
        private readonly Employees employees = new Employees();
        private readonly Users users = new Users();

        /* ---------------- CREATE ---------------- */

        /// <summary>
        /// Hires an employee: creates the login account and the employment
        /// record together. The restaurant always comes from Session.
        /// </summary>
        public bool AddEmployee(string name, string email, string password,
                                string phone, string address, string position,
                                DateTime joiningDate, out string message)
        {
            message = string.Empty;

            if (users.EmailExists(email))
            {
                message = "That email is already in use by another account.";
                return false;
            }

            User user = new User
            {
                Name     = name,
                Email    = email,
                Password = password,
                Phone    = phone,
                Address  = address,
                Role     = "Employee",
                Status   = "Active"
            };

            Employee employee = new Employee
            {
                RestaurantId = Session.CurrentRestaurantId,
                Position     = position,
                JoiningDate  = joiningDate,
                Status       = "Active"
            };

            int newId = employees.AddEmployeeWithUser(user, employee);

            message = "Employee added (id " + newId + "). " +
                      "They can log in with " + email + ".";
            return true;
        }

        /* ---------------- READ ---------------- */

        public DataTable GetMyEmployees()
        {
            return employees.GetEmployeesByRestaurant(Session.CurrentRestaurantId);
        }

        public DataTable GetAllEmployees()
        {
            return employees.GetAllEmployees();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return employees.GetEmployeeById(employeeId);
        }

        public int CountMyEmployees()
        {
            return employees.GetEmployeeCount(Session.CurrentRestaurantId);
        }

        public int CountAllEmployees()
        {
            return employees.GetEmployeeCount(0);
        }

        /* ---------------- UPDATE ---------------- */

        public bool UpdateEmployee(Employee employee, out string message)
        {
            message = string.Empty;

            employee.RestaurantId = Session.CurrentRestaurantId;

            int rows = employees.UpdateEmployee(employee);

            if (rows == 0)
            {
                message = "That employee does not work at your restaurant.";
                return false;
            }

            message = "Employee record updated.";
            return true;
        }

        /* ---------------- DELETE ---------------- */

        /// <summary>
        /// STATUS BASED DELETE only. An employee is never really removed,
        /// because their joining date and position are part of the
        /// restaurant's records.
        /// </summary>
        public bool DeleteEmployee(int employeeId, out string message)
        {
            Employee employee = employees.GetEmployeeById(employeeId);

            if (employee == null || employee.RestaurantId != Session.CurrentRestaurantId)
            {
                message = "That employee does not work at your restaurant.";
                return false;
            }

            employees.DeleteEmployee(employeeId);

            message = employee.Name + " has been deactivated and can no longer log in.";
            return true;
        }
    }
}
