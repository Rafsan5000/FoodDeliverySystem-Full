using System;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// Checkout. Keeps the original ConfirmOrder form name.
    ///
    /// FLOW: btnPlaceOrder_Click
    ///       -> OrderController.Checkout
    ///       -> Carts.GetCartItems  (read the cart)
    ///       -> Orders.PlaceOrder   (ONE transaction that does five things:
    ///            INSERT Orders, INSERT OrderDetails per item,
    ///            UPDATE Foods stock, INSERT Payments, DELETE Cart)
    ///       -> InvoiceForm opens with the new OrderId.
    ///
    /// This is the single most important screen to be able to explain in the
    /// viva, because it is where the transaction lives.
    /// </summary>
    public partial class ConfirmOrder : Form
    {
        private readonly OrderController controller = new OrderController();
        private readonly CartController cartController = new CartController();
        private readonly UserController userController = new UserController();

        public ConfirmOrder()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Confirm Order");

            foreach (Control control in this.Controls)
            {
                if (control is Label)    UiTheme.StyleLabel((Label)control);
                if (control is TextBox)  UiTheme.StyleTextBox((TextBox)control);
                if (control is Button)   UiTheme.StyleButton((Button)control);
                if (control is ComboBox) UiTheme.StyleCombo((ComboBox)control);
            }

            UiTheme.StyleTitle(lblTitle);
            UiTheme.StyleGrid(gridItems);

            lblTotal.Font      = UiTheme.TitleFont;
            lblTotal.ForeColor = UiTheme.Accent;
        }

        private void ConfirmOrder_Load(object sender, EventArgs e)
        {
            try
            {
                gridItems.DataSource = cartController.GetMyCart();

                decimal total = cartController.GetMyCartTotal();
                lblTotal.Text = "Total: " + total.ToString("0.00") + " Tk";

                // Pre-fill the delivery details from the customer's profile.
                User customer = userController.GetUserById(Session.UserId);

                if (customer != null)
                {
                    txtName.Text    = customer.Name;
                    txtPhone.Text   = customer.Phone;
                    txtAddress.Text = customer.Address;
                }

                cmbPayment.SelectedIndex = 0;   // Cash on Delivery

                lblNote.Text = "Cash on Delivery is recorded as Pending until " +
                               "the rider collects the money.";
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validator.IsFilled(txtPhone, "Phone")) return;
                if (!Validator.IsPhone(txtPhone)) return;
                if (!Validator.IsFilled(txtAddress, "Delivery address")) return;
                if (!Validator.IsSelected(cmbPayment, "payment method")) return;

                string paymentMethod = cmbPayment.SelectedItem.ToString();

                if (!Validator.Confirm(
                        "Place this order?" + Environment.NewLine +
                        lblTotal.Text + Environment.NewLine +
                        "Payment: " + paymentMethod))
                    return;

                // Save any change the customer made to their phone / address
                // so the next order is pre-filled correctly.
                SaveDeliveryDetails();

                string message;
                int orderId = controller.Checkout(paymentMethod,
                                                  txtAddress.Text.Trim(), out message);

                if (orderId == 0)
                {
                    // The transaction rolled back - nothing was saved.
                    lblInfo.Text = message;
                    Validator.Show(message);
                    return;
                }

                Validator.Info(message);

                new InvoiceForm(orderId).ShowDialog();

                this.Close();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void SaveDeliveryDetails()
        {
            try
            {
                User customer = userController.GetUserById(Session.UserId);

                if (customer == null) return;

                customer.Phone   = txtPhone.Text.Trim();
                customer.Address = txtAddress.Text.Trim();

                string message;
                userController.UpdateUser(customer, out message);

                Session.CurrentUser = customer;
            }
            catch
            {
                // Not fatal: the order matters more than the saved address.
            }
        }

        private void btnBack_Click(object sender, EventArgs e) { this.Close(); }
    }
}
