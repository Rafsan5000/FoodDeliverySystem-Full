namespace FoodDeliverySystem.View
{
    partial class RestaurantDashBoard
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
            this.btnFoods = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblProfileTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.lblFoods = new System.Windows.Forms.Label();
            this.lblEmployeesCount = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.lblLowStockTitle = new System.Windows.Forms.Label();
            this.gridLowStock = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            //
            // pnlSide
            //
            this.pnlSide.Location = new System.Drawing.Point(10, 10);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(180, 535);
            //
            // lblPanel
            //
            this.lblPanel.Location = new System.Drawing.Point(30, 25);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Text = "Restaurant Panel";
            this.lblPanel.AutoSize = true;
            //
            // btnDashboard
            //
            this.btnDashboard.Location = new System.Drawing.Point(25, 70);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(130, 34);
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            //
            // btnFoods
            //
            this.btnFoods.Location = new System.Drawing.Point(25, 115);
            this.btnFoods.Name = "btnFoods";
            this.btnFoods.Size = new System.Drawing.Size(130, 34);
            this.btnFoods.Text = "Foods";
            this.btnFoods.Click += new System.EventHandler(this.btnFoods_Click);
            //
            // btnEmployees
            //
            this.btnEmployees.Location = new System.Drawing.Point(25, 160);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(130, 34);
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            //
            // btnOrders
            //
            this.btnOrders.Location = new System.Drawing.Point(25, 205);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(130, 34);
            this.btnOrders.Text = "Orders";
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            //
            // btnReports
            //
            this.btnReports.Location = new System.Drawing.Point(25, 250);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(130, 34);
            this.btnReports.Text = "Reports";
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            //
            // btnLogOut
            //
            this.btnLogOut.Location = new System.Drawing.Point(25, 470);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(130, 34);
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            //
            // lblWelcome
            //
            this.lblWelcome.Location = new System.Drawing.Point(215, 18);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(700, 30);
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.AutoSize = true;
            //
            // lblProfileTitle
            //
            this.lblProfileTitle.Location = new System.Drawing.Point(215, 60);
            this.lblProfileTitle.Name = "lblProfileTitle";
            this.lblProfileTitle.Size = new System.Drawing.Size(300, 24);
            this.lblProfileTitle.Text = "Restaurant profile";
            this.lblProfileTitle.AutoSize = true;
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(215, 100);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Name";
            this.lblName.AutoSize = true;
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(330, 97);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 23);
            //
            // lblAddress
            //
            this.lblAddress.Location = new System.Drawing.Point(215, 140);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Text = "Address";
            this.lblAddress.AutoSize = true;
            //
            // txtAddress
            //
            this.txtAddress.Location = new System.Drawing.Point(330, 137);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(250, 23);
            //
            // lblPhone
            //
            this.lblPhone.Location = new System.Drawing.Point(215, 180);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Text = "Phone";
            this.lblPhone.AutoSize = true;
            //
            // txtPhone
            //
            this.txtPhone.Location = new System.Drawing.Point(330, 177);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 23);
            //
            // btnSaveProfile
            //
            this.btnSaveProfile.Location = new System.Drawing.Point(330, 215);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(130, 32);
            this.btnSaveProfile.Text = "Save Profile";
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
            //
            // lblFoods
            //
            this.lblFoods.Location = new System.Drawing.Point(620, 100);
            this.lblFoods.Name = "lblFoods";
            this.lblFoods.Size = new System.Drawing.Size(290, 24);
            this.lblFoods.Text = "Total Foods:";
            this.lblFoods.AutoSize = true;
            //
            // lblEmployeesCount
            //
            this.lblEmployeesCount.Location = new System.Drawing.Point(620, 140);
            this.lblEmployeesCount.Name = "lblEmployeesCount";
            this.lblEmployeesCount.Size = new System.Drawing.Size(290, 24);
            this.lblEmployeesCount.Text = "Total Employees:";
            this.lblEmployeesCount.AutoSize = true;
            //
            // lblPending
            //
            this.lblPending.Location = new System.Drawing.Point(620, 180);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(290, 24);
            this.lblPending.Text = "Pending Orders:";
            this.lblPending.AutoSize = true;
            //
            // lblRevenue
            //
            this.lblRevenue.Location = new System.Drawing.Point(620, 220);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(290, 24);
            this.lblRevenue.Text = "Revenue:";
            this.lblRevenue.AutoSize = true;
            //
            // lblLowStockTitle
            //
            this.lblLowStockTitle.Location = new System.Drawing.Point(215, 265);
            this.lblLowStockTitle.Name = "lblLowStockTitle";
            this.lblLowStockTitle.Size = new System.Drawing.Size(400, 24);
            this.lblLowStockTitle.Text = "Low stock items (10 or fewer left)";
            this.lblLowStockTitle.AutoSize = true;
            //
            // gridLowStock
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridLowStock)).BeginInit();
            this.gridLowStock.Location = new System.Drawing.Point(215, 295);
            this.gridLowStock.Name = "gridLowStock";
            this.gridLowStock.Size = new System.Drawing.Size(695, 240);
            ((System.ComponentModel.ISupportInitialize)(this.gridLowStock)).EndInit();
            //
            // RestaurantDashBoard
            //
            this.ClientSize = new System.Drawing.Size(940, 560);
            this.Controls.Add(this.pnlSide);
            this.pnlSide.Controls.Add(this.lblPanel);
            this.pnlSide.Controls.Add(this.btnDashboard);
            this.pnlSide.Controls.Add(this.btnFoods);
            this.pnlSide.Controls.Add(this.btnEmployees);
            this.pnlSide.Controls.Add(this.btnOrders);
            this.pnlSide.Controls.Add(this.btnReports);
            this.pnlSide.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblProfileTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnSaveProfile);
            this.Controls.Add(this.lblFoods);
            this.Controls.Add(this.lblEmployeesCount);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.lblRevenue);
            this.Controls.Add(this.lblLowStockTitle);
            this.Controls.Add(this.gridLowStock);
            this.Name = "RestaurantDashBoard";
            this.Load += new System.EventHandler(this.RestaurantDashBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Label lblPanel;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnFoods;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblProfileTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnSaveProfile;
        private System.Windows.Forms.Label lblFoods;
        private System.Windows.Forms.Label lblEmployeesCount;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label lblLowStockTitle;
        private System.Windows.Forms.DataGridView gridLowStock;
    }
}
