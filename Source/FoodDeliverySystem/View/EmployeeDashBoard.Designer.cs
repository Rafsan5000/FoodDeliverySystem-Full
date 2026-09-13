namespace FoodDeliverySystem.View
{
    partial class EmployeeDashBoard
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnMyProfile = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.gridOrders = new System.Windows.Forms.DataGridView();
            this.lblTicketTitle = new System.Windows.Forms.Label();
            this.gridTicket = new System.Windows.Forms.DataGridView();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblNewStatus = new System.Windows.Forms.Label();
            this.cmbNewStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnMarkPaid = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // pnlSide
            //
            this.pnlSide.Location = new System.Drawing.Point(10, 10);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(170, 575);
            //
            // lblPanel
            //
            this.lblPanel.Location = new System.Drawing.Point(35, 25);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Text = "Employee Panel";
            this.lblPanel.AutoSize = true;
            //
            // btnRefresh
            //
            this.btnRefresh.Location = new System.Drawing.Point(20, 70);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 34);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // btnInvoice
            //
            this.btnInvoice.Location = new System.Drawing.Point(20, 115);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(130, 34);
            this.btnInvoice.Text = "View Invoice";
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            //
            // btnMyProfile
            //
            this.btnMyProfile.Location = new System.Drawing.Point(20, 160);
            this.btnMyProfile.Name = "btnMyProfile";
            this.btnMyProfile.Size = new System.Drawing.Size(130, 34);
            this.btnMyProfile.Text = "My Profile";
            this.btnMyProfile.Click += new System.EventHandler(this.btnMyProfile_Click);
            //
            // btnLogOut
            //
            this.btnLogOut.Location = new System.Drawing.Point(20, 510);
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
            // lblStatusFilter
            //
            this.lblStatusFilter.Location = new System.Drawing.Point(200, 60);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Text = "Show";
            this.lblStatusFilter.AutoSize = true;
            //
            // cmbStatus
            //
            this.cmbStatus.Location = new System.Drawing.Point(255, 57);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(160, 23);
            this.cmbStatus.Items.AddRange(new object[] { "All", "Pending", "Accepted", "Preparing", "Completed", "Cancelled" });
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            //
            // lblCount
            //
            this.lblCount.Location = new System.Drawing.Point(430, 60);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(400, 22);
            this.lblCount.Text = "";
            this.lblCount.AutoSize = true;
            //
            // gridOrders
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).BeginInit();
            this.gridOrders.Location = new System.Drawing.Point(200, 95);
            this.gridOrders.Name = "gridOrders";
            this.gridOrders.Size = new System.Drawing.Size(730, 215);
            this.gridOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOrders_CellClick);
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).EndInit();
            //
            // lblTicketTitle
            //
            this.lblTicketTitle.Location = new System.Drawing.Point(200, 325);
            this.lblTicketTitle.Name = "lblTicketTitle";
            this.lblTicketTitle.Size = new System.Drawing.Size(400, 24);
            this.lblTicketTitle.Text = "Kitchen ticket for the selected order";
            this.lblTicketTitle.AutoSize = true;
            //
            // gridTicket
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridTicket)).BeginInit();
            this.gridTicket.Location = new System.Drawing.Point(200, 355);
            this.gridTicket.Name = "gridTicket";
            this.gridTicket.Size = new System.Drawing.Size(450, 180);
            ((System.ComponentModel.ISupportInitialize)(this.gridTicket)).EndInit();
            //
            // lblOrderId
            //
            this.lblOrderId.Location = new System.Drawing.Point(670, 325);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Text = "Order Id";
            this.lblOrderId.AutoSize = true;
            //
            // txtOrderId
            //
            this.txtOrderId.Location = new System.Drawing.Point(780, 322);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(80, 23);
            this.txtOrderId.ReadOnly = true;
            //
            // lblCurrent
            //
            this.lblCurrent.Location = new System.Drawing.Point(670, 360);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(260, 22);
            this.lblCurrent.Text = "Current status:";
            this.lblCurrent.AutoSize = true;
            //
            // lblNewStatus
            //
            this.lblNewStatus.Location = new System.Drawing.Point(670, 395);
            this.lblNewStatus.Name = "lblNewStatus";
            this.lblNewStatus.Text = "New status";
            this.lblNewStatus.AutoSize = true;
            //
            // cmbNewStatus
            //
            this.cmbNewStatus.Location = new System.Drawing.Point(670, 420);
            this.cmbNewStatus.Name = "cmbNewStatus";
            this.cmbNewStatus.Size = new System.Drawing.Size(260, 23);
            this.cmbNewStatus.Items.AddRange(new object[] { "Accepted", "Preparing", "Completed", "Cancelled" });
            //
            // btnUpdateStatus
            //
            this.btnUpdateStatus.Location = new System.Drawing.Point(670, 455);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(260, 34);
            this.btnUpdateStatus.Text = "Update Order Status";
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            //
            // btnMarkPaid
            //
            this.btnMarkPaid.Location = new System.Drawing.Point(670, 498);
            this.btnMarkPaid.Name = "btnMarkPaid";
            this.btnMarkPaid.Size = new System.Drawing.Size(260, 34);
            this.btnMarkPaid.Text = "Mark Payment Received";
            this.btnMarkPaid.Click += new System.EventHandler(this.btnMarkPaid_Click);
            //
            // lblInfo
            //
            this.lblInfo.Location = new System.Drawing.Point(200, 545);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(730, 24);
            this.lblInfo.Text = "";
            this.lblInfo.AutoSize = true;
            //
            // EmployeeDashBoard
            //
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.pnlSide);
            this.pnlSide.Controls.Add(this.lblPanel);
            this.pnlSide.Controls.Add(this.btnRefresh);
            this.pnlSide.Controls.Add(this.btnInvoice);
            this.pnlSide.Controls.Add(this.btnMyProfile);
            this.pnlSide.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblStatusFilter);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.gridOrders);
            this.Controls.Add(this.lblTicketTitle);
            this.Controls.Add(this.gridTicket);
            this.Controls.Add(this.lblOrderId);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.lblNewStatus);
            this.Controls.Add(this.cmbNewStatus);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.btnMarkPaid);
            this.Controls.Add(this.lblInfo);
            this.Name = "EmployeeDashBoard";
            this.Load += new System.EventHandler(this.EmployeeDashBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Label lblPanel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnMyProfile;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView gridOrders;
        private System.Windows.Forms.Label lblTicketTitle;
        private System.Windows.Forms.DataGridView gridTicket;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblNewStatus;
        private System.Windows.Forms.ComboBox cmbNewStatus;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnMarkPaid;
        private System.Windows.Forms.Label lblInfo;
    }
}
