using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// The printable invoice for one order. New in this version - the
    /// original project showed an order summary but never produced an
    /// invoice document.
    ///
    /// FLOW: constructor stores the OrderId
    ///       -> InvoiceForm_Load -> OrderController.GetOrderById (header)
    ///                           -> OrderController.GetInvoice   (line items,
    ///                              a 3-table JOIN with a calculated Subtotal)
    /// </summary>
    public partial class InvoiceForm : Form
    {
        private readonly OrderController controller = new OrderController();
        private readonly int orderId;

        private const decimal DeliveryCharge = 50m;

        /// <summary>
        /// Parameterless constructor so the Visual Studio designer can open
        /// this form. The application always uses the overload that takes an
        /// OrderId.
        /// </summary>
        public InvoiceForm() : this(0) { }

        public InvoiceForm(int orderId)
        {
            this.orderId = orderId;
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Invoice");

            foreach (Control control in this.Controls)
            {
                if (control is Label)  UiTheme.StyleLabel((Label)control);
                if (control is Button) UiTheme.StyleButton((Button)control);
            }

            UiTheme.StyleGrid(gridItems);
            UiTheme.StyleTitle(lblBrand);

            lblBrand.Font        = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblInvoiceTitle.Font = UiTheme.HeadingFont;
            lblGrandTotal.Font   = UiTheme.TitleFont;
            lblGrandTotal.ForeColor = UiTheme.Accent;
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            try
            {
                Order order = controller.GetOrderById(orderId);

                if (order == null)
                {
                    Validator.Show("Order " + orderId + " was not found.");
                    this.Close();
                    return;
                }

                lblOrderNo.Text  = "Order No   : " + order.OrderId;
                lblDate.Text     = "Date       : " + order.OrderDate.ToString("dd MMM yyyy, hh:mm tt");
                lblCustomer.Text = "Customer   : " + order.CustomerName;
                lblPhone.Text    = "Phone      : " + order.CustomerPhone;
                lblAddress.Text  = "Address    : " + order.Address;
                lblStatus.Text   = "Order Status : " + order.OrderStatus;
                lblPayment.Text  = "Payment    : " + order.PaymentMethod +
                                   " (" + order.PaymentStatus + ")";

                gridItems.DataSource = controller.GetInvoice(orderId);

                // TotalAmount was stored at checkout, so it is the food total.
                decimal subtotal = order.TotalAmount;

                lblSubtotal.Text   = "Subtotal : " + subtotal.ToString("0.00") + " Tk";
                lblDelivery.Text   = "Delivery Charge : " + DeliveryCharge.ToString("0.00") + " Tk";
                lblGrandTotal.Text = "TOTAL : " + (subtotal + DeliveryCharge).ToString("0.00") + " Tk";
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        /// <summary>
        /// Simple print: captures the form as an image and sends it to the
        /// printer. Enough for a desktop university project, and it also
        /// gives the customer a "Print to PDF" option for free.
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument document = new PrintDocument();

                document.PrintPage += (s, args) =>
                {
                    Bitmap image = new Bitmap(this.Width, this.Height);
                    this.DrawToBitmap(image, new Rectangle(0, 0, this.Width, this.Height));
                    args.Graphics.DrawImage(image, 20, 20);
                };

                PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.Document = document;
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
    }
}
