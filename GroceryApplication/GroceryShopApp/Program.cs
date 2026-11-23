using GroceryShopApp.Repository;
using GroceryShopApp.Services;
using GroceryShopApp.View;

namespace GroceryShopApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UserRepository userRepository = new UserRepository("Users.json");
            UserServices userServices = new UserServices(userRepository);

            MainMenu mainMenu = new MainMenu();
            UserAuth userAuth = new UserAuth(userServices, mainMenu);

            while (true)
            {
                Console.Write($@"
==================================
         GROCERY SHOP APP
==================================
[L]ogIn
[S]ignUp
[A]dmin login
[E]xit

Enter Choice: ");
                ConsoleKey userChoice = Console.ReadKey().Key;
                Console.Clear();
                switch (userChoice)
                {
                    case ConsoleKey.S:
                        userAuth.Register();
                        break;
                    case ConsoleKey.L:
                        userAuth.Login();
                        break;
                    case ConsoleKey.A:
                        break;
                    case ConsoleKey.E:
                        ConsoleHelper.WriteColored("\nExiting...", ConsoleColor.Cyan);
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}