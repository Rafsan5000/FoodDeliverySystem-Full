namespace FoodDeliverySystem.View
{
    partial class InvoiceForm
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
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblInvoiceTitle = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.gridItems = new System.Windows.Forms.DataGridView();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblThanks = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblBrand
            //
            this.lblBrand.Location = new System.Drawing.Point(250, 15);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(220, 40);
            this.lblBrand.Text = "F O O D   X";
            this.lblBrand.AutoSize = true;
            //
            // lblInvoiceTitle
            //
            this.lblInvoiceTitle.Location = new System.Drawing.Point(285, 58);
            this.lblInvoiceTitle.Name = "lblInvoiceTitle";
            this.lblInvoiceTitle.Size = new System.Drawing.Size(150, 24);
            this.lblInvoiceTitle.Text = "INVOICE";
            this.lblInvoiceTitle.AutoSize = true;
            //
            // lblOrderNo
            //
            this.lblOrderNo.Location = new System.Drawing.Point(30, 100);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(300, 22);
            this.lblOrderNo.Text = "Order No:";
            this.lblOrderNo.AutoSize = true;
            //
            // lblDate
            //
            this.lblDate.Location = new System.Drawing.Point(400, 100);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(280, 22);
            this.lblDate.Text = "Date:";
            this.lblDate.AutoSize = true;
            //
            // lblCustomer
            //
            this.lblCustomer.Location = new System.Drawing.Point(30, 128);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(300, 22);
            this.lblCustomer.Text = "Customer:";
            this.lblCustomer.AutoSize = true;
            //
            // lblPhone
            //
            this.lblPhone.Location = new System.Drawing.Point(400, 128);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(280, 22);
            this.lblPhone.Text = "Phone:";
            this.lblPhone.AutoSize = true;
            //
            // lblAddress
            //
            this.lblAddress.Location = new System.Drawing.Point(30, 156);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(650, 22);
            this.lblAddress.Text = "Address:";
            this.lblAddress.AutoSize = true;
            //
            // lblStatus
            //
            this.lblStatus.Location = new System.Drawing.Point(30, 184);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(300, 22);
            this.lblStatus.Text = "Order Status:";
            this.lblStatus.AutoSize = true;
            //
            // lblPayment
            //
            this.lblPayment.Location = new System.Drawing.Point(400, 184);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(280, 22);
            this.lblPayment.Text = "Payment:";
            this.lblPayment.AutoSize = true;
            //
            // gridItems
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.gridItems.Location = new System.Drawing.Point(30, 220);
            this.gridItems.Name = "gridItems";
            this.gridItems.Size = new System.Drawing.Size(650, 250);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            //
            // lblSubtotal
            //
            this.lblSubtotal.Location = new System.Drawing.Point(400, 485);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(280, 22);
            this.lblSubtotal.Text = "Subtotal:";
            this.lblSubtotal.AutoSize = true;
            //
            // lblDelivery
            //
            this.lblDelivery.Location = new System.Drawing.Point(400, 512);
            this.lblDelivery.Name = "lblDelivery";
            this.lblDelivery.Size = new System.Drawing.Size(280, 22);
            this.lblDelivery.Text = "Delivery Charge: 0.00 Tk";
            this.lblDelivery.AutoSize = true;
            //
            // lblGrandTotal
            //
            this.lblGrandTotal.Location = new System.Drawing.Point(400, 542);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(280, 28);
            this.lblGrandTotal.Text = "TOTAL:";
            this.lblGrandTotal.AutoSize = true;
            //
            // lblThanks
            //
            this.lblThanks.Location = new System.Drawing.Point(30, 520);
            this.lblThanks.Name = "lblThanks";
            this.lblThanks.Size = new System.Drawing.Size(330, 22);
            this.lblThanks.Text = "Thank you for ordering with FOOD X.";
            this.lblThanks.AutoSize = true;
            //
            // btnPrint
            //
            this.btnPrint.Location = new System.Drawing.Point(30, 560);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 32);
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(160, 560);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 32);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // InvoiceForm
            //
            this.ClientSize = new System.Drawing.Size(720, 620);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.lblInvoiceTitle);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPayment);
            this.Controls.Add(this.gridItems);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblDelivery);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.lblThanks);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Name = "InvoiceForm";
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblInvoiceTitle;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.DataGridView gridItems;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblDelivery;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label lblThanks;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
    }
}
