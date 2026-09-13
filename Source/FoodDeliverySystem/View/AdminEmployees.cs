using System;
using System.Windows.Forms;
using FoodDeliverySystem.Common;
using FoodDeliverySystem.Controller;
using FoodDeliverySystem.Model;

namespace FoodDeliverySystem.View
{
    /// <summary>
    /// Restaurant Admin employee management. Keeps the original
    /// AdminEmployees name.
    ///
    /// Hiring writes to two tables (Users and Employees), which is why the
    /// Model does it inside a transaction - see Employees.AddEmployeeWithUser.
    /// </summary>
    public partial class AdminEmployees : Form
    {
        private readonly EmployeeController controller = new EmployeeController();

        public AdminEmployees()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            UiTheme.ApplyForm(this, "Employees");

            foreach (Control control in this.Controls)
            {
                if (control is Label)    UiTheme.StyleLabel((Label)control);
                if (control is TextBox)  UiTheme.StyleTextBox((TextBox)control);
                if (control is Button)   UiTheme.StyleButton((Button)control);
                if (control is ComboBox) UiTheme.StyleCombo((ComboBox)control);
            }

            UiTheme.StyleTitle(lblTitle);
            UiTheme.StyleGrid(gridEmployees);
            lblSectionAdd.ForeColor = UiTheme.Accent;
        }

        private void AdminEmployees_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Employees - " + Session.CurrentRestaurantName;

            cmbPosition.SelectedIndex = 0;
            cmbStatus.SelectedIndex   = 0;
            dtpJoining.Value          = DateTime.Today;

            LoadGrid();
        }

        private void LoadGrid()
        {
            try
            {
                gridEmployees.DataSource = controller.GetMyEmployees();
                lblInfo.Text = controller.CountMyEmployees() + " active employee(s).";
            }
            catch (Exception ex)
            {
                Validator.Error(ex);
            }
        }

        private void gridEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = gridEmployees.Rows[e.RowIndex];

            txtId.Text    = row.Cells["EmployeeId"].Value.ToString();
            txtName.Text  = row.Cells["Name"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtPhone.Text = row.Cells["Phone"].Value == DBNull.Value
                            ? "" : row.Cells["Phone"].Value.ToString();

            cmbPosition.SelectedItem = row.Cells["Position"].Value.ToString();
            cmbStatus.SelectedItem   = row.Cells["Status"].Value.ToString();
            dtpJoining.Value         = Convert.ToDateTime(row.Cells["JoiningDate"].Value);

            // Existing accounts keep their password; the box is for new hires.
            txtPassword.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validator.IsFilled(txtName, "Full name")) return;
                if (!Validator.IsFilled(txtEmail, "Email")) return;
                if (!Validator.IsEmail(txtEmail)) return;
                if (!Validator.IsFilled(txtPassword, "Password")) return;
                if (!Validator.IsStrongEnough(txtPassword)) return;
                if (!Validator.IsFilled(txtPhone, "Phone")) return;
                if (!Validator.IsPhone(txtPhone)) return;
                if (!Validator.IsSelected(cmbPosition, "position")) return;

                string message;

                bool ok = controller.AddEmployee(
                    txtName.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPassword.Text,
                    txtPhone.Text.Trim(),
                    txtAddress.Text.Trim(),
                    cmbPosition.SelectedItem.ToString(),
                    dtpJoining.Value,
                    out message);

                if (!ok)
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
                int employeeId;
                if (!TryGetId(out employeeId)) return;

                if (!Validator.IsSelected(cmbPosition, "position")) return;
                if (!Validator.IsSelected(cmbStatus, "status")) return;

                Employee employee = new Employee
                {
                    EmployeeId = employeeId,
                    Position   = cmbPosition.SelectedItem.ToString(),
                    Status     = cmbStatus.SelectedItem.ToString()
                };

                string message;

                if (!controller.UpdateEmployee(employee, out message))
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
                int employeeId;
                if (!TryGetId(out employeeId)) return;

                if (!Validator.Confirm(
                        "Deactivate '" + txtName.Text + "'?" + Environment.NewLine +
                        "Their employment record is kept, but they can no longer log in."))
                    return;

                string message;

                if (!controller.DeleteEmployee(employeeId, out message))
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

        private bool TryGetId(out int employeeId)
        {
            if (!int.TryParse(txtId.Text, out employeeId))
            {
                Validator.Show("Select an employee from the list first.");
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
            txtEmail.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            cmbPosition.SelectedIndex = 0;
            cmbStatus.SelectedIndex   = 0;
            dtpJoining.Value          = DateTime.Today;
            txtName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
    }
}
