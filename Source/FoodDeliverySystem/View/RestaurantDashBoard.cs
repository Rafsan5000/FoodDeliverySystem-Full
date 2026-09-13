using System;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// The Restaurant Admin's home screen: restaurant profile on the left,
    /// counters on the right, low-stock warnings underneath.
    ///
    /// Everything on this form is scoped by Session.CurrentRestaurantId,
    /// which was set at login. The owner physically cannot load another
    /// restaurant's data.
    /// </summary>
    public partial class RestaurantDashBoard : Form
    {
        private readonly ReportController reports = new ReportController();
        private readonly RestaurantController restaurantController = new RestaurantController();

        public RestaurantDashBoard()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Restaurant Dashboard");
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
            UiTheme.StyleGrid(gridLowStock);

            lblFoods.Font           = UiTheme.HeadingFont;
            lblEmployeesCount.Font  = UiTheme.HeadingFont;
            lblPending.Font         = UiTheme.HeadingFont;
            lblRevenue.Font         = UiTheme.HeadingFont;
            lblProfileTitle.ForeColor  = UiTheme.Accent;
            lblLowStockTitle.ForeColor = UiTheme.Accent;
        }

        private void RestaurantDashBoard_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                lblWelcome.Text = "Welcome, " + Session.CurrentUser.Name +
                                  "  -  " + Session.CurrentRestaurantName;

                Restaurant restaurant = restaurantController.GetMyRestaurant();

                if (restaurant != null)
                {
                    txtName.Text    = restaurant.RestaurantName;
                    txtAddress.Text = restaurant.Address;
                    txtPhone.Text   = restaurant.Phone;
                }

                int foods, employees, pending;
                decimal revenue;

                reports.GetRestaurantTotals(out foods, out employees, out pending, out revenue);

                lblFoods.Text          = "Total Foods     : " + foods;
                lblEmployeesCount.Text = "Total Employees : " + employees;
                lblPending.Text        = "Pending Orders  : " + pending;
                lblRevenue.Text        = "Revenue         : " + revenue.ToString("0.00") + " Tk";

                gridLowStock.DataSource = reports.MyLowStock(10);
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        /// <summary>
        /// FLOW: Click -> validate -> RestaurantController.UpdateMyRestaurant
        ///       -> Restaurants.UpdateRestaurant -> UPDATE Restaurants SET ...
        /// </summary>
        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validator.IsFilled(txtName, "Restaurant name")) return;
                if (!Validator.IsFilled(txtAddress, "Address")) return;
                if (!Validator.IsFilled(txtPhone, "Phone")) return;
                if (!Validator.IsPhone(txtPhone)) return;

                Restaurant restaurant = new Restaurant
                {
                    RestaurantName = txtName.Text.Trim(),
                    Address        = txtAddress.Text.Trim(),
                    Phone          = txtPhone.Text.Trim()
                };

                string message;
                restaurantController.UpdateMyRestaurant(restaurant, out message);

                Validator.Info(message);
                LoadDashboard();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        /* ---------------- navigation ---------------- */

        private void btnDashboard_Click(object sender, EventArgs e)  { LoadDashboard(); }

        private void btnFoods_Click(object sender, EventArgs e)
        {
            new FoodAdminForm().ShowDialog();
            LoadDashboard();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            new AdminEmployees().ShowDialog();
            LoadDashboard();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            // "false" means restaurant scoped: only orders containing my food.
            new AdminOrders(false).ShowDialog();
            LoadDashboard();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            new AdminReports().ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (!Validator.Confirm("Log out of FOOD X?")) return;

            Session.Clear();
            this.Close();
        }
    }
}
