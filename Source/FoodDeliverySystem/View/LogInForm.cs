using System;
using System.Drawing;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;
using FoodDeliverySystem.Database;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// The single entry point for all four roles.
    ///
    /// The original project had two login screens (LogInForm for customers
    /// and AdminLogIn for the admin). They have been merged: one form checks
    /// the Role column and opens the right dashboard. Adding a fourth role
    /// therefore needed no new login screen at all.
    ///
    /// FLOW:  btnLogIn_Click -> LogInController.Authenticate
    ///        -> Users.Login  -> SELECT ... FROM Users WHERE Email/Password
    ///        -> Session filled -> OpenDashboardFor(role)
    /// </summary>
    public partial class LogInForm : Form
    {
        private readonly LogInController controller = new LogInController();

        public LogInForm()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Log In");

            UiTheme.StyleTitle(lblBrand);
            lblBrand.Font = new Font("Segoe UI", 26F, FontStyle.Bold);

            UiTheme.StyleLabel(lblTagline);
            UiTheme.StyleLabel(lblEmail);
            UiTheme.StyleLabel(lblPassword);
            UiTheme.StyleLabel(lblCreate);
            UiTheme.StyleLabel(lblStatus);

            UiTheme.StyleTextBox(txtEmail);
            UiTheme.StyleTextBox(txtPassword);

            UiTheme.StyleButton(btnLogIn);
            UiTheme.StyleButton(btnRegister);
            UiTheme.StyleButton(btnForget);

            chkShow.BackColor = Color.Transparent;
            chkShow.Font = UiTheme.InputFont;
            lblStatus.ForeColor = UiTheme.Accent;
        }

        /// <summary>
        /// Checks that SQL Server is reachable before the user types anything,
        /// so a wrong connection string shows a clear message instead of an
        /// exception after the first login attempt.
        /// </summary>
        private void LogInForm_Load(object sender, EventArgs e)
        {
            string message;

            if (!new SqlDbDataAccess().TestConnection(out message))
            {
                lblStatus.Text = "Cannot reach the database. Check App.config.";
                MessageBox.Show(
                    "The application could not connect to SQL Server." +
                    Environment.NewLine + Environment.NewLine + message +
                    Environment.NewLine + Environment.NewLine +
                    "Open App.config and set Data Source to your own server name.",
                    "FOOD X - Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShow.Checked;
        }

        /// <summary>
        /// Button Click -> validate -> Controller -> Model -> SQL -> open form.
        /// </summary>
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validation happens before we ever touch the database.
                if (!Validator.IsFilled(txtEmail, "Email")) return;
                if (!Validator.IsEmail(txtEmail)) return;
                if (!Validator.IsFilled(txtPassword, "Password")) return;

                // 2. Ask the Controller to authenticate.
                string message;
                bool ok = controller.Authenticate(txtEmail.Text, txtPassword.Text, out message);

                if (!ok)
                {
                    lblStatus.Text = message;
                    Validator.Show(message);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                // 3. Session is now filled in - route by role.
                OpenDashboardFor(Session.Role);
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        /// <summary>
        /// Role based access control in one place. Whatever role the user has,
        /// only that one dashboard is ever created.
        /// </summary>
        private void OpenDashboardFor(string role)
        {
            Form dashboard;

            switch (role)
            {
                case "SuperAdmin":
                    dashboard = new SuperAdminDashBoard();
                    break;

                case "RestaurantAdmin":
                    dashboard = new RestaurantDashBoard();
                    break;

                case "Employee":
                    dashboard = new EmployeeDashBoard();
                    break;

                case "Customer":
                    dashboard = new CustomerDashBoard();
                    break;

                default:
                    Validator.Show("This account has an unknown role: " + role);
                    return;
            }

            this.Hide();
            dashboard.FormClosed += (s, args) =>
            {
                // Coming back from a dashboard means the user logged out.
                txtEmail.Clear();
                txtPassword.Clear();
                lblStatus.Text = "";
                this.Show();
            };
            dashboard.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new RegisterForm().ShowDialog();
        }

        private void btnForget_Click(object sender, EventArgs e)
        {
            new ForgetPassword().ShowDialog();
        }
    }
}
