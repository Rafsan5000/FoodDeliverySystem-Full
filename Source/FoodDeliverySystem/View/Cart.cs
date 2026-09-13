using System;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// The shopping cart. Keeps the original Cart form name, but it is now
    /// backed by a real Cart table instead of a list held in memory, so the
    /// contents survive logging out and back in.
    ///
    /// FLOW (load): Cart_Load -> CartController.GetMyCart
    ///       -> Carts.GetCartByCustomer
    ///       -> SELECT ... JOIN Foods JOIN Restaurants,
    ///          (Quantity * Price) AS Subtotal
    /// </summary>
    public partial class Cart : Form
    {
        private readonly CartController controller = new CartController();

        public Cart()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "My Cart");

            foreach (Control control in this.Controls)
            {
                if (control is Label)   UiTheme.StyleLabel((Label)control);
                if (control is TextBox) UiTheme.StyleTextBox((TextBox)control);
                if (control is Button)  UiTheme.StyleButton((Button)control);
            }

            UiTheme.StyleTitle(lblTitle);
            UiTheme.StyleGrid(gridCart);

            lblTotal.Font      = UiTheme.TitleFont;
            lblTotal.ForeColor = UiTheme.Accent;
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            LoadCart();
        }

        private void LoadCart()
        {
            try
            {
                gridCart.DataSource = controller.GetMyCart();

                decimal total = controller.GetMyCartTotal();
                lblTotal.Text = "Total: " + total.ToString("0.00") + " Tk";

                btnCheckout.Enabled = gridCart.Rows.Count > 0;

                lblInfo.Text = gridCart.Rows.Count == 0
                    ? "Your cart is empty. Use Browse Food to add something."
                    : gridCart.Rows.Count + " item(s) in your cart.";

                ClearSelection();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void gridCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = gridCart.Rows[e.RowIndex];

            txtCartId.Text = row.Cells["CartId"].Value.ToString();
            txtQty.Text    = row.Cells["Quantity"].Value.ToString();

            lblItem.Text = "Selected item: " + row.Cells["FoodName"].Value +
                           "   (stock left: " + row.Cells["Stock"].Value + ")";
        }

        private void btnUpdateQty_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validator.IsRowSelected(gridCart, "cart row")) return;

                int cartId;
                if (!int.TryParse(txtCartId.Text, out cartId))
                {
                    Validator.Show("Select a row in the cart first.");
                    return;
                }

                int quantity;
                if (!Validator.IsNonNegativeInt(txtQty, "Quantity", out quantity)) return;

                int foodId = Convert.ToInt32(gridCart.CurrentRow.Cells["FoodId"].Value);

                string message;

                if (!controller.UpdateQuantity(cartId, foodId, quantity, out message))
                {
                    Validator.Show(message);
                    return;
                }

                LoadCart();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int cartId;
                if (!int.TryParse(txtCartId.Text, out cartId))
                {
                    Validator.Show("Select a row in the cart first.");
                    return;
                }

                string message;
                controller.RemoveItem(cartId, out message);

                LoadCart();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridCart.Rows.Count == 0) return;
                if (!Validator.Confirm("Remove everything from your cart?")) return;

                string message;
                controller.ClearCart(out message);

                LoadCart();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (gridCart.Rows.Count == 0)
            {
                Validator.Show("Your cart is empty.");
                return;
            }

            new ConfirmOrder().ShowDialog();

            // Coming back: a successful checkout emptied the cart.
            LoadCart();

            if (gridCart.Rows.Count == 0) this.Close();
        }

        private void ClearSelection()
        {
            txtCartId.Clear();
            txtQty.Clear();
            lblItem.Text = "Selected item:";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            new FoodCustomerForm().ShowDialog();
            LoadCart();
        }

        private void btnRefresh_Click(object sender, EventArgs e) { LoadCart(); }
        private void btnClose_Click(object sender, EventArgs e)   { this.Close(); }
    }
}
