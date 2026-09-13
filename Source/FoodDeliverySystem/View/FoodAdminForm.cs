using System;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// Restaurant Admin food CRUD and stock management. Keeps the original
    /// FoodAdminForm name and grid-on-top / fields-below layout.
    ///
    /// FLOW (add):  btnAdd_Click -> Validator -> FoodController.AddFood
    ///              -> Foods.FoodNameExists (SELECT COUNT(*))
    ///              -> Foods.AddFood (INSERT ... SCOPE_IDENTITY())
    ///              -> LoadGrid() re-runs the SELECT and refreshes the grid.
    /// </summary>
    public partial class FoodAdminForm : Form
    {
        private readonly FoodController controller = new FoodController();
        private readonly CategoryController categoryController = new CategoryController();

        public FoodAdminForm()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Food Management");

            foreach (Control control in this.Controls)
            {
                if (control is Label)    UiTheme.StyleLabel((Label)control);
                if (control is TextBox)  UiTheme.StyleTextBox((TextBox)control);
                if (control is Button)   UiTheme.StyleButton((Button)control);
                if (control is ComboBox) UiTheme.StyleCombo((ComboBox)control);
            }

            UiTheme.StyleTitle(lblTitle);
            UiTheme.StyleGrid(gridFoods);
        }

        private void FoodAdminForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Food Management - " + Session.CurrentRestaurantName;

            LoadCategories();
            LoadGrid();
        }

        private void LoadCategories()
        {
            try
            {
                cmbCategory.DataSource    = categoryController.GetActiveCategories();
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember   = "CategoryId";
                cmbCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void LoadGrid()
        {
            try
            {
                gridFoods.DataSource = controller.GetMyMenu();

                int lowStock = controller.GetLowStock(10).Rows.Count;

                lblLowStock.Text = lowStock == 0
                    ? "Stock levels are healthy."
                    : lowStock + " item(s) have 10 or fewer left.";

                lblInfo.Text = controller.CountMyFoods() + " item(s) on your menu.";
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void gridFoods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = gridFoods.Rows[e.RowIndex];

            txtId.Text          = row.Cells["FoodId"].Value.ToString();
            txtName.Text        = row.Cells["FoodName"].Value.ToString();
            txtPrice.Text       = row.Cells["Price"].Value.ToString();
            txtStock.Text       = row.Cells["Stock"].Value.ToString();
            txtDescription.Text = row.Cells["Description"].Value == DBNull.Value
                                  ? "" : row.Cells["Description"].Value.ToString();

            cmbCategory.SelectedValue = Convert.ToInt32(row.Cells["CategoryId"].Value);
            cmbStatus.SelectedItem    = row.Cells["Status"].Value.ToString();
        }

        /// <summary>
        /// Reads and validates every field, returning a filled Food entity.
        /// Both Add and Update use it, so the two paths can never validate
        /// differently.
        /// </summary>
        private bool TryBuildFood(out Food food)
        {
            food = null;

            if (!Validator.IsFilled(txtName, "Food name")) return false;

            if (cmbCategory.SelectedValue == null)
            {
                Validator.Show("Please choose a category.");
                return false;
            }

            decimal price;
            if (!Validator.IsPositiveDecimal(txtPrice, "Price", out price)) return false;

            int stock;
            if (!Validator.IsNonNegativeInt(txtStock, "Stock", out stock)) return false;

            if (!Validator.IsSelected(cmbStatus, "status")) return false;

            food = new Food
            {
                FoodName    = txtName.Text.Trim(),
                CategoryId  = Convert.ToInt32(cmbCategory.SelectedValue),
                Price       = price,
                Stock       = stock,
                Description = txtDescription.Text.Trim(),
                Status      = cmbStatus.SelectedItem.ToString()
            };

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Food food;
                if (!TryBuildFood(out food)) return;

                string message;

                if (!controller.AddFood(food, out message))
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
                int foodId;
                if (!TryGetId(out foodId)) return;

                Food food;
                if (!TryBuildFood(out food)) return;

                food.FoodId = foodId;

                string message;

                if (!controller.UpdateFood(food, out message))
                {
                    Validator.Show(message);
                    return;
                }

                Validator.Info(message);
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
                int foodId;
                if (!TryGetId(out foodId)) return;

                if (!Validator.Confirm("Remove '" + txtName.Text + "' from the menu?"))
                    return;

                string message;
                controller.DeleteFood(foodId, out message);

                Validator.Info(message);
                ClearForm();
                LoadGrid();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                int foodId;
                if (!TryGetId(out foodId)) return;

                string message;
                controller.RestoreFood(foodId, out message);

                Validator.Info(message);
                LoadGrid();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        /// <summary>Stock management: top up an existing item.</summary>
        private void btnAddStock_Click(object sender, EventArgs e)
        {
            try
            {
                int foodId;
                if (!TryGetId(out foodId)) return;

                int quantity;
                if (!Validator.IsNonNegativeInt(txtAddStock, "Stock quantity", out quantity))
                    return;

                string message;

                if (!controller.AddStock(foodId, quantity, out message))
                {
                    Validator.Show(message);
                    return;
                }

                Validator.Info(message);
                txtAddStock.Clear();
                LoadGrid();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private bool TryGetId(out int foodId)
        {
            if (!int.TryParse(txtId.Text, out foodId))
            {
                Validator.Show("Select a food item from the list first.");
                return false;
            }
            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)   { ClearForm(); }
        private void btnRefresh_Click(object sender, EventArgs e) { LoadGrid();  }

        private void ClearForm()
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            txtDescription.Clear();
            txtAddStock.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbStatus.SelectedIndex   = -1;
            txtName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
    }
}
