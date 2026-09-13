namespace FoodDeliverySystem.View
{
    partial class AdminReports
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
            this.btnSales = new System.Windows.Forms.Button();
            this.btnBest = new System.Windows.Forms.Button();
            this.btnDaily = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMinUnits = new System.Windows.Forms.Label();
            this.txtMinUnits = new System.Windows.Forms.TextBox();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.gridReport = new System.Windows.Forms.DataGridView();
            this.lblSummary = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(340, 30);
            this.lblTitle.Text = "Reports";
            this.lblTitle.AutoSize = true;
            //
            // btnSales
            //
            this.btnSales.Location = new System.Drawing.Point(20, 60);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(150, 32);
            this.btnSales.Text = "Sales / Restaurant";
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            //
            // btnBest
            //
            this.btnBest.Location = new System.Drawing.Point(180, 60);
            this.btnBest.Name = "btnBest";
            this.btnBest.Size = new System.Drawing.Size(150, 32);
            this.btnBest.Text = "Best Sellers";
            this.btnBest.Click += new System.EventHandler(this.btnBest_Click);
            //
            // btnDaily
            //
            this.btnDaily.Location = new System.Drawing.Point(340, 60);
            this.btnDaily.Name = "btnDaily";
            this.btnDaily.Size = new System.Drawing.Size(150, 32);
            this.btnDaily.Text = "Daily Sales";
            this.btnDaily.Click += new System.EventHandler(this.btnDaily_Click);
            //
            // btnPayments
            //
            this.btnPayments.Location = new System.Drawing.Point(500, 60);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(150, 32);
            this.btnPayments.Text = "Payments";
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(800, 60);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 32);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // lblMinUnits
            //
            this.lblMinUnits.Location = new System.Drawing.Point(20, 110);
            this.lblMinUnits.Name = "lblMinUnits";
            this.lblMinUnits.Text = "Minimum units sold (for Best Sellers)";
            this.lblMinUnits.AutoSize = true;
            //
            // txtMinUnits
            //
            this.txtMinUnits.Location = new System.Drawing.Point(260, 107);
            this.txtMinUnits.Name = "txtMinUnits";
            this.txtMinUnits.Size = new System.Drawing.Size(70, 23);
            this.txtMinUnits.Text = "1";
            //
            // lblReportTitle
            //
            this.lblReportTitle.Location = new System.Drawing.Point(20, 145);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(600, 24);
            this.lblReportTitle.Text = "Sales per restaurant";
            this.lblReportTitle.AutoSize = true;
            //
            // gridReport
            //
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).BeginInit();
            this.gridReport.Location = new System.Drawing.Point(20, 175);
            this.gridReport.Name = "gridReport";
            this.gridReport.Size = new System.Drawing.Size(890, 330);
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).EndInit();
            //
            // lblSummary
            //
            this.lblSummary.Location = new System.Drawing.Point(20, 520);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(890, 24);
            this.lblSummary.Text = "";
            this.lblSummary.AutoSize = true;
            //
            // AdminReports
            //
            this.ClientSize = new System.Drawing.Size(940, 590);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnBest);
            this.Controls.Add(this.btnDaily);
            this.Controls.Add(this.btnPayments);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMinUnits);
            this.Controls.Add(this.txtMinUnits);
            this.Controls.Add(this.lblReportTitle);
            this.Controls.Add(this.gridReport);
            this.Controls.Add(this.lblSummary);
            this.Name = "AdminReports";
            this.Load += new System.EventHandler(this.AdminReports_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnBest;
        private System.Windows.Forms.Button btnDaily;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMinUnits;
        private System.Windows.Forms.TextBox txtMinUnits;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.DataGridView gridReport;
        private System.Windows.Forms.Label lblSummary;
    }
}
