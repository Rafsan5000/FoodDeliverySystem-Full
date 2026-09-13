namespace FoodDeliverySystem.View
{
    partial class Cart
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gridCart = new System.Windows.Forms.DataGridView();
            this.lblCartId = new System.Windows.Forms.Label();
            this.txtCartId = new System.Windows.Forms.TextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.btnUpdateQty = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.Text = "My Cart";
            this.lblTitle.AutoSize = true;
            //
            // btnBrowse
            //
            this.btnBrowse.Location = new System.Drawing.Point(500, 18);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(110, 28);
            this.btnBrowse.Text = "Browse Food";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            //
            // btnRefresh
            //
            this.btnRefresh.Location = new System.Drawing.Point(620, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 28);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(730, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // gridCart
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridCart)).BeginInit();
            this.gridCart.Location = new System.Drawing.Point(20, 60);
            this.gridCart.Name = "gridCart";
            this.gridCart.Size = new System.Drawing.Size(810, 250);
            this.gridCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCart_CellClick);
            ((System.ComponentModel.ISupportInitialize)(this.gridCart)).EndInit();
            //
            // lblCartId
            //
            this.lblCartId.Location = new System.Drawing.Point(20, 330);
            this.lblCartId.Name = "lblCartId";
            this.lblCartId.Text = "Cart Id";
            this.lblCartId.AutoSize = true;
            //
            // txtCartId
            //
            this.txtCartId.Location = new System.Drawing.Point(110, 327);
            this.txtCartId.Name = "txtCartId";
            this.txtCartId.Size = new System.Drawing.Size(70, 23);
            this.txtCartId.ReadOnly = true;
            //
            // lblItem
            //
            this.lblItem.Location = new System.Drawing.Point(200, 330);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(400, 22);
            this.lblItem.Text = "Selected item:";
            this.lblItem.AutoSize = true;
            //
            // lblQty
            //
            this.lblQty.Location = new System.Drawing.Point(20, 370);
            this.lblQty.Name = "lblQty";
            this.lblQty.Text = "Quantity";
            this.lblQty.AutoSize = true;
            //
            // txtQty
            //
            this.txtQty.Location = new System.Drawing.Point(110, 367);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(70, 23);
            //
            // btnUpdateQty
            //
            this.btnUpdateQty.Location = new System.Drawing.Point(200, 365);
            this.btnUpdateQty.Name = "btnUpdateQty";
            this.btnUpdateQty.Size = new System.Drawing.Size(140, 30);
            this.btnUpdateQty.Text = "Update Quantity";
            this.btnUpdateQty.Click += new System.EventHandler(this.btnUpdateQty_Click);
            //
            // btnRemove
            //
            this.btnRemove.Location = new System.Drawing.Point(350, 365);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(120, 30);
            this.btnRemove.Text = "Remove Item";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(480, 365);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 30);
            this.btnClear.Text = "Clear Cart";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // lblTotal
            //
            this.lblTotal.Location = new System.Drawing.Point(20, 420);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(420, 32);
            this.lblTotal.Text = "Total: 0.00 Tk";
            this.lblTotal.AutoSize = true;
            //
            // btnCheckout
            //
            this.btnCheckout.Location = new System.Drawing.Point(620, 415);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(210, 42);
            this.btnCheckout.Text = "Proceed to Checkout";
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            //
            // lblInfo
            //
            this.lblInfo.Location = new System.Drawing.Point(20, 470);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(810, 24);
            this.lblInfo.Text = "";
            this.lblInfo.AutoSize = true;
            //
            // Cart
            //
            this.ClientSize = new System.Drawing.Size(860, 540);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gridCart);
            this.Controls.Add(this.lblCartId);
            this.Controls.Add(this.txtCartId);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.btnUpdateQty);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.lblInfo);
            this.Name = "Cart";
            this.Load += new System.EventHandler(this.Cart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView gridCart;
        private System.Windows.Forms.Label lblCartId;
        private System.Windows.Forms.TextBox txtCartId;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Button btnUpdateQty;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Label lblInfo;
    }
}
