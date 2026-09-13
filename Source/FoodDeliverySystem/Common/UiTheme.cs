using System.Drawing;
using System.Windows.Forms;

namespace FoodDeliverySystem.Common
{
    /// <summary>
    /// The colours and fonts taken straight from the original project's
    /// screenshots (the orange "FOOD X" look). Putting them in one class means
    /// every new form matches the old ones without anyone guessing the exact
    /// RGB values, which is the "same colour theme / same button style"
    /// requirement.
    /// </summary>
    public static class UiTheme
    {
        // --- Colours ---------------------------------------------------------
        public static readonly Color Background = Color.FromArgb(232, 161,  92);  // main orange panel
        public static readonly Color Sidebar    = Color.FromArgb(224, 140, 106);  // salmon left panel
        public static readonly Color ButtonFace = Color.FromArgb(244, 164,  96);  // SandyBrown
        public static readonly Color ButtonText = Color.Black;
        public static readonly Color Border     = Color.White;
        public static readonly Color Heading    = Color.FromArgb( 40,  25,  15);
        public static readonly Color Accent     = Color.FromArgb(214,  90,  49);  // deep orange
        public static readonly Color GridHeader = Color.FromArgb(214,  90,  49);
        public static readonly Color GridRow    = Color.FromArgb(253, 235, 216);
        public static readonly Color GridAlt    = Color.FromArgb(247, 220, 195);

        // --- Fonts -----------------------------------------------------------
        public static readonly Font TitleFont   = new Font("Segoe UI", 16F, FontStyle.Bold);
        public static readonly Font HeadingFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static readonly Font LabelFont   = new Font("Segoe UI",  9.75F, FontStyle.Bold);
        public static readonly Font InputFont   = new Font("Segoe UI",  9.75F, FontStyle.Regular);
        public static readonly Font ButtonFont  = new Font("Segoe UI",  9.75F, FontStyle.Bold);

        /// <summary>
        /// Applies the shared look to a whole form in one call. Every form
        /// calls this at the end of its constructor.
        /// </summary>
        public static void ApplyForm(Form form, string title)
        {
            form.BackColor = Background;
            form.Font = InputFont;
            form.Text = "FOOD X - " + title;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
        }

        /// <summary>Orange button with the white flat border from the original UI.</summary>
        public static void StyleButton(Button button)
        {
            button.BackColor = ButtonFace;
            button.ForeColor = ButtonText;
            button.Font = ButtonFont;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Border;
            button.FlatAppearance.BorderSize = 2;
            button.Cursor = Cursors.Hand;
        }

        public static void StyleSidebarButton(Button button)
        {
            StyleButton(button);
            button.TextAlign = ContentAlignment.MiddleCenter;
        }

        public static void StyleLabel(Label label)
        {
            label.Font = LabelFont;
            label.ForeColor = Heading;
            label.BackColor = Color.Transparent;
            label.AutoSize = true;
        }

        public static void StyleTitle(Label label)
        {
            label.Font = TitleFont;
            label.ForeColor = Accent;
            label.BackColor = Color.Transparent;
            label.AutoSize = true;
        }

        public static void StyleTextBox(TextBox box)
        {
            box.BackColor = ButtonFace;
            box.ForeColor = Color.Black;
            box.BorderStyle = BorderStyle.FixedSingle;
            box.Font = InputFont;
        }

        public static void StyleCombo(ComboBox combo)
        {
            combo.BackColor = ButtonFace;
            combo.FlatStyle = FlatStyle.Flat;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.Font = InputFont;
        }

        /// <summary>
        /// Makes every DataGridView in the app look the same: orange header,
        /// alternating cream rows, full-row select, read only.
        /// </summary>
        public static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = GridRow;
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = GridHeader;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = LabelFont;
            grid.ColumnHeadersHeight = 32;
            grid.DefaultCellStyle.BackColor = GridRow;
            grid.DefaultCellStyle.SelectionBackColor = Accent;
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.AlternatingRowsDefaultCellStyle.BackColor = GridAlt;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToResizeRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static void StylePanel(Panel panel, bool isSidebar)
        {
            panel.BackColor = isSidebar ? Sidebar : Background;
        }
    }
}
