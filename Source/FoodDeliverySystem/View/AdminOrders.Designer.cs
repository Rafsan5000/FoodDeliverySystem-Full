namespace FoodDeliverySystem.View
{
    partial class AdminOrders
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gridOrders = new System.Windows.Forms.DataGridView();
            this.lblItemsTitle = new System.Windows.Forms.Label();
            this.gridItems = new System.Windows.Forms.DataGridView();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblNewStatus = new System.Windows.Forms.Label();
            this.cmbNewStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnMarkPaid = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(420, 30);
            this.lblTitle.Text = "Manage Orders";
            this.lblTitle.AutoSize = true;
            //
            // lblStatus
            //
            this.lblStatus.Location = new System.Drawing.Point(20, 62);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Status";
            this.lblStatus.AutoSize = true;
            //
            // cmbStatus
            //
            this.cmbStatus.Location = new System.Drawing.Point(75, 59);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 23);
            this.cmbStatus.Items.AddRange(new object[] { "All", "Pending", "Accepted", "Preparing", "Completed", "Cancelled" });
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            //
            // btnRefresh
            //
            this.btnRefresh.Location = new System.Drawing.Point(240, 57);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 28);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // btnInvoice
            //
            this.btnInvoice.Location = new System.Drawing.Point(360, 57);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(110, 28);
            this.btnInvoice.Text = "View Invoice";
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(850, 57);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // gridOrders
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).BeginInit();
            this.gridOrders.Location = new System.Drawing.Point(20, 100);
            this.gridOrders.Name = "gridOrders";
            this.gridOrders.Size = new System.Drawing.Size(930, 230);
            this.gridOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOrders_CellClick);
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).EndInit();
            //
            // lblItemsTitle
            //
            this.lblItemsTitle.Location = new System.Drawing.Point(20, 345);
            this.lblItemsTitle.Name = "lblItemsTitle";
            this.lblItemsTitle.Size = new System.Drawing.Size(400, 24);
            this.lblItemsTitle.Text = "Items in the selected order";
            this.lblItemsTitle.AutoSize = true;
            //
            // gridItems
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.gridItems.Location = new System.Drawing.Point(20, 375);
            this.gridItems.Name = "gridItems";
            this.gridItems.Size = new System.Drawing.Size(600, 170);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            //
            // lblOrderId
            //
            this.lblOrderId.Location = new System.Drawing.Point(650, 345);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Text = "Order Id";
            this.lblOrderId.AutoSize = true;
            //
            // txtOrderId
            //
            this.txtOrderId.Location = new System.Drawing.Point(760, 342);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(90, 23);
            this.txtOrderId.ReadOnly = true;
            //
            // lblCurrent
            //
            this.lblCurrent.Location = new System.Drawing.Point(650, 385);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(290, 22);
            this.lblCurrent.Text = "Current status:";
            this.lblCurrent.AutoSize = true;
            //
            // lblNewStatus
            //
            this.lblNewStatus.Location = new System.Drawing.Point(650, 420);
            this.lblNewStatus.Name = "lblNewStatus";
            this.lblNewStatus.Text = "New status";
            this.lblNewStatus.AutoSize = true;
            //
            // cmbNewStatus
            //
            this.cmbNewStatus.Location = new System.Drawing.Point(760, 417);
            this.cmbNewStatus.Name = "cmbNewStatus";
            this.cmbNewStatus.Size = new System.Drawing.Size(180, 23);
            this.cmbNewStatus.Items.AddRange(new object[] { "Accepted", "Preparing", "Completed", "Cancelled" });
            //
            // btnUpdateStatus
            //
            this.btnUpdateStatus.Location = new System.Drawing.Point(650, 460);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(140, 34);
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            //
            // btnMarkPaid
            //
            this.btnMarkPaid.Location = new System.Drawing.Point(800, 460);
            this.btnMarkPaid.Name = "btnMarkPaid";
            this.btnMarkPaid.Size = new System.Drawing.Size(140, 34);
            this.btnMarkPaid.Text = "Mark Paid";
            this.btnMarkPaid.Click += new System.EventHandler(this.btnMarkPaid_Click);
            //
            // btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(650, 505);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(140, 32);
            this.btnDelete.Text = "Delete Order";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // lblInfo
            //
            this.lblInfo.Location = new System.Drawing.Point(20, 555);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(930, 24);
            this.lblInfo.Text = "";
            this.lblInfo.AutoSize = true;
            //
            // AdminOrders
            //
            this.ClientSize = new System.Drawing.Size(980, 620);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gridOrders);
            this.Controls.Add(this.lblItemsTitle);
            this.Controls.Add(this.gridItems);
            this.Controls.Add(this.lblOrderId);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.lblNewStatus);
            this.Controls.Add(this.cmbNewStatus);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.btnMarkPaid);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblInfo);
            this.Name = "AdminOrders";
            this.Load += new System.EventHandler(this.AdminOrders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView gridOrders;
        private System.Windows.Forms.Label lblItemsTitle;
        private System.Windows.Forms.DataGridView gridItems;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblNewStatus;
        private System.Windows.Forms.ComboBox cmbNewStatus;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnMarkPaid;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblInfo;
    }
}
