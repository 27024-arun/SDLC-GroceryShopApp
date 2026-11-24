using GroceryShopApp.Services;

namespace GroceryShopApp.View
{
    /// <summary>
    /// Enables the admin to enter details to login.
    /// </summary>
    internal class AdminLogin
    {
        private readonly AdminServices _adminServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminLogin"/> class.
        /// </summary>
        /// <param name="adminServices">Services of admin.</param>
        public AdminLogin(AdminServices adminServices)
        {
            this._adminServices = adminServices;
        }

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

            string validatorMessage = Validator.ValidateLoginFields(userName, password);
            if (validatorMessage != "passed")
            {
                ConsoleHelper.WriteErrorMessage($"\n{validatorMessage}\n");
                ConsoleHelper.CleanConsole();
                return;
            }

            if (!this._adminServices.IsAdmin(userName!, password!))
            {
                ConsoleHelper.WriteErrorMessage("\nUser is not an admin\n");
                ConsoleHelper.CleanConsole();
                return;
            }
            else
            {
                ConsoleHelper.WriteSuccessMessage("\nWelcome! Admin\n");
                ConsoleHelper.CleanConsole();
                this.AdminMenu();
            }
        }

        /// <summary>
        /// Menu options for the admin
        /// </summary>
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
