using GroceryShopApp.Repository;
using GroceryShopApp.Services;
using GroceryShopApp.View;

namespace GroceryShopApp
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            UserRepository userRepository = new UserRepository("Users.json");
            ProductRepository productRepository = new ProductRepository("Products.json");

            UserServices userServices = new UserServices(userRepository);
            ProductServices productServices = new ProductServices(productRepository);
            AdminServices adminServices = new AdminServices(userRepository, productRepository);

            ProductView productView = new ProductView(productServices);
            MainMenu mainMenu = new MainMenu(productView);
            UserAuth userAuth = new UserAuth(userServices, mainMenu);
            AdminLogin adminLogin = new AdminLogin(adminServices);

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
                        adminLogin.Login();
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