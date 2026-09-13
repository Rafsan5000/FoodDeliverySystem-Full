namespace FoodDeliverySystem.View
{
    partial class AdminCategories
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
            this.gridCategories = new System.Windows.Forms.DataGridView();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.Text = "Food Categories";
            this.lblTitle.AutoSize = true;
            //
            // gridCategories
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridCategories)).BeginInit();
            this.gridCategories.Location = new System.Drawing.Point(20, 60);
            this.gridCategories.Name = "gridCategories";
            this.gridCategories.Size = new System.Drawing.Size(710, 250);
            this.gridCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCategories_CellClick);
            ((System.ComponentModel.ISupportInitialize)(this.gridCategories)).EndInit();
            //
            // lblId
            //
            this.lblId.Location = new System.Drawing.Point(20, 335);
            this.lblId.Name = "lblId";
            this.lblId.Text = "Category Id";
            this.lblId.AutoSize = true;
            //
            // txtId
            //
            this.txtId.Location = new System.Drawing.Point(140, 332);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(80, 23);
            this.txtId.ReadOnly = true;
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(20, 375);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Category Name";
            this.lblName.AutoSize = true;
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(140, 372);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(230, 23);
            //
            // lblStatus
            //
            this.lblStatus.Location = new System.Drawing.Point(20, 415);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Status";
            this.lblStatus.AutoSize = true;
            //
            // cmbStatus
            //
            this.cmbStatus.Location = new System.Drawing.Point(140, 412);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(230, 23);
            this.cmbStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            //
            // btnAdd
            //
            this.btnAdd.Location = new System.Drawing.Point(400, 332);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 32);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnUpdate
            //
            this.btnUpdate.Location = new System.Drawing.Point(510, 332);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 32);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(400, 372);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 32);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(510, 372);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 32);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(620, 372);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 32);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // lblHint
            //
            this.lblHint.Location = new System.Drawing.Point(400, 415);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(320, 60);
            this.lblHint.Text = "";
            this.lblHint.AutoSize = true;
            //
            // AdminCategories
            //
            this.ClientSize = new System.Drawing.Size(760, 520);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gridCategories);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblHint);
            this.Name = "AdminCategories";
            this.Load += new System.EventHandler(this.AdminCategories_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView gridCategories;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHint;
    }
}
