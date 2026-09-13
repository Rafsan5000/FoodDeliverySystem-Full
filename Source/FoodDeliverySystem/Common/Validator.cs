using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FoodDeliverySystem.Common
{
    /// <summary>
    /// All input validation lives here so the same rules apply on every form
    /// and no form repeats the logic. Each method returns true when the input
    /// is valid; when it is not, it shows a message and returns false.
    /// </summary>
    public static class Validator
    {
        /// <summary>Empty field validation.</summary>
        public static bool IsFilled(TextBox box, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(box.Text))
            {
                Show(fieldName + " cannot be empty.");
                box.Focus();
                return false;
            }
            return true;
        }

        public static bool IsFilled(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Show(fieldName + " cannot be empty.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Email validation. The pattern asks for text, an @, more text,
        /// a dot and at least two letters.
        /// </summary>
        public static bool IsEmail(TextBox box)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[A-Za-z]{2,}$";

            if (!Regex.IsMatch(box.Text.Trim(), pattern))
            {
                Show("Please enter a valid email address, for example name@gmail.com");
                box.Focus();
                return false;
            }
            return true;
        }

        /// <summary>Phone number: 11 digits, the Bangladeshi mobile format.</summary>
        public static bool IsPhone(TextBox box)
        {
            if (!Regex.IsMatch(box.Text.Trim(), @"^01[3-9]\d{8}$"))
            {
                Show("Phone number must be 11 digits and start with 01.");
                box.Focus();
                return false;
            }
            return true;
        }

        /// <summary>Number validation: whole number, zero or more.</summary>
        public static bool IsNonNegativeInt(TextBox box, string fieldName, out int result)
        {
            if (!int.TryParse(box.Text.Trim(), out result) || result < 0)
            {
                Show(fieldName + " must be a whole number that is 0 or more.");
                box.Focus();
                result = 0;
                return false;
            }
            return true;
        }

        /// <summary>Number validation for money values.</summary>
        public static bool IsPositiveDecimal(TextBox box, string fieldName, out decimal result)
        {
            if (!decimal.TryParse(box.Text.Trim(), out result) || result < 0)
            {
                Show(fieldName + " must be a number that is 0 or more.");
                box.Focus();
                result = 0;
                return false;
            }
            return true;
        }

        /// <summary>Password rule used by register and change-password.</summary>
        public static bool IsStrongEnough(TextBox box)
        {
            if (box.Text.Length < 6)
            {
                Show("Password must be at least 6 characters long.");
                box.Focus();
                return false;
            }
            return true;
        }

        public static bool IsSelected(ComboBox combo, string fieldName)
        {
            if (combo.SelectedIndex < 0)
            {
                Show("Please select a " + fieldName + ".");
                combo.Focus();
                return false;
            }
            return true;
        }

        public static bool IsRowSelected(DataGridView grid, string what)
        {
            if (grid.CurrentRow == null || grid.CurrentRow.Index < 0)
            {
                Show("Please select a " + what + " from the list first.");
                return false;
            }
            return true;
        }

        public static void Show(string message)
        {
            MessageBox.Show(message, "FOOD X",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Info(string message)
        {
            MessageBox.Show(message, "FOOD X",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// One place that turns an exception into a message box. Every catch
        /// block in the View layer calls this, so error handling looks the
        /// same everywhere.
        /// </summary>
        public static void Error(Exception ex)
        {
            MessageBox.Show("Something went wrong:" + Environment.NewLine + ex.Message,
                "FOOD X - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirm(string message)
        {
            return MessageBox.Show(message, "FOOD X - Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
