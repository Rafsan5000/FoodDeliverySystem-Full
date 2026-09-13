using System;
using System.Data;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// Super Admin user management. Full CRUD on Users plus search and filter.
    /// Replaces the original AdminCustomers form, which could only see one
    /// kind of person.
    ///
    /// FLOW (search): txtSearch + two combo boxes -> UserController.SearchUsers
    ///                -> Users.SearchUsers -> one SELECT with LIKE and the
    ///                   "@Role = 'All' OR Role = @Role" trick -> grid
    /// </summary>
    public partial class AdminUsers : Form
    {
        private readonly UserController controller = new UserController();

        public AdminUsers()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Manage Users");

            foreach (Control control in this.Controls)
            {
                if (control is Label)    UiTheme.StyleLabel((Label)control);
                if (control is TextBox)  UiTheme.StyleTextBox((TextBox)control);
                if (control is Button)   UiTheme.StyleButton((Button)control);
                if (control is ComboBox) UiTheme.StyleCombo((ComboBox)control);
            }

            UiTheme.StyleTitle(lblTitle);
            UiTheme.StyleGrid(gridUsers);
            lblEditTitle.ForeColor = UiTheme.Accent;
        }

        private void AdminUsers_Load(object sender, EventArgs e)
        {
            cmbRole.SelectedIndex   = 0;   // "All"
            cmbStatus.SelectedIndex = 0;   // "All"
            LoadGrid();
        }

        /// <summary>One method feeds the grid; search and filter both call it.</summary>
        private void LoadGrid()
        {
            try
            {
                DataTable table = controller.SearchUsers(
                    txtSearch.Text.Trim(),
                    cmbRole.SelectedItem == null   ? "All" : cmbRole.SelectedItem.ToString(),
                    cmbStatus.SelectedItem == null ? "All" : cmbStatus.SelectedItem.ToString());

                gridUsers.DataSource = table;
                lblCount.Text = table.Rows.Count + " user(s) found.";
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)   { LoadGrid(); }
        private void Filter_Changed(object sender, EventArgs e)    { LoadGrid(); }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbRole.SelectedIndex   = 0;
            cmbStatus.SelectedIndex = 0;
            ClearForm();
            LoadGrid();
        }

        /// <summary>Copies the clicked row into the edit boxes underneath.</summary>
        private void gridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = gridUsers.Rows[e.RowIndex];

            txtId.Text      = row.Cells["UserId"].Value.ToString();
            txtName.Text    = row.Cells["Name"].Value.ToString();
            txtEmail.Text   = row.Cells["Email"].Value.ToString();
            txtPhone.Text   = SafeText(row.Cells["Phone"].Value);
            txtAddress.Text = SafeText(row.Cells["Address"].Value);

            cmbNewRole.SelectedItem = row.Cells["Role"].Value.ToString();
        }

        private string SafeText(object value)
        {
            return value == null || value == DBNull.Value ? "" : value.ToString();
        }

        private bool TryGetSelectedId(out int userId)
        {
            userId = 0;

            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                Validator.Show("Select a user from the list first.");
                return false;
            }

            return int.TryParse(txtId.Text, out userId);
        }

        /* ---------------- UPDATE ---------------- */

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int userId;
                if (!TryGetSelectedId(out userId)) return;

                if (!Validator.IsFilled(txtName, "Name")) return;
                if (!Validator.IsFilled(txtEmail, "Email")) return;
                if (!Validator.IsEmail(txtEmail)) return;

                User user = new User
                {
                    UserId  = userId,
                    Name    = txtName.Text.Trim(),
                    Email   = txtEmail.Text.Trim(),
                    Phone   = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim()
                };

                string message;

                if (!controller.UpdateUser(user, out message))
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

        private void btnChangeRole_Click(object sender, EventArgs e)
        {
            try
            {
                int userId;
                if (!TryGetSelectedId(out userId)) return;
                if (!Validator.IsSelected(cmbNewRole, "role")) return;

                if (userId == Session.UserId)
                {
                    Validator.Show("You cannot change your own role while logged in.");
                    return;
                }

                string message;
                controller.UpdateRole(userId, cmbNewRole.SelectedItem.ToString(), out message);

                Validator.Info(message);
                LoadGrid();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void btnActivate_Click(object sender, EventArgs e) { SetStatus("Active");   }
        private void btnSuspend_Click(object sender, EventArgs e)  { SetStatus("Inactive"); }

        private void SetStatus(string status)
        {
            try
            {
                int userId;
                if (!TryGetSelectedId(out userId)) return;

                if (userId == Session.UserId && status == "Inactive")
                {
                    Validator.Show("You cannot suspend your own account.");
                    return;
                }

                string message;
                controller.UpdateStatus(userId, status, out message);

                Validator.Info(message);
                LoadGrid();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        /* ---------------- DELETE ---------------- */

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int userId;
                if (!TryGetSelectedId(out userId)) return;

                if (userId == Session.UserId)
                {
                    Validator.Show("You cannot delete your own account.");
                    return;
                }

                if (!Validator.Confirm("Delete user '" + txtName.Text + "'?" +
                                       Environment.NewLine +
                                       "If they have order history the account is " +
                                       "deactivated instead, so nothing is lost."))
                    return;

                string message;
                controller.DeleteUser(userId, out message);

                Validator.Info(message);
                ClearForm();
                LoadGrid();
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void ClearForm()
        {
            txtId.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            cmbNewRole.SelectedIndex = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
