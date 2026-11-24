using GroceryShopApp.Services;

namespace GroceryShopApp.View
{
    /// <summary>
    /// Authenticates the user by fetching the details and displays appropritate messages.
    /// </summary>
    internal class UserAuth
    {
        private readonly UserServices _userServices;
        private readonly MainMenu _mainMenu;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAuth"/> class.
        /// </summary>
        /// <param name="userServices">Services of the user</param>
        /// <param name="mainMenu">Main menu of the application</param>
        public UserAuth(UserServices userServices, MainMenu mainMenu)
        {
            this._userServices = userServices;
            this._mainMenu = mainMenu;
        }

        /// <summary>
        /// Retrieved the user credentials for signing up and displays appropriate message.
        /// </summary>
        public void Register()
        {
            Console.Write($@"
==================================
             SIGN-UP
==================================
");
            Console.Write("Enter full-name: ");
            string? fullName = Console.ReadLine();

            Console.Write("Enter unique user-name: ");
            string? userName = Console.ReadLine();

            Console.Write("Enter Phone number: ");
            string? phone = Console.ReadLine();

            Console.Write("Enter Password [Alpha-numeric]: ");
            string? password = Console.ReadLine();

            if (!Validator.ValidateSignupFields(fullName, userName, phone, password))
            {
                ConsoleHelper.WriteErrorMessage("\nInvalid data\n");
                ConsoleHelper.CleanConsole();
                return;
            }

            if (this._userServices.CreateUser(fullName!, userName!, phone!, password!))
            {
                ConsoleHelper.WriteSuccessMessage("\nUser account created\n");
            }
            else
            {
                ConsoleHelper.WriteErrorMessage("\nUser account already exists\n");
            }

            ConsoleHelper.CleanConsole();
        }

        /// <summary>
        /// Retrieved the log-in credentials from user and displays appropriate message.
        /// </summary>
        internal void Login()
        {
            Console.Write($@"
==================================
             LOG-IN
==================================
");
            Console.Write("Enter unique user-name: ");
            string? userName = Console.ReadLine();

            Console.Write("Enter Password [Alpha-numeric]: ");
            string? password = Console.ReadLine();

            if (!Validator.ValidateLoginFields(userName, password))
            {
                ConsoleHelper.WriteErrorMessage("\nInvalid data\n");
                ConsoleHelper.CleanConsole();
                return;
            }

            if (this._userServices.UserExists(userName!, password!))
            {
                ConsoleHelper.WriteColored("\nLogged In", ConsoleColor.Green);
                Thread.Sleep(1000);
                this._mainMenu.AssignCurrentUser(userName!);
                Console.Clear();
                this._mainMenu.MenuOptions();
            }
            else
            {
                ConsoleHelper.WriteColored($"User data not valid\nReturning to Main menu.", ConsoleColor.Red);
                Thread.Sleep(1300);
                Console.Clear();
            }
        }
    }
}
