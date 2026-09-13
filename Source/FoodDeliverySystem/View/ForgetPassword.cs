using System;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// Password reset. The user proves they own the account by giving the
    /// phone number that is stored against it.
    ///
    /// FLOW: btnReset_Click -> LogInController.ResetPassword
    ///       -> Users.GetByEmail (SELECT) -> compare phone
    ///       -> Users.ResetPasswordByEmail (UPDATE)
    /// </summary>
    public partial class ForgetPassword : Form
    {
        private readonly LogInController controller = new LogInController();

        public ForgetPassword()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Forgot Password");

            foreach (Control control in this.Controls)
            {
                if (control is Label)   UiTheme.StyleLabel((Label)control);
                if (control is TextBox) UiTheme.StyleTextBox((TextBox)control);
                if (control is Button)  UiTheme.StyleButton((Button)control);
            }

            UiTheme.StyleTitle(lblTitle);
        }

        private void ForgetPassword_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validator.IsFilled(txtEmail, "Email")) return;
                if (!Validator.IsEmail(txtEmail)) return;
                if (!Validator.IsFilled(txtPhone, "Phone")) return;
                if (!Validator.IsFilled(txtNew, "New password")) return;
                if (!Validator.IsStrongEnough(txtNew)) return;

                if (txtNew.Text != txtConfirm.Text)
                {
                    Validator.Show("The two passwords do not match.");
                    txtConfirm.Focus();
                    return;
                }

                string message;

                if (!controller.ResetPassword(txtEmail.Text, txtPhone.Text,
                                              txtNew.Text, out message))
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
