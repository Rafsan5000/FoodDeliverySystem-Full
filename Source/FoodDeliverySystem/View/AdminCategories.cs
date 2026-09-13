using System;
using System.Data;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// Super Admin category management. Small, self-contained CRUD screen -
    /// the easiest one to demonstrate the Form -> Controller -> Model -> SQL
    /// flow with during the viva.
    /// </summary>
    public partial class AdminCategories : Form
    {
        private readonly CategoryController controller = new CategoryController();

        public AdminCategories()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Food Categories");

            foreach (Control control in this.Controls)
            {
                if (control is Label)    UiTheme.StyleLabel((Label)control);
                if (control is TextBox)  UiTheme.StyleTextBox((TextBox)control);
                if (control is Button)   UiTheme.StyleButton((Button)control);
                if (control is ComboBox) UiTheme.StyleCombo((ComboBox)control);
            }

            UiTheme.StyleTitle(lblTitle);
            UiTheme.StyleGrid(gridCategories);
        }

        private void AdminCategories_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;
            LoadGrid();
        }

        /// <summary>Uses the GROUP BY query so each row shows its food count.</summary>
        private void LoadGrid()
        {
            try
            {
                gridCategories.DataSource = controller.GetCategoriesWithCount();
                lblHint.Text = "TotalFoods comes from a LEFT JOIN with GROUP BY, " +
                               "so a new category still shows with 0.";
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void gridCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = gridCategories.Rows[e.RowIndex];

            txtId.Text   = row.Cells["CategoryId"].Value.ToString();
            txtName.Text = row.Cells["CategoryName"].Value.ToString();
            cmbStatus.SelectedItem = row.Cells["Status"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validator.IsFilled(txtName, "Category name")) return;

                string message;

                if (!controller.AddCategory(txtName.Text, out message))
                {
                    Validator.Show(message);
                    return;
                }

                Validator.Info(message);
                ClearForm();
                LoadGrid();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryId;

                if (!int.TryParse(txtId.Text, out categoryId))
                {
                    Validator.Show("Select a category from the list first.");
                    return;
                }

                if (!Validator.IsFilled(txtName, "Category name")) return;
                if (!Validator.IsSelected(cmbStatus, "status")) return;

                Category category = new Category
                {
                    CategoryId   = categoryId,
                    CategoryName = txtName.Text.Trim(),
                    Status       = cmbStatus.SelectedItem.ToString()
                };

                string message;

                if (!controller.UpdateCategory(category, out message))
                {
                    Validator.Show(message);
                    return;
                }

                Validator.Info(message);
                ClearForm();
                LoadGrid();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryId;

                if (!int.TryParse(txtId.Text, out categoryId))
                {
                    Validator.Show("Select a category from the list first.");
                    return;
                }

                if (!Validator.Confirm("Delete category '" + txtName.Text + "'?")) return;

                string message;
                controller.DeleteCategory(categoryId, out message);

                Validator.Info(message);
                ClearForm();
                LoadGrid();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) { ClearForm(); }

        private void ClearForm()
        {
            txtId.Clear();
            txtName.Clear();
            cmbStatus.SelectedIndex = 0;
            txtName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
    }
}
