namespace FoodDeliverySystem.View
{
    partial class FoodCustomerForm
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
            this.lblCartInfo = new System.Windows.Forms.Label();
            this.btnGoCart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.chkInStock = new System.Windows.Forms.CheckBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.gridFoods = new System.Windows.Forms.DataGridView();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.Text = "Browse Food";
            this.lblTitle.AutoSize = true;
            //
            // lblCartInfo
            //
            this.lblCartInfo.Location = new System.Drawing.Point(600, 22);
            this.lblCartInfo.Name = "lblCartInfo";
            this.lblCartInfo.Size = new System.Drawing.Size(230, 24);
            this.lblCartInfo.Text = "Cart: 0 items";
            this.lblCartInfo.AutoSize = true;
            //
            // btnGoCart
            //
            this.btnGoCart.Location = new System.Drawing.Point(730, 18);
            this.btnGoCart.Name = "btnGoCart";
            this.btnGoCart.Size = new System.Drawing.Size(105, 28);
            this.btnGoCart.Text = "My Cart";
            this.btnGoCart.Click += new System.EventHandler(this.btnGoCart_Click);
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(845, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 28);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // lblSearch
            //
            this.lblSearch.Location = new System.Drawing.Point(20, 62);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "Search";
            this.lblSearch.AutoSize = true;
            //
            // txtSearch
            //
            this.txtSearch.Location = new System.Drawing.Point(80, 59);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 23);
            //
            // btnSearch
            //
            this.btnSearch.Location = new System.Drawing.Point(290, 57);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 28);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // lblCategory
            //
            this.lblCategory.Location = new System.Drawing.Point(395, 62);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Text = "Category";
            this.lblCategory.AutoSize = true;
            //
            // cmbCategory
            //
            this.cmbCategory.Location = new System.Drawing.Point(465, 59);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(170, 23);
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            //
            // lblMin
            //
            this.lblMin.Location = new System.Drawing.Point(650, 62);
            this.lblMin.Name = "lblMin";
            this.lblMin.Text = "Price";
            this.lblMin.AutoSize = true;
            //
            // txtMin
            //
            this.txtMin.Location = new System.Drawing.Point(695, 59);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(60, 23);
            this.txtMin.Text = "0";
            //
            // lblTo
            //
            this.lblTo.Location = new System.Drawing.Point(760, 62);
            this.lblTo.Name = "lblTo";
            this.lblTo.Text = "to";
            this.lblTo.AutoSize = true;
            //
            // txtMax
            //
            this.txtMax.Location = new System.Drawing.Point(785, 59);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(60, 23);
            this.txtMax.Text = "5000";
            //
            // chkInStock
            //
            this.chkInStock.Location = new System.Drawing.Point(855, 60);
            this.chkInStock.Name = "chkInStock";
            this.chkInStock.Size = new System.Drawing.Size(100, 22);
            this.chkInStock.Text = "In stock only";
            this.chkInStock.CheckedChanged += new System.EventHandler(this.chkInStock_CheckedChanged);
            //
            // btnFilter
            //
            this.btnFilter.Location = new System.Drawing.Point(20, 95);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(110, 28);
            this.btnFilter.Text = "Apply Filter";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            //
            // btnReset
            //
            this.btnReset.Location = new System.Drawing.Point(140, 95);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 28);
            this.btnReset.Text = "Show All";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            //
            // lblResult
            //
            this.lblResult.Location = new System.Drawing.Point(270, 100);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(400, 22);
            this.lblResult.Text = "";
            this.lblResult.AutoSize = true;
            //
            // gridFoods
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridFoods)).BeginInit();
            this.gridFoods.Location = new System.Drawing.Point(20, 135);
            this.gridFoods.Name = "gridFoods";
            this.gridFoods.Size = new System.Drawing.Size(935, 290);
            this.gridFoods.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFoods_CellClick);
            ((System.ComponentModel.ISupportInitialize)(this.gridFoods)).EndInit();
            //
            // lblSelected
            //
            this.lblSelected.Location = new System.Drawing.Point(20, 445);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(500, 26);
            this.lblSelected.Text = "Selected: none";
            this.lblSelected.AutoSize = true;
            //
            // lblDetails
            //
            this.lblDetails.Location = new System.Drawing.Point(20, 478);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(500, 60);
            this.lblDetails.Text = "";
            this.lblDetails.AutoSize = true;
            //
            // lblQty
            //
            this.lblQty.Location = new System.Drawing.Point(560, 448);
            this.lblQty.Name = "lblQty";
            this.lblQty.Text = "Quantity";
            this.lblQty.AutoSize = true;
            //
            // txtQty
            //
            this.txtQty.Location = new System.Drawing.Point(640, 445);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(80, 23);
            this.txtQty.Text = "1";
            //
            // btnAddToCart
            //
            this.btnAddToCart.Location = new System.Drawing.Point(740, 443);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(215, 34);
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            //
            // lblInfo
            //
            this.lblInfo.Location = new System.Drawing.Point(560, 490);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(395, 60);
            this.lblInfo.Text = "";
            this.lblInfo.AutoSize = true;
            //
            // FoodCustomerForm
            //
            this.ClientSize = new System.Drawing.Size(980, 620);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCartInfo);
            this.Controls.Add(this.btnGoCart);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.chkInStock);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.gridFoods);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.lblInfo);
            this.Name = "FoodCustomerForm";
            this.Load += new System.EventHandler(this.FoodCustomerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCartInfo;
        private System.Windows.Forms.Button btnGoCart;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.CheckBox chkInStock;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.DataGridView gridFoods;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Label lblInfo;
    }
}
