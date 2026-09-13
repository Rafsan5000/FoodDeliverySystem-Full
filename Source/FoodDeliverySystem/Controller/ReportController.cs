using System.Data;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.Controller
{
    /// <summary>
    /// Read-only controller that gathers the numbers shown on the dashboards
    /// and report screens. Keeping the reports separate from the CRUD
    /// controllers means a report can join across several tables without
    /// making the CRUD classes messy.
    /// </summary>
    public class ReportController
    {
        private readonly Orders orders = new Orders();
        private readonly Users users = new Users();
        private readonly Foods foods = new Foods();
        private readonly Restaurants restaurants = new Restaurants();
        private readonly Employees employees = new Employees();
        private readonly Payments payments = new Payments();

        /* ---------------- SUPER ADMIN ---------------- */

        public DataTable SalesPerRestaurant()
        {
            return orders.GetSalesPerRestaurant();
        }

        public DataTable PaymentSummary()
        {
            return payments.GetPaymentSummary();
        }

        public DataTable BestSellersPlatformWide(int minUnits)
        {
            return orders.GetBestSellingFoods(0, minUnits);
        }

        public DataTable DailySalesPlatformWide()
        {
            return orders.GetDailySales(0);
        }

        /// <summary>The four counters on the Super Admin dashboard.</summary>
        public void GetPlatformTotals(out int totalRestaurants, out int totalCustomers,
                                      out int totalOrders, out decimal totalRevenue)
        {
            totalRestaurants = restaurants.GetRestaurantCount();
            totalCustomers   = users.GetUserCount("Customer");
            totalOrders      = orders.GetOrderCount("All");
            totalRevenue     = orders.GetTotalRevenue();
        }

        /* ---------------- RESTAURANT ADMIN ---------------- */

        public DataTable MyBestSellers(int minUnits)
        {
            return orders.GetBestSellingFoods(Session.CurrentRestaurantId, minUnits);
        }

        public DataTable MyDailySales()
        {
            return orders.GetDailySales(Session.CurrentRestaurantId);
        }

        public DataTable MyOrderStatusSummary()
        {
            return orders.GetOrderStatusSummary(Session.CurrentRestaurantId);
        }

        public DataTable MyLowStock(int threshold)
        {
            return foods.GetLowStock(Session.CurrentRestaurantId, threshold);
        }

        /// <summary>The four counters on the Restaurant Admin dashboard.</summary>
        public void GetRestaurantTotals(out int totalFoods, out int totalEmployees,
                                        out int pendingOrders, out decimal revenue)
        {
            totalFoods     = foods.GetFoodCountByRestaurant(Session.CurrentRestaurantId);
            totalEmployees = employees.GetEmployeeCount(Session.CurrentRestaurantId);
            revenue        = orders.GetRevenueByRestaurant(Session.CurrentRestaurantId);

            DataTable restaurantOrders =
                orders.GetOrdersByRestaurant(Session.CurrentRestaurantId, "Pending");

            pendingOrders = restaurantOrders.Rows.Count;
        }
    }
}
