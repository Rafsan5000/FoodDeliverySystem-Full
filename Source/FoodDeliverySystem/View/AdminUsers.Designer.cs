namespace FoodDeliverySystem.View
{
    partial class AdminUsers
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
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gridUsers = new System.Windows.Forms.DataGridView();
            this.lblEditTitle = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblNewRole = new System.Windows.Forms.Label();
            this.cmbNewRole = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnChangeRole = new System.Windows.Forms.Button();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnSuspend = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 30);
            this.lblTitle.Text = "Manage Users";
            this.lblTitle.AutoSize = true;
            //
            // lblSearch
            //
            this.lblSearch.Location = new System.Drawing.Point(20, 65);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "Search";
            this.lblSearch.AutoSize = true;
            //
            // txtSearch
            //
            this.txtSearch.Location = new System.Drawing.Point(80, 62);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 23);
            //
            // lblRole
            //
            this.lblRole.Location = new System.Drawing.Point(300, 65);
            this.lblRole.Name = "lblRole";
            this.lblRole.Text = "Role";
            this.lblRole.AutoSize = true;
            //
            // cmbRole
            //
            this.cmbRole.Location = new System.Drawing.Point(345, 62);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(150, 23);
            this.cmbRole.Items.AddRange(new object[] { "All", "SuperAdmin", "RestaurantAdmin", "Employee", "Customer" });
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            //
            // lblStatus
            //
            this.lblStatus.Location = new System.Drawing.Point(510, 65);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Status";
            this.lblStatus.AutoSize = true;
            //
            // cmbStatus
            //
            this.cmbStatus.Location = new System.Drawing.Point(565, 62);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(120, 23);
            this.cmbStatus.Items.AddRange(new object[] { "All", "Active", "Inactive", "Pending" });
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            //
            // btnSearch
            //
            this.btnSearch.Location = new System.Drawing.Point(700, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // btnRefresh
            //
            this.btnRefresh.Location = new System.Drawing.Point(810, 60);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 28);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // gridUsers
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            this.gridUsers.Location = new System.Drawing.Point(20, 105);
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.Size = new System.Drawing.Size(930, 240);
            this.gridUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUsers_CellClick);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            //
            // lblEditTitle
            //
            this.lblEditTitle.Location = new System.Drawing.Point(20, 360);
            this.lblEditTitle.Name = "lblEditTitle";
            this.lblEditTitle.Size = new System.Drawing.Size(300, 24);
            this.lblEditTitle.Text = "Selected user";
            this.lblEditTitle.AutoSize = true;
            //
            // lblId
            //
            this.lblId.Location = new System.Drawing.Point(20, 400);
            this.lblId.Name = "lblId";
            this.lblId.Text = "User Id";
            this.lblId.AutoSize = true;
            //
            // txtId
            //
            this.txtId.Location = new System.Drawing.Point(140, 397);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(90, 23);
            this.txtId.ReadOnly = true;
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(20, 440);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Name";
            this.lblName.AutoSize = true;
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(140, 437);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(230, 23);
            //
            // lblEmail
            //
            this.lblEmail.Location = new System.Drawing.Point(20, 480);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email";
            this.lblEmail.AutoSize = true;
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(140, 477);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(230, 23);
            //
            // lblPhone
            //
            this.lblPhone.Location = new System.Drawing.Point(400, 440);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Text = "Phone";
            this.lblPhone.AutoSize = true;
            //
            // txtPhone
            //
            this.txtPhone.Location = new System.Drawing.Point(500, 437);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 23);
            //
            // lblAddress
            //
            this.lblAddress.Location = new System.Drawing.Point(400, 480);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Text = "Address";
            this.lblAddress.AutoSize = true;
            //
            // txtAddress
            //
            this.txtAddress.Location = new System.Drawing.Point(500, 477);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 23);
            //
            // lblNewRole
            //
            this.lblNewRole.Location = new System.Drawing.Point(400, 400);
            this.lblNewRole.Name = "lblNewRole";
            this.lblNewRole.Text = "Role";
            this.lblNewRole.AutoSize = true;
            //
            // cmbNewRole
            //
            this.cmbNewRole.Location = new System.Drawing.Point(500, 397);
            this.cmbNewRole.Name = "cmbNewRole";
            this.cmbNewRole.Size = new System.Drawing.Size(200, 23);
            this.cmbNewRole.Items.AddRange(new object[] { "SuperAdmin", "RestaurantAdmin", "Employee", "Customer" });
            //
            // btnUpdate
            //
            this.btnUpdate.Location = new System.Drawing.Point(730, 397);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 30);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // btnChangeRole
            //
            this.btnChangeRole.Location = new System.Drawing.Point(845, 397);
            this.btnChangeRole.Name = "btnChangeRole";
            this.btnChangeRole.Size = new System.Drawing.Size(105, 30);
            this.btnChangeRole.Text = "Set Role";
            this.btnChangeRole.Click += new System.EventHandler(this.btnChangeRole_Click);
            //
            // btnActivate
            //
            this.btnActivate.Location = new System.Drawing.Point(730, 437);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(105, 30);
            this.btnActivate.Text = "Activate";
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            //
            // btnSuspend
            //
            this.btnSuspend.Location = new System.Drawing.Point(845, 437);
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.Size = new System.Drawing.Size(105, 30);
            this.btnSuspend.Text = "Suspend";
            this.btnSuspend.Click += new System.EventHandler(this.btnSuspend_Click);
            //
            // btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(730, 477);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 30);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(845, 477);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 30);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // lblCount
            //
            this.lblCount.Location = new System.Drawing.Point(20, 545);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(500, 20);
            this.lblCount.Text = "";
            this.lblCount.AutoSize = true;
            //
            // AdminUsers
            //
            this.ClientSize = new System.Drawing.Size(980, 620);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.gridUsers);
            this.Controls.Add(this.lblEditTitle);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblNewRole);
            this.Controls.Add(this.cmbNewRole);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnChangeRole);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.btnSuspend);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblCount);
            this.Name = "AdminUsers";
            this.Load += new System.EventHandler(this.AdminUsers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView gridUsers;
        private System.Windows.Forms.Label lblEditTitle;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblNewRole;
        private System.Windows.Forms.ComboBox cmbNewRole;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnChangeRole;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnSuspend;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCount;
    }
}
