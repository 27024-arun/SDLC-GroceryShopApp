namespace GroceryShopApp.View
{
    internal class AdminLogin
    {
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
        }
    }
}
