namespace FoodDeliverySystem.View
{
    partial class ForgetPassword
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
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblNew = new System.Windows.Forms.Label();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Location = new System.Drawing.Point(140, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(230, 34);
            this.lblTitle.Text = "Reset your password";
            this.lblTitle.AutoSize = true;
            //
            // lblEmail
            //
            this.lblEmail.Location = new System.Drawing.Point(40, 85);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Registered Email";
            this.lblEmail.AutoSize = true;
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(190, 82);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(260, 23);
            //
            // lblPhone
            //
            this.lblPhone.Location = new System.Drawing.Point(40, 125);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Text = "Registered Phone";
            this.lblPhone.AutoSize = true;
            //
            // txtPhone
            //
            this.txtPhone.Location = new System.Drawing.Point(190, 122);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(260, 23);
            //
            // lblNew
            //
            this.lblNew.Location = new System.Drawing.Point(40, 165);
            this.lblNew.Name = "lblNew";
            this.lblNew.Text = "New Password";
            this.lblNew.AutoSize = true;
            //
            // txtNew
            //
            this.txtNew.Location = new System.Drawing.Point(190, 162);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(260, 23);
            this.txtNew.UseSystemPasswordChar = true;
            //
            // lblConfirm
            //
            this.lblConfirm.Location = new System.Drawing.Point(40, 205);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Text = "Confirm Password";
            this.lblConfirm.AutoSize = true;
            //
            // txtConfirm
            //
            this.txtConfirm.Location = new System.Drawing.Point(190, 202);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(260, 23);
            this.txtConfirm.UseSystemPasswordChar = true;
            //
            // btnReset
            //
            this.btnReset.Location = new System.Drawing.Point(190, 250);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 36);
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(330, 250);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // ForgetPassword
            //
            this.AcceptButton = this.btnReset;
            this.ClientSize = new System.Drawing.Size(500, 330);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnClose);
            this.Name = "ForgetPassword";
            this.Load += new System.EventHandler(this.ForgetPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;
    }
}
