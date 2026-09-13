using System;
using System.Data;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// Report viewer. The same form serves both admin roles: a Super Admin
    /// sees the whole platform, a Restaurant Admin sees only their own
    /// restaurant. Session.Role decides which controller method is called, so
    /// there is no second screen to maintain.
    ///
    /// Every button here runs a GROUP BY query - this is the screen to open
    /// when the examiner asks to see aggregate SQL.
    /// </summary>
    public partial class AdminReports : Form
    {
        private readonly ReportController reports = new ReportController();

        private bool IsSuperAdmin
        {
            get { return Session.Role == "SuperAdmin"; }
        }

        public AdminReports()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Reports");

            foreach (Control control in this.Controls)
            {
                if (control is Label)   UiTheme.StyleLabel((Label)control);
                if (control is TextBox) UiTheme.StyleTextBox((TextBox)control);
                if (control is Button)  UiTheme.StyleButton((Button)control);
            }

            UiTheme.StyleTitle(lblTitle);
            UiTheme.StyleGrid(gridReport);
            lblReportTitle.ForeColor = UiTheme.Accent;
        }

        private void AdminReports_Load(object sender, EventArgs e)
        {
            lblTitle.Text = IsSuperAdmin
                ? "Platform Reports"
                : "Reports - " + Session.CurrentRestaurantName;

            // Sales per restaurant only makes sense platform wide.
            btnSales.Enabled    = IsSuperAdmin;
            btnPayments.Enabled = IsSuperAdmin;

            if (IsSuperAdmin) ShowSales();
            else              ShowBestSellers();
        }

        private void btnSales_Click(object sender, EventArgs e)    { ShowSales(); }
        private void btnBest_Click(object sender, EventArgs e)     { ShowBestSellers(); }
        private void btnDaily_Click(object sender, EventArgs e)    { ShowDailySales(); }
        private void btnPayments_Click(object sender, EventArgs e) { ShowPayments(); }

        /// <summary>
        /// GROUP BY across Restaurants, Foods, OrderDetails and Orders.
        /// </summary>
        private void ShowSales()
        {
            Render("Sales per restaurant  (JOIN + GROUP BY + SUM)",
                   reports.SalesPerRestaurant(), "TotalSales");
        }

        /// <summary>GROUP BY with HAVING on the aggregate.</summary>
        private void ShowBestSellers()
        {
            try
            {
                int minUnits;

                if (!int.TryParse(txtMinUnits.Text.Trim(), out minUnits) || minUnits < 0)
                {
                    Validator.Show("Minimum units must be a whole number of 0 or more.");
                    return;
                }

                DataTable table = IsSuperAdmin
                    ? reports.BestSellersPlatformWide(minUnits)
                    : reports.MyBestSellers(minUnits);

                Render("Best selling foods  (GROUP BY + HAVING SUM(Quantity) >= " +
                       minUnits + ")", table, "Revenue");
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        /// <summary>GROUP BY on a cast date.</summary>
        private void ShowDailySales()
        {
            DataTable table = IsSuperAdmin
                ? reports.DailySalesPlatformWide()
                : reports.MyDailySales();

            Render("Daily sales  (GROUP BY CAST(OrderDate AS DATE))", table, "TotalSales");
        }

        private void ShowPayments()
        {
            Render("Payments by method and status  (GROUP BY two columns)",
                   reports.PaymentSummary(), "TotalAmount");
        }

        /// <summary>
        /// Puts a report on screen and adds up one money column underneath,
        /// so the grand total does not have to be read off the grid by eye.
        /// </summary>
        private void Render(string title, DataTable table, string sumColumn)
        {
            try
            {
                lblReportTitle.Text  = title;
                gridReport.DataSource = table;

                decimal total = 0;

                if (table.Columns.Contains(sumColumn))
                {
                    foreach (DataRow row in table.Rows)
                        if (row[sumColumn] != DBNull.Value)
                            total += Convert.ToDecimal(row[sumColumn]);
                }

                lblSummary.Text = table.Rows.Count + " row(s).   " +
                                  sumColumn + " overall: " + total.ToString("0.00") + " Tk";
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
    }
}
