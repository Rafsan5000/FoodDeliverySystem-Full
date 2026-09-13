using System;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// The Employee's whole application: see the orders for the restaurant
    /// they work at, open the kitchen ticket, move the order along and record
    /// cash received.
    ///
    /// Employees have no CRUD powers at all. The only thing they can write is
    /// an order status and a payment status, which matches the requirement
    /// "View orders / Update order status / Support restaurant operations".
    /// </summary>
    public partial class EmployeeDashBoard : Form
    {
        private readonly OrderController controller = new OrderController();
        private readonly PaymentController paymentController = new PaymentController();

        public EmployeeDashBoard()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Employee Dashboard");
            UiTheme.StylePanel(pnlSide, true);

            foreach (Control control in pnlSide.Controls)
            {
                if (control is Button) UiTheme.StyleSidebarButton((Button)control);
                if (control is Label)  UiTheme.StyleLabel((Label)control);
            }

            foreach (Control control in this.Controls)
            {
                if (control is Label)    UiTheme.StyleLabel((Label)control);
                if (control is TextBox)  UiTheme.StyleTextBox((TextBox)control);
                if (control is Button)   UiTheme.StyleButton((Button)control);
                if (control is ComboBox) UiTheme.StyleCombo((ComboBox)control);
            }

            UiTheme.StyleTitle(lblWelcome);
            UiTheme.StyleGrid(gridOrders);
            UiTheme.StyleGrid(gridTicket);
            lblTicketTitle.ForeColor = UiTheme.Accent;
        }

        private void EmployeeDashBoard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + Session.CurrentUser.Name +
                              "  -  " + Session.CurrentRestaurantName;

            cmbStatus.SelectedIndex    = 0;
            cmbNewStatus.SelectedIndex = 0;

            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                string filter = cmbStatus.SelectedItem == null
                    ? "All" : cmbStatus.SelectedItem.ToString();

                gridOrders.DataSource = controller.GetRestaurantOrders(filter);

                lblCount.Text = gridOrders.Rows.Count + " order(s) in view.";
                gridTicket.DataSource = null;
                lblCurrent.Text = "Current status:";
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) { LoadOrders(); }
        private void btnRefresh_Click(object sender, EventArgs e)               { LoadOrders(); }

        /// <summary>
        /// Loads the kitchen ticket: only the items from this restaurant,
        /// because an order can contain food from two restaurants and each
        /// kitchen should cook only its own part.
        /// </summary>
        private void gridOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                int orderId = Convert.ToInt32(gridOrders.Rows[e.RowIndex].Cells["OrderId"].Value);

                txtOrderId.Text = orderId.ToString();
                lblCurrent.Text = "Current status: " +
                    gridOrders.Rows[e.RowIndex].Cells["OrderStatus"].Value;

                gridTicket.DataSource = controller.GetKitchenTicket(orderId);
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
                    !Validator.Confirm("Cancel order " + orderId +
                                       "? The stock will be returned."))
                    return;

                string message;

                if (!controller.UpdateStatus(orderId, newStatus, out message))
                {
                    Validator.Show(message);
                    return;
                }

                lblInfo.Text = message;
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

                lblInfo.Text = message;
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

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            Validator.Info(
                "Name  : " + Session.CurrentUser.Name  + Environment.NewLine +
                "Email : " + Session.CurrentUser.Email + Environment.NewLine +
                "Phone : " + Session.CurrentUser.Phone + Environment.NewLine +
                "Works at: " + Session.CurrentRestaurantName);
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (!Validator.Confirm("Log out of FOOD X?")) return;

            Session.Clear();
            this.Close();
        }
    }
}
