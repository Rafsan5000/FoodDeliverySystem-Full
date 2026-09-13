namespace FoodDeliverySystem.View
{
    partial class SuperAdminDashBoard
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
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnRestaurants = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRestaurants = new System.Windows.Forms.Label();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.lblOrders = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.gridSummary = new System.Windows.Forms.DataGridView();
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
            this.lblPanel.Location = new System.Drawing.Point(35, 25);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Text = "Super Admin";
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
            // btnUsers
            //
            this.btnUsers.Location = new System.Drawing.Point(25, 115);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(130, 34);
            this.btnUsers.Text = "Users";
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            //
            // btnRestaurants
            //
            this.btnRestaurants.Location = new System.Drawing.Point(25, 160);
            this.btnRestaurants.Name = "btnRestaurants";
            this.btnRestaurants.Size = new System.Drawing.Size(130, 34);
            this.btnRestaurants.Text = "Restaurants";
            this.btnRestaurants.Click += new System.EventHandler(this.btnRestaurants_Click);
            //
            // btnCategories
            //
            this.btnCategories.Location = new System.Drawing.Point(25, 205);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(130, 34);
            this.btnCategories.Text = "Categories";
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            //
            // btnReports
            //
            this.btnReports.Location = new System.Drawing.Point(25, 250);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(130, 34);
            this.btnReports.Text = "Reports";
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            //
            // btnOrders
            //
            this.btnOrders.Location = new System.Drawing.Point(25, 295);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(130, 34);
            this.btnOrders.Text = "All Orders";
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
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
            this.lblWelcome.Location = new System.Drawing.Point(215, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(600, 30);
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.AutoSize = true;
            //
            // lblRestaurants
            //
            this.lblRestaurants.Location = new System.Drawing.Point(220, 75);
            this.lblRestaurants.Name = "lblRestaurants";
            this.lblRestaurants.Size = new System.Drawing.Size(300, 26);
            this.lblRestaurants.Text = "Total Restaurants:";
            this.lblRestaurants.AutoSize = true;
            //
            // lblCustomers
            //
            this.lblCustomers.Location = new System.Drawing.Point(220, 115);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(300, 26);
            this.lblCustomers.Text = "Total Customers:";
            this.lblCustomers.AutoSize = true;
            //
            // lblOrders
            //
            this.lblOrders.Location = new System.Drawing.Point(220, 155);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(300, 26);
            this.lblOrders.Text = "Total Orders:";
            this.lblOrders.AutoSize = true;
            //
            // lblRevenue
            //
            this.lblRevenue.Location = new System.Drawing.Point(220, 195);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(400, 26);
            this.lblRevenue.Text = "Total Revenue:";
            this.lblRevenue.AutoSize = true;
            //
            // lblGridTitle
            //
            this.lblGridTitle.Location = new System.Drawing.Point(220, 240);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(400, 22);
            this.lblGridTitle.Text = "Sales per restaurant";
            this.lblGridTitle.AutoSize = true;
            //
            // gridSummary
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).BeginInit();
            this.gridSummary.Location = new System.Drawing.Point(220, 268);
            this.gridSummary.Name = "gridSummary";
            this.gridSummary.Size = new System.Drawing.Size(690, 270);
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).EndInit();
            //
            // SuperAdminDashBoard
            //
            this.ClientSize = new System.Drawing.Size(940, 560);
            this.Controls.Add(this.pnlSide);
            this.pnlSide.Controls.Add(this.lblPanel);
            this.pnlSide.Controls.Add(this.btnDashboard);
            this.pnlSide.Controls.Add(this.btnUsers);
            this.pnlSide.Controls.Add(this.btnRestaurants);
            this.pnlSide.Controls.Add(this.btnCategories);
            this.pnlSide.Controls.Add(this.btnReports);
            this.pnlSide.Controls.Add(this.btnOrders);
            this.pnlSide.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblRestaurants);
            this.Controls.Add(this.lblCustomers);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.lblRevenue);
            this.Controls.Add(this.lblGridTitle);
            this.Controls.Add(this.gridSummary);
            this.Name = "SuperAdminDashBoard";
            this.Load += new System.EventHandler(this.SuperAdminDashBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Label lblPanel;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnRestaurants;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRestaurants;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.DataGridView gridSummary;
    }
}
