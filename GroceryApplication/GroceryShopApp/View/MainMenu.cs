namespace GroceryShopApp.View
{
    /// <summary>
    /// Handles the main menu logics for redirecting the user.
    /// </summary>
    internal class MainMenu
    {
        private readonly ProductView _productView;

        private string _currentUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenu"/> class.
        /// </summary>
        /// <param name="productView">View level operation of the product</param>
        public MainMenu(ProductView productView)
        {
            this._currentUser = string.Empty;
            this._productView = productView;
        }

        /// <summary>
        /// Assigns the current user for session handling.
        /// </summary>
        /// <param name="userName">Unique username of the user</param>
        public void AssignCurrentUser(string userName)
        {
            this._currentUser = userName;
        }

        /// <summary>
        /// Displays the menu options for redirecting.
        /// </summary>
        internal void MenuOptions()
        {
            while (true)
            {
                Console.Write($@"
==================================
            MAIN MENU
==================================
[P]roducts
[C]art Items
[L]og out

Enter Choice: ");

                ConsoleKey userChoice = Console.ReadKey().Key;
                Console.Clear();

                switch (userChoice)
                {
                    case ConsoleKey.P:
                        this._productView.DisplayProductMenu();
                        break;

                    case ConsoleKey.C:
                        break;

                    case ConsoleKey.L:
                        this._currentUser = string.Empty;
                        ConsoleHelper.WriteColored("\nLogging out...", ConsoleColor.Yellow);
                        Thread.Sleep(1000);
                        Console.Clear();
                        return;

                    default:
                        break;
                }
            }
        }
    }
}