namespace FoodDeliverySystem.View
{
    partial class AdminRestaurants
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
            this.gridRestaurants = new System.Windows.Forms.DataGridView();
            this.lblOwner = new System.Windows.Forms.Label();
            this.cmbOwner = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnSuspend = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(340, 30);
            this.lblTitle.Text = "Manage Restaurants";
            this.lblTitle.AutoSize = true;
            //
            // gridRestaurants
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridRestaurants)).BeginInit();
            this.gridRestaurants.Location = new System.Drawing.Point(20, 60);
            this.gridRestaurants.Name = "gridRestaurants";
            this.gridRestaurants.Size = new System.Drawing.Size(890, 240);
            this.gridRestaurants.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRestaurants_CellClick);
            ((System.ComponentModel.ISupportInitialize)(this.gridRestaurants)).EndInit();
            //
            // lblOwner
            //
            this.lblOwner.Location = new System.Drawing.Point(20, 325);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Text = "Owner";
            this.lblOwner.AutoSize = true;
            //
            // cmbOwner
            //
            this.cmbOwner.Location = new System.Drawing.Point(140, 322);
            this.cmbOwner.Name = "cmbOwner";
            this.cmbOwner.Size = new System.Drawing.Size(260, 23);
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(20, 365);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Restaurant Name";
            this.lblName.AutoSize = true;
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(140, 362);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(260, 23);
            //
            // lblAddress
            //
            this.lblAddress.Location = new System.Drawing.Point(20, 405);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Text = "Address";
            this.lblAddress.AutoSize = true;
            //
            // txtAddress
            //
            this.txtAddress.Location = new System.Drawing.Point(140, 402);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(260, 23);
            //
            // lblPhone
            //
            this.lblPhone.Location = new System.Drawing.Point(20, 445);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Text = "Phone";
            this.lblPhone.AutoSize = true;
            //
            // txtPhone
            //
            this.txtPhone.Location = new System.Drawing.Point(140, 442);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(260, 23);
            //
            // lblId
            //
            this.lblId.Location = new System.Drawing.Point(430, 325);
            this.lblId.Name = "lblId";
            this.lblId.Text = "Restaurant Id";
            this.lblId.AutoSize = true;
            //
            // txtId
            //
            this.txtId.Location = new System.Drawing.Point(545, 322);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(90, 23);
            this.txtId.ReadOnly = true;
            //
            // btnAdd
            //
            this.btnAdd.Location = new System.Drawing.Point(430, 365);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 32);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnUpdate
            //
            this.btnUpdate.Location = new System.Drawing.Point(550, 365);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 32);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // btnApprove
            //
            this.btnApprove.Location = new System.Drawing.Point(430, 405);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(110, 32);
            this.btnApprove.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            //
            // btnSuspend
            //
            this.btnSuspend.Location = new System.Drawing.Point(550, 405);
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.Size = new System.Drawing.Size(110, 32);
            this.btnSuspend.Text = "Suspend";
            this.btnSuspend.Click += new System.EventHandler(this.btnSuspend_Click);
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(430, 445);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 32);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(550, 445);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 32);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // lblHint
            //
            this.lblHint.Location = new System.Drawing.Point(690, 330);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(220, 150);
            this.lblHint.Text = "One owner manages one restaurant.";
            this.lblHint.AutoSize = true;
            //
            // AdminRestaurants
            //
            this.ClientSize = new System.Drawing.Size(940, 580);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gridRestaurants);
            this.Controls.Add(this.lblOwner);
            this.Controls.Add(this.cmbOwner);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnSuspend);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblHint);
            this.Name = "AdminRestaurants";
            this.Load += new System.EventHandler(this.AdminRestaurants_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView gridRestaurants;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.ComboBox cmbOwner;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnSuspend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHint;
    }
}
