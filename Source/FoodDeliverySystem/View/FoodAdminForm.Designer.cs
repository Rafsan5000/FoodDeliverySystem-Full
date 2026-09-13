namespace FoodDeliverySystem.View
{
    partial class FoodAdminForm
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
            this.gridFoods = new System.Windows.Forms.DataGridView();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblAddStock = new System.Windows.Forms.Label();
            this.txtAddStock = new System.Windows.Forms.TextBox();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(420, 30);
            this.lblTitle.Text = "Food Management";
            this.lblTitle.AutoSize = true;
            //
            // btnRefresh
            //
            this.btnRefresh.Location = new System.Drawing.Point(730, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 28);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(845, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // gridFoods
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridFoods)).BeginInit();
            this.gridFoods.Location = new System.Drawing.Point(20, 60);
            this.gridFoods.Name = "gridFoods";
            this.gridFoods.Size = new System.Drawing.Size(930, 250);
            this.gridFoods.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFoods_CellClick);
            ((System.ComponentModel.ISupportInitialize)(this.gridFoods)).EndInit();
            //
            // lblId
            //
            this.lblId.Location = new System.Drawing.Point(20, 330);
            this.lblId.Name = "lblId";
            this.lblId.Text = "Food Id";
            this.lblId.AutoSize = true;
            //
            // txtId
            //
            this.txtId.Location = new System.Drawing.Point(140, 327);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(80, 23);
            this.txtId.ReadOnly = true;
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(20, 370);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Food Name";
            this.lblName.AutoSize = true;
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(140, 367);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 23);
            //
            // lblCategory
            //
            this.lblCategory.Location = new System.Drawing.Point(20, 410);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Text = "Category";
            this.lblCategory.AutoSize = true;
            //
            // cmbCategory
            //
            this.cmbCategory.Location = new System.Drawing.Point(140, 407);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(240, 23);
            //
            // lblPrice
            //
            this.lblPrice.Location = new System.Drawing.Point(20, 450);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Text = "Price (Tk)";
            this.lblPrice.AutoSize = true;
            //
            // txtPrice
            //
            this.txtPrice.Location = new System.Drawing.Point(140, 447);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(110, 23);
            //
            // lblStock
            //
            this.lblStock.Location = new System.Drawing.Point(20, 490);
            this.lblStock.Name = "lblStock";
            this.lblStock.Text = "Stock";
            this.lblStock.AutoSize = true;
            //
            // txtStock
            //
            this.txtStock.Location = new System.Drawing.Point(140, 487);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(110, 23);
            //
            // lblStatus
            //
            this.lblStatus.Location = new System.Drawing.Point(20, 530);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Status";
            this.lblStatus.AutoSize = true;
            //
            // cmbStatus
            //
            this.cmbStatus.Location = new System.Drawing.Point(140, 527);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(240, 23);
            this.cmbStatus.Items.AddRange(new object[] { "Available", "Unavailable" });
            //
            // lblDescription
            //
            this.lblDescription.Location = new System.Drawing.Point(410, 330);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Text = "Description";
            this.lblDescription.AutoSize = true;
            //
            // txtDescription
            //
            this.txtDescription.Location = new System.Drawing.Point(410, 360);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(280, 90);
            this.txtDescription.Multiline = true;
            //
            // lblAddStock
            //
            this.lblAddStock.Location = new System.Drawing.Point(410, 470);
            this.lblAddStock.Name = "lblAddStock";
            this.lblAddStock.Text = "Add stock quantity";
            this.lblAddStock.AutoSize = true;
            //
            // txtAddStock
            //
            this.txtAddStock.Location = new System.Drawing.Point(410, 500);
            this.txtAddStock.Name = "txtAddStock";
            this.txtAddStock.Size = new System.Drawing.Size(110, 23);
            //
            // btnAddStock
            //
            this.btnAddStock.Location = new System.Drawing.Point(530, 498);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(160, 28);
            this.btnAddStock.Text = "Add to stock";
            this.btnAddStock.Click += new System.EventHandler(this.btnAddStock_Click);
            //
            // btnAdd
            //
            this.btnAdd.Location = new System.Drawing.Point(720, 360);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 34);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnUpdate
            //
            this.btnUpdate.Location = new System.Drawing.Point(840, 360);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 34);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(720, 405);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 34);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnRestore
            //
            this.btnRestore.Location = new System.Drawing.Point(840, 405);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(110, 34);
            this.btnRestore.Text = "Restore";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(720, 450);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(230, 34);
            this.btnClear.Text = "Clear form";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // lblLowStock
            //
            this.lblLowStock.Location = new System.Drawing.Point(720, 500);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(230, 60);
            this.lblLowStock.Text = "";
            this.lblLowStock.AutoSize = true;
            //
            // lblInfo
            //
            this.lblInfo.Location = new System.Drawing.Point(20, 570);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(930, 24);
            this.lblInfo.Text = "";
            this.lblInfo.AutoSize = true;
            //
            // FoodAdminForm
            //
            this.ClientSize = new System.Drawing.Size(980, 640);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gridFoods);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblAddStock);
            this.Controls.Add(this.txtAddStock);
            this.Controls.Add(this.btnAddStock);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblLowStock);
            this.Controls.Add(this.lblInfo);
            this.Name = "FoodAdminForm";
            this.Load += new System.EventHandler(this.FoodAdminForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView gridFoods;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblAddStock;
        private System.Windows.Forms.TextBox txtAddStock;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblLowStock;
        private System.Windows.Forms.Label lblInfo;
    }
}
