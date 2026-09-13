using System;
using System.Drawing;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// Customer self-registration.
    ///
    /// FLOW: btnRegister_Click -> Validator checks -> LogInController.Register
    ///       -> Users.EmailExists (SELECT COUNT(*)) -> Users.AddUser (INSERT)
    ///
    /// The Role is set inside the Controller, never on this form, so a
    /// visitor can never register themselves as an admin.
    /// </summary>
    public partial class RegisterForm : Form
    {
        private readonly LogInController controller = new LogInController();

        public RegisterForm()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Register");
            UiTheme.StyleTitle(lblTitle);

            foreach (Control control in this.Controls)
            {
                if (control is Label)   UiTheme.StyleLabel((Label)control);
                if (control is TextBox) UiTheme.StyleTextBox((TextBox)control);
                if (control is Button)  UiTheme.StyleButton((Button)control);
            }

            UiTheme.StyleTitle(lblTitle);
            lblHint.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // ---- Validation: every rule from the requirements ----------
                if (!Validator.IsFilled(txtName, "Full name")) return;
                if (!Validator.IsFilled(txtEmail, "Email")) return;
                if (!Validator.IsEmail(txtEmail)) return;
                if (!Validator.IsFilled(txtPhone, "Phone")) return;
                if (!Validator.IsPhone(txtPhone)) return;
                if (!Validator.IsFilled(txtAddress, "Address")) return;
                if (!Validator.IsFilled(txtPassword, "Password")) return;
                if (!Validator.IsStrongEnough(txtPassword)) return;

                if (txtPassword.Text != txtConfirm.Text)
                {
                    Validator.Show("The two passwords do not match.");
                    txtConfirm.Focus();
                    return;
                }

                // ---- Build the entity and hand it to the Controller --------
                User user = new User
                {
                    Name     = txtName.Text.Trim(),
                    Email    = txtEmail.Text.Trim(),
                    Password = txtPassword.Text,
                    Phone    = txtPhone.Text.Trim(),
                    Address  = txtAddress.Text.Trim()
                };

                string message;

                if (!controller.Register(user, out message))
                {
                    Validator.Show(message);
                    return;
                }

                Validator.Info(message);
                this.Close();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
