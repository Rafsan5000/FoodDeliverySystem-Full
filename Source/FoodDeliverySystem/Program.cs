using System;
using System.Windows.Forms;
using FoodDeliverySystem.View;

namespace FoodDeliverySystem
{
    /// <summary>
    /// PROTECTED FILE - only Member 1 edits this.
    /// Application entry point. Unchanged from the original project except
    /// that the start-up form now lives in the View folder.
    /// </summary>
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogInForm());
        }
    }
}
