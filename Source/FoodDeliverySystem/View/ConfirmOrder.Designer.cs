namespace FoodDeliverySystem.View
{
    partial class ConfirmOrder
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
            this.gridItems = new System.Windows.Forms.DataGridView();
            this.lblDeliveryTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblPayment = new System.Windows.Forms.Label();
            this.cmbPayment = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(340, 30);
            this.lblTitle.Text = "Confirm Your Order";
            this.lblTitle.AutoSize = true;
            //
            // gridItems
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.gridItems.Location = new System.Drawing.Point(20, 60);
            this.gridItems.Name = "gridItems";
            this.gridItems.Size = new System.Drawing.Size(730, 200);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            //
            // lblDeliveryTitle
            //
            this.lblDeliveryTitle.Location = new System.Drawing.Point(20, 280);
            this.lblDeliveryTitle.Name = "lblDeliveryTitle";
            this.lblDeliveryTitle.Size = new System.Drawing.Size(300, 24);
            this.lblDeliveryTitle.Text = "Delivery details";
            this.lblDeliveryTitle.AutoSize = true;
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(20, 318);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Name";
            this.lblName.AutoSize = true;
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(140, 315);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 23);
            this.txtName.ReadOnly = true;
            //
            // lblPhone
            //
            this.lblPhone.Location = new System.Drawing.Point(20, 358);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Text = "Phone";
            this.lblPhone.AutoSize = true;
            //
            // txtPhone
            //
            this.txtPhone.Location = new System.Drawing.Point(140, 355);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 23);
            //
            // lblAddress
            //
            this.lblAddress.Location = new System.Drawing.Point(20, 398);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Text = "Delivery Address";
            this.lblAddress.AutoSize = true;
            //
            // txtAddress
            //
            this.txtAddress.Location = new System.Drawing.Point(140, 395);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(250, 50);
            this.txtAddress.Multiline = true;
            //
            // lblPayment
            //
            this.lblPayment.Location = new System.Drawing.Point(420, 318);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Text = "Payment Method";
            this.lblPayment.AutoSize = true;
            //
            // cmbPayment
            //
            this.cmbPayment.Location = new System.Drawing.Point(550, 315);
            this.cmbPayment.Name = "cmbPayment";
            this.cmbPayment.Size = new System.Drawing.Size(200, 23);
            this.cmbPayment.Items.AddRange(new object[] { "Cash on Delivery", "Card", "Mobile Banking" });
            //
            // lblTotal
            //
            this.lblTotal.Location = new System.Drawing.Point(420, 360);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(330, 32);
            this.lblTotal.Text = "Total: 0.00 Tk";
            this.lblTotal.AutoSize = true;
            //
            // lblNote
            //
            this.lblNote.Location = new System.Drawing.Point(420, 400);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(330, 48);
            this.lblNote.Text = "";
            this.lblNote.AutoSize = true;
            //
            // btnPlaceOrder
            //
            this.btnPlaceOrder.Location = new System.Drawing.Point(420, 465);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(200, 42);
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            //
            // btnBack
            //
            this.btnBack.Location = new System.Drawing.Point(630, 465);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 42);
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            //
            // lblInfo
            //
            this.lblInfo.Location = new System.Drawing.Point(20, 465);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(380, 42);
            this.lblInfo.Text = "";
            this.lblInfo.AutoSize = true;
            //
            // ConfirmOrder
            //
            this.ClientSize = new System.Drawing.Size(780, 560);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gridItems);
            this.Controls.Add(this.lblDeliveryTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblPayment);
            this.Controls.Add(this.cmbPayment);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblInfo);
            this.Name = "ConfirmOrder";
            this.Load += new System.EventHandler(this.ConfirmOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView gridItems;
        private System.Windows.Forms.Label lblDeliveryTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.ComboBox cmbPayment;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblInfo;
    }
}
