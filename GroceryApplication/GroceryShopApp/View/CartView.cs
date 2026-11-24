using GroceryShopApp.Model;
using GroceryShopApp.Services;

namespace GroceryShopApp.View
{
    /// <summary>
    /// Performs the view level operations for cart and checkout.
    /// </summary>
    internal class CartView
    {
        private readonly CartServices _cartServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartView"/> class.
        /// </summary>
        /// <param name="cartServices">Services of the cart.</param>
        public CartView(CartServices cartServices)
        {
            this._cartServices = cartServices;
        }

        /// <summary>
        /// Displays the cart products of the current user.
        /// </summary>
        /// <param name="userName">Username of the user.</param>
        internal void DisplayCart(string userName)
        {
            List<Cart> carts = this._cartServices.GetCart(userName);

            Console.WriteLine(@"
==================================
            YOUR CART
==================================");

            if (carts.Count == 0)
            {
                ConsoleHelper.WriteErrorMessage("\nYour cart is empty.\n");
                ConsoleHelper.CleanConsole();
                return;
            }

            for (int i = 0; i < carts.Count; i++)
            {
                Cart cart = carts[i];

                Console.WriteLine($@"
{i + 1}. Product: {cart.Product.Name}
   Price: ₹{cart.Product.Price}
   Quantity: {cart.CartQuantity}
   Subtotal: ₹{cart.Product.Price * cart.CartQuantity}");
            }

            decimal totalAmount = this._cartServices.GetCartTotal(userName);

            Console.WriteLine($@"
==================================
Total Amount: ₹{totalAmount}
==================================");

            Console.Write(@"
[C]heckout
[B]ack to Main Menu

Enter Choice: ");

            ConsoleKey userChoice = Console.ReadKey().Key;
            Console.Clear();

            switch (userChoice)
            {
                case ConsoleKey.C:
                    // this.Checkout(userName);
                    break;
                case ConsoleKey.B:
                    return;
                default:
                    ConsoleHelper.WriteErrorMessage("\nInvalid choice.\n");
                    ConsoleHelper.CleanConsole();
                    break;
            }
        }
    }
}