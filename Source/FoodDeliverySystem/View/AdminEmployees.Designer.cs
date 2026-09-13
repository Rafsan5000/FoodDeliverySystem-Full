namespace FoodDeliverySystem.View
{
    partial class AdminEmployees
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gridEmployees = new System.Windows.Forms.DataGridView();
            this.lblSectionAdd = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.lblJoining = new System.Windows.Forms.Label();
            this.dtpJoining = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 30);
            this.lblTitle.Text = "Employee Management";
            this.lblTitle.AutoSize = true;
            //
            // btnRefresh
            //
            this.btnRefresh.Location = new System.Drawing.Point(720, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 28);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(830, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // gridEmployees
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).BeginInit();
            this.gridEmployees.Location = new System.Drawing.Point(20, 60);
            this.gridEmployees.Name = "gridEmployees";
            this.gridEmployees.Size = new System.Drawing.Size(910, 230);
            this.gridEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEmployees_CellClick);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).EndInit();
            //
            // lblSectionAdd
            //
            this.lblSectionAdd.Location = new System.Drawing.Point(20, 305);
            this.lblSectionAdd.Name = "lblSectionAdd";
            this.lblSectionAdd.Size = new System.Drawing.Size(300, 24);
            this.lblSectionAdd.Text = "Hire a new employee";
            this.lblSectionAdd.AutoSize = true;
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(20, 345);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Full Name";
            this.lblName.AutoSize = true;
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(140, 342);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(220, 23);
            //
            // lblEmail
            //
            this.lblEmail.Location = new System.Drawing.Point(20, 385);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email";
            this.lblEmail.AutoSize = true;
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(140, 382);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(220, 23);
            //
            // lblPassword
            //
            this.lblPassword.Location = new System.Drawing.Point(20, 425);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Text = "Password";
            this.lblPassword.AutoSize = true;
            //
            // txtPassword
            //
            this.txtPassword.Location = new System.Drawing.Point(140, 422);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(220, 23);
            this.txtPassword.UseSystemPasswordChar = true;
            //
            // lblPhone
            //
            this.lblPhone.Location = new System.Drawing.Point(20, 465);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Text = "Phone";
            this.lblPhone.AutoSize = true;
            //
            // txtPhone
            //
            this.txtPhone.Location = new System.Drawing.Point(140, 462);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(220, 23);
            //
            // lblAddress
            //
            this.lblAddress.Location = new System.Drawing.Point(390, 345);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Text = "Address";
            this.lblAddress.AutoSize = true;
            //
            // txtAddress
            //
            this.txtAddress.Location = new System.Drawing.Point(500, 342);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(220, 23);
            //
            // lblPosition
            //
            this.lblPosition.Location = new System.Drawing.Point(390, 385);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Text = "Position";
            this.lblPosition.AutoSize = true;
            //
            // cmbPosition
            //
            this.cmbPosition.Location = new System.Drawing.Point(500, 382);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(220, 23);
            this.cmbPosition.Items.AddRange(new object[] { "Chef", "Waiter", "Delivery Rider", "Cashier", "Manager" });
            //
            // lblJoining
            //
            this.lblJoining.Location = new System.Drawing.Point(390, 425);
            this.lblJoining.Name = "lblJoining";
            this.lblJoining.Text = "Joining Date";
            this.lblJoining.AutoSize = true;
            //
            // dtpJoining
            //
            this.dtpJoining.Location = new System.Drawing.Point(500, 422);
            this.dtpJoining.Name = "dtpJoining";
            this.dtpJoining.Size = new System.Drawing.Size(220, 23);
            //
            // lblStatus
            //
            this.lblStatus.Location = new System.Drawing.Point(390, 465);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Status";
            this.lblStatus.AutoSize = true;
            //
            // cmbStatus
            //
            this.cmbStatus.Location = new System.Drawing.Point(500, 462);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(220, 23);
            this.cmbStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            //
            // lblId
            //
            this.lblId.Location = new System.Drawing.Point(750, 345);
            this.lblId.Name = "lblId";
            this.lblId.Text = "Employee Id";
            this.lblId.AutoSize = true;
            //
            // txtId
            //
            this.txtId.Location = new System.Drawing.Point(860, 342);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(70, 23);
            this.txtId.ReadOnly = true;
            //
            // btnAdd
            //
            this.btnAdd.Location = new System.Drawing.Point(750, 382);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(180, 32);
            this.btnAdd.Text = "Hire Employee";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnUpdate
            //
            this.btnUpdate.Location = new System.Drawing.Point(750, 422);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(180, 32);
            this.btnUpdate.Text = "Update Selected";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(750, 462);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(180, 32);
            this.btnDelete.Text = "Deactivate";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(750, 502);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(180, 32);
            this.btnClear.Text = "Clear form";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // lblInfo
            //
            this.lblInfo.Location = new System.Drawing.Point(20, 535);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(700, 24);
            this.lblInfo.Text = "";
            this.lblInfo.AutoSize = true;
            //
            // AdminEmployees
            //
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gridEmployees);
            this.Controls.Add(this.lblSectionAdd);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.lblJoining);
            this.Controls.Add(this.dtpJoining);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblInfo);
            this.Name = "AdminEmployees";
            this.Load += new System.EventHandler(this.AdminEmployees_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView gridEmployees;
        private System.Windows.Forms.Label lblSectionAdd;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label lblJoining;
        private System.Windows.Forms.DateTimePicker dtpJoining;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblInfo;
    }
}
