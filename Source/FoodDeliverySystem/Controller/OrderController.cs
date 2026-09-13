using System.Collections.Generic;
using System.Data;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.Controller
{
    /// <summary>
    /// Controller for placing, viewing, progressing and cancelling orders.
    /// Same class name as the original project's OrderController.
    /// </summary>
    public class OrderController
    {
        private readonly Orders orders = new Orders();
        private readonly OrderDetails orderDetails = new OrderDetails();
        private readonly Carts carts = new Carts();

        /* ---------------- CHECKOUT ---------------- */

        /// <summary>
        /// Reads the cart, checks everything is still buyable, then hands the
        /// whole list to Orders.PlaceOrder, which does the work in one
        /// transaction.
        /// </summary>
        public int Checkout(string paymentMethod, string deliveryAddress, out string message)
        {
            message = string.Empty;

            List<CartItem> items = carts.GetCartItems(Session.UserId);

            if (items.Count == 0)
            {
                message = "Your cart is empty. Add some food first.";
                return 0;
            }

            // Friendly pre-check. The real protection is still the
            // "AND Stock >= @Quantity" inside the transaction, because stock
            // can change between this check and the write.
            foreach (CartItem item in items)
            {
                if (item.Quantity > item.Stock)
                {
                    message = "'" + item.FoodName + "' only has " + item.Stock +
                              " left. Please change the quantity in your cart.";
                    return 0;
                }
            }

            return orders.PlaceOrder(Session.UserId, items, paymentMethod,
                                     deliveryAddress, out message);
        }

        /* ---------------- READ ---------------- */

        public DataTable GetMyOrders()
        {
            return orders.GetOrdersByCustomer(Session.UserId);
        }

        public DataTable GetAllOrders(string statusFilter)
        {
            return orders.GetAllOrders(statusFilter);
        }

        /// <summary>Used by both the Employee and the Restaurant Admin screens.</summary>
        public DataTable GetRestaurantOrders(string statusFilter)
        {
            return orders.GetOrdersByRestaurant(Session.CurrentRestaurantId, statusFilter);
        }

        public Order GetOrderById(int orderId)
        {
            return orders.GetOrderById(orderId);
        }

        public DataTable GetInvoice(int orderId)
        {
            return orderDetails.GetInvoiceByOrder(orderId);
        }

        public DataTable GetKitchenTicket(int orderId)
        {
            return orderDetails.GetOrderItemsForRestaurant(orderId, Session.CurrentRestaurantId);
        }

        public int CountOrders(string status)
        {
            return orders.GetOrderCount(status);
        }

        public decimal GetTotalRevenue()
        {
            return orders.GetTotalRevenue();
        }

        public decimal GetMyRestaurantRevenue()
        {
            return orders.GetRevenueByRestaurant(Session.CurrentRestaurantId);
        }

        /* ---------------- UPDATE ---------------- */

        /// <summary>
        /// Moves an order along the workflow. The allowed next steps are
        /// listed here rather than in the form, so the Employee screen and
        /// the Admin screen can never disagree about the rules.
        ///
        ///   Pending   -> Accepted or Cancelled
        ///   Accepted  -> Preparing or Cancelled
        ///   Preparing -> Completed or Cancelled
        ///   Completed -> nothing
        ///   Cancelled -> nothing
        /// </summary>
        public bool UpdateStatus(int orderId, string newStatus, out string message)
        {
            message = string.Empty;

            Order order = orders.GetOrderById(orderId);

            if (order == null)
            {
                message = "Order not found.";
                return false;
            }

            if (!IsAllowedTransition(order.OrderStatus, newStatus))
            {
                message = "An order that is '" + order.OrderStatus +
                          "' cannot be changed to '" + newStatus + "'.";
                return false;
            }

            if (newStatus == "Cancelled")
                return orders.CancelOrder(orderId, out message);

            int rows = orders.UpdateOrderStatus(orderId, newStatus);

            if (rows == 0)
            {
                message = "The order was already finished, so nothing changed.";
                return false;
            }

            message = "Order " + orderId + " is now '" + newStatus + "'.";
            return true;
        }

        /// <summary>The state machine, written out so it is easy to explain.</summary>
        private bool IsAllowedTransition(string from, string to)
        {
            if (from == to) return false;

            switch (from)
            {
                case "Pending":   return to == "Accepted"  || to == "Cancelled";
                case "Accepted":  return to == "Preparing" || to == "Cancelled";
                case "Preparing": return to == "Completed" || to == "Cancelled";
                default:          return false;   // Completed and Cancelled are final
            }
        }

        /* ---------------- DELETE ---------------- */

        /// <summary>
        /// Customer-initiated cancel. A customer may only cancel their own
        /// order, and only before the kitchen starts cooking.
        /// </summary>
        public bool CancelMyOrder(int orderId, out string message)
        {
            message = string.Empty;

            Order order = orders.GetOrderById(orderId);

            if (order == null || order.CustomerId != Session.UserId)
            {
                message = "You can only cancel your own orders.";
                return false;
            }

            if (order.OrderStatus == "Preparing")
            {
                message = "The kitchen has already started cooking this order, " +
                          "so it can no longer be cancelled.";
                return false;
            }

            return orders.CancelOrder(orderId, out message);
        }

        /// <summary>Permanent removal. Super Admin only.</summary>
        public bool DeleteOrder(int orderId, out string message)
        {
            orders.HardDeleteOrder(orderId);
            message = "Order " + orderId + " and all of its records were deleted.";
            return true;
        }
    }
}
