namespace FoodDeliverySystem.View
{
    partial class LogInForm
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
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblTagline = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkShow = new System.Windows.Forms.CheckBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnForget = new System.Windows.Forms.Button();
            this.lblCreate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblBrand
            //
            this.lblBrand.Location = new System.Drawing.Point(230, 30);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(200, 45);
            this.lblBrand.Text = "F O O D   X";
            //
            // lblTagline
            //
            this.lblTagline.Location = new System.Drawing.Point(205, 78);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(260, 20);
            this.lblTagline.Text = "Food Delivery Restaurant Management System";
            //
            // lblEmail
            //
            this.lblEmail.Location = new System.Drawing.Point(150, 150);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email";
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(250, 147);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(230, 23);
            //
            // lblPassword
            //
            this.lblPassword.Location = new System.Drawing.Point(150, 195);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Text = "Password";
            //
            // txtPassword
            //
            this.txtPassword.Location = new System.Drawing.Point(250, 192);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(230, 23);
            this.txtPassword.UseSystemPasswordChar = true;
            //
            // chkShow
            //
            this.chkShow.AutoSize = true;
            this.chkShow.Location = new System.Drawing.Point(250, 222);
            this.chkShow.Name = "chkShow";
            this.chkShow.Text = "Show password";
            this.chkShow.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            //
            // btnForget
            //
            this.btnForget.Location = new System.Drawing.Point(360, 218);
            this.btnForget.Name = "btnForget";
            this.btnForget.Size = new System.Drawing.Size(120, 26);
            this.btnForget.Text = "Forgot password?";
            this.btnForget.Click += new System.EventHandler(this.btnForget_Click);
            //
            // btnLogIn
            //
            this.btnLogIn.Location = new System.Drawing.Point(250, 260);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(110, 36);
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            //
            // lblCreate
            //
            this.lblCreate.Location = new System.Drawing.Point(150, 320);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Text = "New customer?";
            //
            // btnRegister
            //
            this.btnRegister.Location = new System.Drawing.Point(250, 313);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(110, 30);
            this.btnRegister.Text = "Register";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            //
            // lblStatus
            //
            this.lblStatus.Location = new System.Drawing.Point(150, 365);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(360, 20);
            this.lblStatus.Text = "";
            //
            // LogInForm
            //
            this.AcceptButton = this.btnLogIn;
            this.ClientSize = new System.Drawing.Size(660, 410);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.lblTagline);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.chkShow);
            this.Controls.Add(this.btnForget);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.lblCreate);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblStatus);
            this.Name = "LogInForm";
            this.Load += new System.EventHandler(this.LogInForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkShow;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnForget;
    }
}
