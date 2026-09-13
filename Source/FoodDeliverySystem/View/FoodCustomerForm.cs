using System;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// The customer's browse screen: search, filter and add to cart.
    /// Keeps the original FoodCustomerForm name.
    ///
    /// FLOW (search): btnSearch_Click -> FoodController.SearchFood
    ///       -> Foods.SearchFood
    ///       -> SELECT ... JOIN Restaurants JOIN Categories
    ///          WHERE FoodName LIKE '%' + @Keyword + '%'   (parameterised)
    ///
    /// FLOW (filter): btnFilter_Click -> FoodController.FilterFood
    ///       -> Foods.FilterFood -> one SELECT combining category, price
    ///          range, stock and keyword.
    /// </summary>
    public partial class FoodCustomerForm : Form
    {
        private readonly FoodController controller = new FoodController();
        private readonly CategoryController categoryController = new CategoryController();
        private readonly CartController cartController = new CartController();

        private int selectedFoodId;

        public FoodCustomerForm()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Browse Food");

            foreach (Control control in this.Controls)
            {
                if (control is Label)    UiTheme.StyleLabel((Label)control);
                if (control is TextBox)  UiTheme.StyleTextBox((TextBox)control);
                if (control is Button)   UiTheme.StyleButton((Button)control);
                if (control is ComboBox) UiTheme.StyleCombo((ComboBox)control);
            }

            UiTheme.StyleTitle(lblTitle);
            UiTheme.StyleGrid(gridFoods);

            chkInStock.BackColor = System.Drawing.Color.Transparent;
            chkInStock.Font = UiTheme.InputFont;
            lblSelected.Font = UiTheme.HeadingFont;
        }

        private void FoodCustomerForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            chkInStock.Checked = true;
            ShowAll();
            RefreshCartLabel();
        }

        /// <summary>
        /// The combo starts with "All categories" whose CategoryId is 0.
        /// The SQL reads "@CategoryId = 0 OR f.CategoryId = @CategoryId",
        /// so selecting it simply switches the filter off.
        /// </summary>
        private void LoadCategories()
        {
            try
            {
                cmbCategory.DataSource    = categoryController.GetCategoriesForFilter();
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember   = "CategoryId";
                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void ShowAll()
        {
            try
            {
                gridFoods.DataSource = controller.GetAvailableFoods();
                lblResult.Text = gridFoods.Rows.Count + " item(s) available.";
                ClearSelection();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gridFoods.DataSource = controller.SearchFood(txtSearch.Text.Trim());

                lblResult.Text = gridFoods.Rows.Count +
                    " item(s) matched \"" + txtSearch.Text.Trim() + "\".";

                ClearSelection();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e) { ApplyFilter(); }

        private void Filter_Changed(object sender, EventArgs e)
        {
            // Only react once the form has finished loading.
            if (this.IsHandleCreated && cmbCategory.SelectedValue != null) ApplyFilter();
        }

        private void chkInStock_CheckedChanged(object sender, EventArgs e)
        {
            if (this.IsHandleCreated && cmbCategory.SelectedValue != null) ApplyFilter();
        }

        private void ApplyFilter()
        {
            try
            {
                decimal minPrice, maxPrice;

                if (!decimal.TryParse(txtMin.Text.Trim(), out minPrice)) minPrice = 0;
                if (!decimal.TryParse(txtMax.Text.Trim(), out maxPrice)) maxPrice = 100000;

                int categoryId = cmbCategory.SelectedValue == null
                    ? 0 : Convert.ToInt32(cmbCategory.SelectedValue);

                gridFoods.DataSource = controller.FilterFood(
                    categoryId, minPrice, maxPrice,
                    chkInStock.Checked, txtSearch.Text.Trim());

                lblResult.Text = gridFoods.Rows.Count + " item(s) match your filter.";
                ClearSelection();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtMin.Text = "0";
            txtMax.Text = "5000";
            cmbCategory.SelectedIndex = 0;
            ShowAll();
        }

        private void gridFoods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = gridFoods.Rows[e.RowIndex];

                selectedFoodId = Convert.ToInt32(row.Cells["FoodId"].Value);

                Food food = controller.GetFoodById(selectedFoodId);

                if (food == null) return;

                lblSelected.Text = "Selected: " + food.FoodName +
                                   "  (" + food.Price.ToString("0.00") + " Tk)";

                lblDetails.Text = "Restaurant : " + food.RestaurantName + Environment.NewLine +
                                  "Category   : " + food.CategoryName   + Environment.NewLine +
                                  "In stock   : " + food.Stock          + Environment.NewLine +
                                  food.Description;

                lblInfo.Text = food.IsOrderable
                    ? ""
                    : "This item is out of stock right now.";
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        /// <summary>
        /// FLOW: btnAddToCart_Click -> CartController.AddToCart
        ///       -> Foods.GetFoodById (checks stock and status)
        ///       -> Carts.AddOrUpdate (IF EXISTS ... UPDATE ELSE INSERT)
        /// </summary>
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedFoodId == 0)
                {
                    Validator.Show("Click a food item in the list first.");
                    return;
                }

                int quantity;
                if (!Validator.IsNonNegativeInt(txtQty, "Quantity", out quantity)) return;

                string message;

                if (!cartController.AddToCart(selectedFoodId, quantity, out message))
                {
                    Validator.Show(message);
                    return;
                }

                lblInfo.Text = message;
                RefreshCartLabel();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void RefreshCartLabel()
        {
            try
            {
                lblCartInfo.Text = "Cart: " + cartController.GetMyCartCount() + " item(s)";
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void ClearSelection()
        {
            selectedFoodId   = 0;
            lblSelected.Text = "Selected: none";
            lblDetails.Text  = "";
            txtQty.Text      = "1";
        }

        private void btnGoCart_Click(object sender, EventArgs e)
        {
            new Cart().ShowDialog();
            RefreshCartLabel();
        }

        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
    }
}
