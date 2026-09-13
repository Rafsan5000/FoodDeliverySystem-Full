using System;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// The customer's home screen. Keeps the original CustomerDashBoard
    /// layout: profile fields at the top, order history in a grid below,
    /// navigation buttons down the left.
    /// </summary>
    public partial class CustomerDashBoard : Form
    {
        private readonly OrderController orderController = new OrderController();
        private readonly UserController userController = new UserController();

        public CustomerDashBoard()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Customer Dashboard");
            UiTheme.StylePanel(pnlSide, true);

            foreach (Control control in pnlSide.Controls)
            {
                if (control is Button) UiTheme.StyleSidebarButton((Button)control);
                if (control is Label)  UiTheme.StyleLabel((Label)control);
            }

            foreach (Control control in this.Controls)
            {
                if (control is Label)   UiTheme.StyleLabel((Label)control);
                if (control is TextBox) UiTheme.StyleTextBox((TextBox)control);
                if (control is Button)  UiTheme.StyleButton((Button)control);
            }

            UiTheme.StyleTitle(lblWelcome);
            UiTheme.StyleGrid(gridOrders);

            lblProfileTitle.ForeColor = UiTheme.Accent;
            lblPwdTitle.ForeColor     = UiTheme.Accent;
            lblHistoryTitle.ForeColor = UiTheme.Accent;
        }

        private void CustomerDashBoard_Load(object sender, EventArgs e)
        {
            LoadProfile();
            LoadOrders();
        }

        private void LoadProfile()
        {
            try
            {
                lblWelcome.Text = "Welcome, " + Session.CurrentUser.Name;

                User customer = userController.GetUserById(Session.UserId);

                if (customer == null) return;

                Session.CurrentUser = customer;

                txtName.Text    = customer.Name;
                txtEmail.Text   = customer.Email;
                txtPhone.Text   = customer.Phone;
                txtAddress.Text = customer.Address;
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        /// <summary>
        /// FLOW: OrderController.GetMyOrders -> Orders.GetOrdersByCustomer
        ///       -> SELECT ... LEFT JOIN Payments WHERE CustomerId = @CustomerId
        /// </summary>
        private void LoadOrders()
        {
            try
            {
                gridOrders.DataSource = orderController.GetMyOrders();

                lblInfo.Text = gridOrders.Rows.Count == 0
                    ? "You have not ordered anything yet."
                    : "You have placed " + gridOrders.Rows.Count + " order(s).";
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validator.IsFilled(txtName, "Name")) return;
                if (!Validator.IsFilled(txtEmail, "Email")) return;
                if (!Validator.IsEmail(txtEmail)) return;
                if (!Validator.IsFilled(txtPhone, "Phone")) return;
                if (!Validator.IsPhone(txtPhone)) return;
                if (!Validator.IsFilled(txtAddress, "Address")) return;

                User customer = new User
                {
                    UserId  = Session.UserId,
                    Name    = txtName.Text.Trim(),
                    Email   = txtEmail.Text.Trim(),
                    Phone   = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim()
                };

                string message;

                if (!userController.UpdateUser(customer, out message))
                {
                    Validator.Show(message);
                    return;
                }

                Validator.Info(message);
                LoadProfile();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validator.IsFilled(txtOldPwd, "Current password")) return;
                if (!Validator.IsFilled(txtNewPwd, "New password")) return;
                if (!Validator.IsStrongEnough(txtNewPwd)) return;

                if (txtNewPwd.Text != txtConfirmPwd.Text)
                {
                    Validator.Show("The two new passwords do not match.");
                    return;
                }

                string message;

                if (!userController.ChangePassword(Session.UserId, txtOldPwd.Text,
                                                   txtNewPwd.Text, out message))
                {
                    Validator.Show(message);
                    return;
                }

                Validator.Info(message);

                txtOldPwd.Clear();
                txtNewPwd.Clear();
                txtConfirmPwd.Clear();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        /// <summary>
        /// FLOW: OrderController.CancelMyOrder -> ownership and status checks
        ///       -> Orders.CancelOrder (transaction: restore stock, set
        ///          Cancelled, mark payment Failed)
        /// </summary>
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int orderId;
                if (!TryGetOrderId(out orderId)) return;

                if (!Validator.Confirm("Cancel order " + orderId + "?")) return;

                string message;

                if (!orderController.CancelMyOrder(orderId, out message))
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

        private void btnViewOrder_Click(object sender, EventArgs e) { OpenInvoice(); }
        private void btnInvoice_Click(object sender, EventArgs e)   { OpenInvoice(); }

        private void OpenInvoice()
        {
            int orderId;
            if (!TryGetOrderId(out orderId)) return;

            new InvoiceForm(orderId).ShowDialog();
        }

        private bool TryGetOrderId(out int orderId)
        {
            orderId = 0;

            if (gridOrders.CurrentRow == null)
            {
                Validator.Show("Select an order from your history first.");
                return false;
            }

            orderId = Convert.ToInt32(gridOrders.CurrentRow.Cells["OrderId"].Value);
            return true;
        }

        private void gridOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            lblInfo.Text = "Order " + gridOrders.Rows[e.RowIndex].Cells["OrderId"].Value +
                           " selected - status: " +
                           gridOrders.Rows[e.RowIndex].Cells["OrderStatus"].Value;
        }

        /* ---------------- navigation ---------------- */

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadProfile();
            LoadOrders();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            new FoodCustomerForm().ShowDialog();
            LoadOrders();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            new Cart().ShowDialog();
            LoadOrders();
        }

        private void btnRefresh_Click(object sender, EventArgs e) { LoadOrders(); }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (!Validator.Confirm("Log out of FOOD X?")) return;

            Session.Clear();
            this.Close();
        }
    }
}
