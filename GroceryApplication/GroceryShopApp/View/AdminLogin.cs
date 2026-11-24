using GroceryShopApp.Services;

namespace GroceryShopApp.View
{
    /// <summary>
    /// Enables the admin to enter details to login.
    /// </summary>
    internal class AdminLogin
    {
        /// <summary>
        /// Asks the user for admin credentials to login.
        /// </summary>
        internal void Login()
        {
            Console.Write($@"
==================================
          ADMIN LOG-IN
==================================
");
            Console.Write("Enter admin user-name: ");
            string? userName = Console.ReadLine();

            Console.Write("Enter admin password [Alpha-numeric]: ");
            string? password = Console.ReadLine();

            if (!Validator.ValidateLoginFields(userName, password))
            {
                ConsoleHelper.WriteErrorMessage("\nInvalid data\n");
                ConsoleHelper.CleanConsole();
                return;
            }

            if (userName == "admin" && password == "password123")
            {
                this.AdminMenu();
            }
        }

        internal void AdminMenu()
        {
            Console.Write($@"
==================================
          ADMIN MENU
==================================
");
        }
    }
}
