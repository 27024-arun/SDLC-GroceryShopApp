using GroceryShopApp.Model;
using GroceryShopApp.Services;

namespace GroceryShopApp.View
{
    /// <summary>
    /// Performs the view level fetching and display operations for products.
    /// </summary>
    internal class ProductView
    {
        private readonly ProductServices _productServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductView"/> class.
        /// </summary>
        /// <param name="productServices">Services of the product.</param>
        public ProductView(ProductServices productServices)
        {
            this._productServices = productServices;
        }

        /// <summary>
        /// Displays the product menu and fetches the user choice to redirect.
        /// </summary>
        internal void DisplayProductMenu()
        {
            while (true)
            {
                Console.Write(@"
==================================
          PRODUCT MENU
==================================
[V]egetables
[F]ruits
[C]ookware
[B]ack to Main Menu

Enter Choice: ");

                ConsoleKey userChoice = Console.ReadKey().Key;
                Console.Clear();
                switch (userChoice)
                {
                    case ConsoleKey.V:
                        this.DisplayProducts(Categories.Vegetable);
                        break;
                    case ConsoleKey.F:
                        this.DisplayProducts(Categories.Fruit);
                        break;
                    case ConsoleKey.C:
                        this.DisplayProducts(Categories.Cookware);
                        break;
                    case ConsoleKey.B:
                        return;
                    default:
                        break;
                }
            }
        }

        private void DisplayProducts(Categories category)
        {
            List<Product> products = this._productServices.GetProductsByCategory(category);

            while (true)
            {
                Console.WriteLine($@"
==================================
            {category.ToString().ToUpper()}
==================================");

                this.DisplayProductList(products);

                Console.Write(@"
[S]earch Product
[B]ack to Categories

Enter product number to select: ");

                string? choice = Console.ReadLine();

                if (string.Equals(choice, "B", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    return;
                }

                if (string.Equals(choice, "S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("\nEnter product name to search: ");
                    string searchName = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(searchName))
                    {
                        ConsoleHelper.WriteErrorMessage("\nSearch name cannot be empty.\n");
                        continue;
                    }

                    products = this._productServices.SearchProducts(category, searchName.Trim());
                    Console.Clear();

                    if (products.Count == 0)
                    {
                        ConsoleHelper.WriteErrorMessage("\nNo products found.\n");
                    }

                    continue;
                }

                if (!int.TryParse(choice, out int productNumber) || productNumber < 1 || productNumber > products.Count)
                {
                    ConsoleHelper.WriteErrorMessage("\nInvalid product selection.\n");
                    continue;
                }

                Product selectedProduct = products[productNumber - 1];
                this.DisplaySelectedProduct(selectedProduct);
            }
        }

        private void DisplayProductList(List<Product> products)
        {
            if (products.Count == 0)
            {
                ConsoleHelper.WriteErrorMessage("\nNo products found.\n");
                return;
            }

            for (int i = 0; i < products.Count; i++)
            {
                Product product = products[i];
                Console.WriteLine($"\n{i + 1}. Product: {product.Name}");
                Console.WriteLine($"   Price: ₹{product.Price}");
                Console.WriteLine(product.Quantity == 0 ? "   Status: Out of stock" : $"   Remaining Stock: {product.Quantity}");
            }
        }

        private void DisplaySelectedProduct(Product product)
        {
            Console.WriteLine(@$"
==================================
        PRODUCT DETAILS
==================================
Name: {product.Name}
Price: ₹{product.Price}
Category: {product.Category}
Stock: {product.Quantity}
Image: {product.ImageFile}");

            if (product.Quantity == 0)
            {
                ConsoleHelper.WriteErrorMessage("\nOut of stock. Cannot add this product.\n");
                return;
            }
        }
    }
}
