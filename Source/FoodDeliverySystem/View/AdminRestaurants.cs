using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// Super Admin screen for creating, editing, approving and suspending
    /// restaurants. Brand new: the original project had no Restaurants table.
    /// </summary>
    public partial class AdminRestaurants : Form
    {
        private readonly RestaurantController controller = new RestaurantController();
        private readonly UserController userController = new UserController();

        public AdminRestaurants()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Manage Restaurants");

            foreach (Control control in this.Controls)
            {
                if (control is Label)    UiTheme.StyleLabel((Label)control);
                if (control is TextBox)  UiTheme.StyleTextBox((TextBox)control);
                if (control is Button)   UiTheme.StyleButton((Button)control);
                if (control is ComboBox) UiTheme.StyleCombo((ComboBox)control);
            }

            UiTheme.StyleTitle(lblTitle);
            UiTheme.StyleGrid(gridRestaurants);
        }

        private void AdminRestaurants_Load(object sender, EventArgs e)
        {
            LoadOwners();
            LoadGrid();

            lblHint.Text =
                "Creating a restaurant also promotes the chosen user to " +
                "RestaurantAdmin. One owner manages one restaurant, so the " +
                "owner list only offers people who do not own one yet. " +
                "Suspending hides the whole menu from customers in one step.";
        }

        /// <summary>
        /// Fills the owner combo. Customers appear too, because promoting a
        /// registered customer into a restaurant owner is the normal way a
        /// new restaurant joins the platform.
        /// </summary>
        private void LoadOwners()
        {
            try
            {
                List<User> owners = new List<User>();
                owners.AddRange(userController.GetUsersByRole("RestaurantAdmin"));
                owners.AddRange(userController.GetUsersByRole("Customer"));

                cmbOwner.DataSource    = owners;
                cmbOwner.DisplayMember = "Name";
                cmbOwner.ValueMember   = "UserId";
                cmbOwner.SelectedIndex = -1;
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
                gridRestaurants.DataSource = controller.GetAllRestaurants();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void gridRestaurants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = gridRestaurants.Rows[e.RowIndex];

            txtId.Text      = row.Cells["RestaurantId"].Value.ToString();
            txtName.Text    = row.Cells["RestaurantName"].Value.ToString();
            txtAddress.Text = Safe(row.Cells["Address"].Value);
            txtPhone.Text   = Safe(row.Cells["Phone"].Value);
        }

        private string Safe(object value)
        {
            return value == null || value == DBNull.Value ? "" : value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbOwner.SelectedValue == null)
                {
                    Validator.Show("Please choose an owner for the restaurant.");
                    return;
                }

                if (!Validator.IsFilled(txtName, "Restaurant name")) return;
                if (!Validator.IsFilled(txtAddress, "Address")) return;
                if (!Validator.IsFilled(txtPhone, "Phone")) return;
                if (!Validator.IsPhone(txtPhone)) return;

                Restaurant restaurant = new Restaurant
                {
                    OwnerId        = Convert.ToInt32(cmbOwner.SelectedValue),
                    RestaurantName = txtName.Text.Trim(),
                    Address        = txtAddress.Text.Trim(),
                    Phone          = txtPhone.Text.Trim()
                };

                string message;

                if (!controller.AddRestaurant(restaurant, out message))
                {
                    Validator.Show(message);
                    return;
                }

                Validator.Info(message);
                ClearForm();
                LoadOwners();
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
                int restaurantId;
                if (!TryGetId(out restaurantId)) return;

                if (!Validator.IsFilled(txtName, "Restaurant name")) return;

                // The Super Admin edits any restaurant, so we set the id here
                // rather than going through UpdateMyRestaurant.
                Restaurants restaurants = new Restaurants();

                restaurants.UpdateRestaurant(new Restaurant
                {
                    RestaurantId   = restaurantId,
                    RestaurantName = txtName.Text.Trim(),
                    Address        = txtAddress.Text.Trim(),
                    Phone          = txtPhone.Text.Trim()
                });

                Validator.Info("Restaurant updated.");
                LoadGrid();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e) { SetStatus("Active");   }
        private void btnSuspend_Click(object sender, EventArgs e) { SetStatus("Inactive"); }

        private void SetStatus(string status)
        {
            try
            {
                int restaurantId;
                if (!TryGetId(out restaurantId)) return;

                string message;
                controller.UpdateStatus(restaurantId, status, out message);

                Validator.Info(message);
                LoadGrid();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private bool TryGetId(out int restaurantId)
        {
            if (!int.TryParse(txtId.Text, out restaurantId))
            {
                Validator.Show("Select a restaurant from the list first.");
                return false;
            }
            return true;
        }

        private void btnClear_Click(object sender, EventArgs e) { ClearForm(); }

        private void ClearForm()
        {
            txtId.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            cmbOwner.SelectedIndex = -1;
        }

        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
    }
}
