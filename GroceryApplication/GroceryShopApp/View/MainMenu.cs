namespace GroceryShopApp.View
{
    internal class MainMenu
    {
        private string _currentUser;

        public MainMenu()
        {
            this._currentUser = string.Empty;
        }

        public void AssignCurrentUser(string userName)
        {
            this._currentUser = userName;
        }

        public void MenuOptions()
        {
            while (true)
            {
                Console.Write($@"
==================================
            MAIN MENU
==================================
[P]roducts available
[C]art Items
[L]og out

Enter Choice: ");
                ConsoleKey userChoice = Console.ReadKey().Key;
                Console.Clear();
                switch (userChoice)
                {
                    case ConsoleKey.P:
                        break;
                    case ConsoleKey.C:
                        break;
                    case ConsoleKey.L:
                        this._currentUser = string.Empty;
                        ConsoleHelper.WriteColored($"\nLogging out...", ConsoleColor.Yellow);
                        Thread.Sleep(1300);
                        Console.Clear();
                        return;
                    default:
                        break;
                }
            }
        }
    }
}