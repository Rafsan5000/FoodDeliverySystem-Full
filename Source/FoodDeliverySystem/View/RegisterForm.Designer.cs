namespace FoodDeliverySystem.View
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Location = new System.Drawing.Point(150, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 34);
            this.lblTitle.Text = "Create your account";
            this.lblTitle.AutoSize = true;
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(40, 80);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Full Name";
            this.lblName.AutoSize = true;
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(170, 77);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 23);
            //
            // lblEmail
            //
            this.lblEmail.Location = new System.Drawing.Point(40, 120);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email";
            this.lblEmail.AutoSize = true;
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(170, 117);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 23);
            //
            // lblPhone
            //
            this.lblPhone.Location = new System.Drawing.Point(40, 160);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Text = "Phone";
            this.lblPhone.AutoSize = true;
            //
            // txtPhone
            //
            this.txtPhone.Location = new System.Drawing.Point(170, 157);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(300, 23);
            //
            // lblAddress
            //
            this.lblAddress.Location = new System.Drawing.Point(40, 200);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Text = "Address";
            this.lblAddress.AutoSize = true;
            //
            // txtAddress
            //
            this.txtAddress.Location = new System.Drawing.Point(170, 197);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(300, 50);
            this.txtAddress.Multiline = true;
            //
            // lblPassword
            //
            this.lblPassword.Location = new System.Drawing.Point(40, 265);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Text = "Password";
            this.lblPassword.AutoSize = true;
            //
            // txtPassword
            //
            this.txtPassword.Location = new System.Drawing.Point(170, 262);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(300, 23);
            this.txtPassword.UseSystemPasswordChar = true;
            //
            // lblConfirm
            //
            this.lblConfirm.Location = new System.Drawing.Point(40, 305);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Text = "Confirm Password";
            this.lblConfirm.AutoSize = true;
            //
            // txtConfirm
            //
            this.txtConfirm.Location = new System.Drawing.Point(170, 302);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(300, 23);
            this.txtConfirm.UseSystemPasswordChar = true;
            //
            // lblHint
            //
            this.lblHint.Location = new System.Drawing.Point(170, 332);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(300, 18);
            this.lblHint.Text = "Password must be at least 6 characters.";
            this.lblHint.AutoSize = true;
            //
            // btnRegister
            //
            this.btnRegister.Location = new System.Drawing.Point(170, 370);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(130, 36);
            this.btnRegister.Text = "Register";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(330, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 36);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // RegisterForm
            //
            this.AcceptButton = this.btnRegister;
            this.ClientSize = new System.Drawing.Size(520, 470);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnCancel);
            this.Name = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
    }
}
