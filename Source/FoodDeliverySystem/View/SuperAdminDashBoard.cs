using System;
using System.Drawing;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// The Super Admin's home screen. Keeps the original AdminDashBoard
    /// layout: a sidebar of navigation buttons on the left, counters and a
    /// grid on the right.
    ///
    /// FLOW: SuperAdminDashBoard_Load -> ReportController.GetPlatformTotals
    ///       -> COUNT(*) / SUM(...) queries -> labels updated
    ///       and ReportController.SalesPerRestaurant -> GROUP BY query -> grid
    /// </summary>
    public partial class SuperAdminDashBoard : Form
    {
        private readonly ReportController reports = new ReportController();

        public SuperAdminDashBoard()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Super Admin Dashboard");
            UiTheme.StylePanel(pnlSide, true);

            foreach (Control control in pnlSide.Controls)
            {
                if (control is Button) UiTheme.StyleSidebarButton((Button)control);
                if (control is Label)  UiTheme.StyleLabel((Label)control);
            }

            foreach (Control control in this.Controls)
                if (control is Label) UiTheme.StyleLabel((Label)control);

            UiTheme.StyleTitle(lblWelcome);
            UiTheme.StyleGrid(gridSummary);

            lblRestaurants.Font = UiTheme.HeadingFont;
            lblCustomers.Font   = UiTheme.HeadingFont;
            lblOrders.Font      = UiTheme.HeadingFont;
            lblRevenue.Font     = UiTheme.HeadingFont;

            lblGridTitle.ForeColor = UiTheme.Accent;
        }

        private void SuperAdminDashBoard_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        /// <summary>Refreshes every counter and the summary grid.</summary>
        private void LoadDashboard()
        {
            try
            {
                lblWelcome.Text = "Welcome, " + Session.CurrentUser.Name + " (Super Admin)";

                int restaurants, customers, orders;
                decimal revenue;

                reports.GetPlatformTotals(out restaurants, out customers,
                                          out orders, out revenue);

                lblRestaurants.Text = "Total Restaurants : " + restaurants;
                lblCustomers.Text   = "Total Customers   : " + customers;
                lblOrders.Text      = "Total Orders      : " + orders;
                lblRevenue.Text     = "Total Revenue     : " + revenue.ToString("0.00") + " Tk";

                gridSummary.DataSource = reports.SalesPerRestaurant();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        /* ---------------- navigation ---------------- */

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            new AdminUsers().ShowDialog();
            LoadDashboard();
        }

        private void btnRestaurants_Click(object sender, EventArgs e)
        {
            new AdminRestaurants().ShowDialog();
            LoadDashboard();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            new AdminCategories().ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            new AdminReports().ShowDialog();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            // "true" means platform wide: every order, not one restaurant's.
            new AdminOrders(true).ShowDialog();
            LoadDashboard();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (!Validator.Confirm("Log out of FOOD X?")) return;

            Session.Clear();
            this.Close();   // LogInForm reappears through its FormClosed handler
        }
    }
}
