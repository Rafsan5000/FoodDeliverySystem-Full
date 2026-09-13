namespace FoodDeliverySystem.View
{
    partial class CustomerDashBoard
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
            this.pnlSide = new System.Windows.Forms.Panel();
            this.lblPanel = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCart = new System.Windows.Forms.Button();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblProfileTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.lblPwdTitle = new System.Windows.Forms.Label();
            this.lblOldPwd = new System.Windows.Forms.Label();
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.lblNewPwd = new System.Windows.Forms.Label();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.lblConfirmPwd = new System.Windows.Forms.Label();
            this.txtConfirmPwd = new System.Windows.Forms.TextBox();
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnViewOrder = new System.Windows.Forms.Button();
            this.gridOrders = new System.Windows.Forms.DataGridView();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // pnlSide
            //
            this.pnlSide.Location = new System.Drawing.Point(10, 10);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(170, 595);
            //
            // lblPanel
            //
            this.lblPanel.Location = new System.Drawing.Point(35, 25);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Text = "Customer Panel";
            this.lblPanel.AutoSize = true;
            //
            // btnDashboard
            //
            this.btnDashboard.Location = new System.Drawing.Point(20, 70);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(130, 34);
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            //
            // btnBrowse
            //
            this.btnBrowse.Location = new System.Drawing.Point(20, 115);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(130, 34);
            this.btnBrowse.Text = "Browse Food";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            //
            // btnCart
            //
            this.btnCart.Location = new System.Drawing.Point(20, 160);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(130, 34);
            this.btnCart.Text = "My Cart";
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            //
            // btnInvoice
            //
            this.btnInvoice.Location = new System.Drawing.Point(20, 205);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(130, 34);
            this.btnInvoice.Text = "View Invoice";
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            //
            // btnLogOut
            //
            this.btnLogOut.Location = new System.Drawing.Point(20, 530);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(130, 34);
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            //
            // lblWelcome
            //
            this.lblWelcome.Location = new System.Drawing.Point(200, 18);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(730, 28);
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.AutoSize = true;
            //
            // lblProfileTitle
            //
            this.lblProfileTitle.Location = new System.Drawing.Point(200, 58);
            this.lblProfileTitle.Name = "lblProfileTitle";
            this.lblProfileTitle.Size = new System.Drawing.Size(300, 24);
            this.lblProfileTitle.Text = "My profile";
            this.lblProfileTitle.AutoSize = true;
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(200, 95);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Name";
            this.lblName.AutoSize = true;
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(300, 92);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(220, 23);
            //
            // lblEmail
            //
            this.lblEmail.Location = new System.Drawing.Point(200, 135);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email";
            this.lblEmail.AutoSize = true;
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(300, 132);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(220, 23);
            //
            // lblPhone
            //
            this.lblPhone.Location = new System.Drawing.Point(200, 175);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Text = "Phone";
            this.lblPhone.AutoSize = true;
            //
            // txtPhone
            //
            this.txtPhone.Location = new System.Drawing.Point(300, 172);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(220, 23);
            //
            // lblAddress
            //
            this.lblAddress.Location = new System.Drawing.Point(200, 215);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Text = "Address";
            this.lblAddress.AutoSize = true;
            //
            // txtAddress
            //
            this.txtAddress.Location = new System.Drawing.Point(300, 212);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(220, 23);
            //
            // btnSaveProfile
            //
            this.btnSaveProfile.Location = new System.Drawing.Point(300, 248);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(220, 32);
            this.btnSaveProfile.Text = "Save Profile";
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
            //
            // lblPwdTitle
            //
            this.lblPwdTitle.Location = new System.Drawing.Point(560, 58);
            this.lblPwdTitle.Name = "lblPwdTitle";
            this.lblPwdTitle.Size = new System.Drawing.Size(320, 24);
            this.lblPwdTitle.Text = "Change password";
            this.lblPwdTitle.AutoSize = true;
            //
            // lblOldPwd
            //
            this.lblOldPwd.Location = new System.Drawing.Point(560, 95);
            this.lblOldPwd.Name = "lblOldPwd";
            this.lblOldPwd.Text = "Current";
            this.lblOldPwd.AutoSize = true;
            //
            // txtOldPwd
            //
            this.txtOldPwd.Location = new System.Drawing.Point(660, 92);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.Size = new System.Drawing.Size(220, 23);
            this.txtOldPwd.UseSystemPasswordChar = true;
            //
            // lblNewPwd
            //
            this.lblNewPwd.Location = new System.Drawing.Point(560, 135);
            this.lblNewPwd.Name = "lblNewPwd";
            this.lblNewPwd.Text = "New";
            this.lblNewPwd.AutoSize = true;
            //
            // txtNewPwd
            //
            this.txtNewPwd.Location = new System.Drawing.Point(660, 132);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Size = new System.Drawing.Size(220, 23);
            this.txtNewPwd.UseSystemPasswordChar = true;
            //
            // lblConfirmPwd
            //
            this.lblConfirmPwd.Location = new System.Drawing.Point(560, 175);
            this.lblConfirmPwd.Name = "lblConfirmPwd";
            this.lblConfirmPwd.Text = "Confirm";
            this.lblConfirmPwd.AutoSize = true;
            //
            // txtConfirmPwd
            //
            this.txtConfirmPwd.Location = new System.Drawing.Point(660, 172);
            this.txtConfirmPwd.Name = "txtConfirmPwd";
            this.txtConfirmPwd.Size = new System.Drawing.Size(220, 23);
            this.txtConfirmPwd.UseSystemPasswordChar = true;
            //
            // btnChangePwd
            //
            this.btnChangePwd.Location = new System.Drawing.Point(660, 210);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(220, 32);
            this.btnChangePwd.Text = "Change Password";
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            //
            // lblHistoryTitle
            //
            this.lblHistoryTitle.Location = new System.Drawing.Point(200, 295);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(300, 24);
            this.lblHistoryTitle.Text = "Order history";
            this.lblHistoryTitle.AutoSize = true;
            //
            // btnRefresh
            //
            this.btnRefresh.Location = new System.Drawing.Point(560, 292);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 28);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // btnCancelOrder
            //
            this.btnCancelOrder.Location = new System.Drawing.Point(680, 292);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(130, 28);
            this.btnCancelOrder.Text = "Cancel Order";
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            //
            // btnViewOrder
            //
            this.btnViewOrder.Location = new System.Drawing.Point(820, 292);
            this.btnViewOrder.Name = "btnViewOrder";
            this.btnViewOrder.Size = new System.Drawing.Size(110, 28);
            this.btnViewOrder.Text = "Invoice";
            this.btnViewOrder.Click += new System.EventHandler(this.btnViewOrder_Click);
            //
            // gridOrders
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).BeginInit();
            this.gridOrders.Location = new System.Drawing.Point(200, 328);
            this.gridOrders.Name = "gridOrders";
            this.gridOrders.Size = new System.Drawing.Size(730, 230);
            this.gridOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOrders_CellClick);
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).EndInit();
            //
            // lblInfo
            //
            this.lblInfo.Location = new System.Drawing.Point(200, 568);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(730, 24);
            this.lblInfo.Text = "";
            this.lblInfo.AutoSize = true;
            //
            // CustomerDashBoard
            //
            this.ClientSize = new System.Drawing.Size(960, 620);
            this.Controls.Add(this.pnlSide);
            this.pnlSide.Controls.Add(this.lblPanel);
            this.pnlSide.Controls.Add(this.btnDashboard);
            this.pnlSide.Controls.Add(this.btnBrowse);
            this.pnlSide.Controls.Add(this.btnCart);
            this.pnlSide.Controls.Add(this.btnInvoice);
            this.pnlSide.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblProfileTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnSaveProfile);
            this.Controls.Add(this.lblPwdTitle);
            this.Controls.Add(this.lblOldPwd);
            this.Controls.Add(this.txtOldPwd);
            this.Controls.Add(this.lblNewPwd);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.lblConfirmPwd);
            this.Controls.Add(this.txtConfirmPwd);
            this.Controls.Add(this.btnChangePwd);
            this.Controls.Add(this.lblHistoryTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCancelOrder);
            this.Controls.Add(this.btnViewOrder);
            this.Controls.Add(this.gridOrders);
            this.Controls.Add(this.lblInfo);
            this.Name = "CustomerDashBoard";
            this.Load += new System.EventHandler(this.CustomerDashBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Label lblPanel;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblProfileTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSaveProfile;
        private System.Windows.Forms.Label lblPwdTitle;
        private System.Windows.Forms.Label lblOldPwd;
        private System.Windows.Forms.TextBox txtOldPwd;
        private System.Windows.Forms.Label lblNewPwd;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.Label lblConfirmPwd;
        private System.Windows.Forms.TextBox txtConfirmPwd;
        private System.Windows.Forms.Button btnChangePwd;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnViewOrder;
        private System.Windows.Forms.DataGridView gridOrders;
        private System.Windows.Forms.Label lblInfo;
    }
}
