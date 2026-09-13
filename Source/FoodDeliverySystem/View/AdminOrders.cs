using System;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// Order management for both admin roles.
    ///
    /// The constructor takes a flag instead of there being two near-identical
    /// forms: platformWide = true loads every order (Super Admin), false
    /// loads only orders containing this restaurant's food.
    ///
    /// FLOW (status change): btnUpdateStatus_Click
    ///       -> OrderController.UpdateStatus  (checks the state machine)
    ///       -> Orders.UpdateOrderStatus      (UPDATE ... WHERE OrderStatus
    ///                                         NOT IN ('Completed','Cancelled'))
    ///       or Orders.CancelOrder            (transaction: restore stock,
    ///                                         set Cancelled, fail payment)
    /// </summary>
    public partial class AdminOrders : Form
    {
        private readonly OrderController controller = new OrderController();
        private readonly PaymentController paymentController = new PaymentController();
        private readonly bool platformWide;

        public AdminOrders() : this(true) { }

        public AdminOrders(bool platformWide)
        {
            this.platformWide = platformWide;
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Orders");

            foreach (Control control in this.Controls)
            {
                if (control is Label)    UiTheme.StyleLabel((Label)control);
                if (control is TextBox)  UiTheme.StyleTextBox((TextBox)control);
                if (control is Button)   UiTheme.StyleButton((Button)control);
                if (control is ComboBox) UiTheme.StyleCombo((ComboBox)control);
            }

            UiTheme.StyleTitle(lblTitle);
            UiTheme.StyleGrid(gridOrders);
            UiTheme.StyleGrid(gridItems);
            lblItemsTitle.ForeColor = UiTheme.Accent;
        }

        private void AdminOrders_Load(object sender, EventArgs e)
        {
            lblTitle.Text = platformWide
                ? "All Orders (Platform)"
                : "Orders - " + Session.CurrentRestaurantName;

            // Deleting an order permanently is a Super Admin power only.
            btnDelete.Visible = platformWide;

            cmbStatus.SelectedIndex    = 0;   // "All"
            cmbNewStatus.SelectedIndex = 0;

            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                string filter = cmbStatus.SelectedItem == null
                    ? "All" : cmbStatus.SelectedItem.ToString();

                gridOrders.DataSource = platformWide
                    ? controller.GetAllOrders(filter)
                    : controller.GetRestaurantOrders(filter);

                lblInfo.Text = gridOrders.Rows.Count + " order(s) shown.";
                gridItems.DataSource = null;
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) { LoadOrders(); }
        private void btnRefresh_Click(object sender, EventArgs e)               { LoadOrders(); }

        /// <summary>
        /// Clicking an order loads its line items. The Restaurant Admin only
        /// sees their own items; the Super Admin sees the full invoice.
        /// </summary>
        private void gridOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                int orderId = Convert.ToInt32(gridOrders.Rows[e.RowIndex].Cells["OrderId"].Value);

                txtOrderId.Text  = orderId.ToString();
                lblCurrent.Text  = "Current status: " +
                    gridOrders.Rows[e.RowIndex].Cells["OrderStatus"].Value;

                gridItems.DataSource = platformWide
                    ? controller.GetInvoice(orderId)
                    : controller.GetKitchenTicket(orderId);
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            try
            {
                int orderId;
                if (!TryGetOrderId(out orderId)) return;
                if (!Validator.IsSelected(cmbNewStatus, "new status")) return;

                string newStatus = cmbNewStatus.SelectedItem.ToString();

                if (newStatus == "Cancelled" &&
                    !Validator.Confirm("Cancel order " + orderId + "? " +
                                       "The stock will be returned to the restaurant."))
                    return;

                string message;

                if (!controller.UpdateStatus(orderId, newStatus, out message))
                {
                    Validator.Show(message);
                    return;
                }

                Validator.Info(message);
                LoadOrders();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnMarkPaid_Click(object sender, EventArgs e)
        {
            try
            {
                int orderId;
                if (!TryGetOrderId(out orderId)) return;

                string message;

                if (!paymentController.MarkAsPaid(orderId, out message))
                {
                    Validator.Show(message);
                    return;
                }

                Validator.Info(message);
                LoadOrders();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            int orderId;
            if (!TryGetOrderId(out orderId)) return;

            new InvoiceForm(orderId).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int orderId;
                if (!TryGetOrderId(out orderId)) return;

                if (!Validator.Confirm(
                        "Permanently delete order " + orderId + "?" + Environment.NewLine +
                        "This removes the payment and all order items too, and " +
                        "the sales reports will change. Cancelling is usually better."))
                    return;

                string message;
                controller.DeleteOrder(orderId, out message);

                Validator.Info(message);
                txtOrderId.Clear();
                LoadOrders();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private bool TryGetOrderId(out int orderId)
        {
            if (!int.TryParse(txtOrderId.Text, out orderId))
            {
                Validator.Show("Select an order from the list first.");
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
    }
}
