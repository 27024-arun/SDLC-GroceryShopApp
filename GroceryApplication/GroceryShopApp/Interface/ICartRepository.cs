using GroceryShopApp.Model;

namespace GroceryShopApp.Interface
{
    /// <summary>
    /// Defines the operations for the cart repository.
    /// </summary>
    internal interface ICartRepository
    {
        /// <summary>
        /// Retrieves all cart products of a particular user.
        /// </summary>
        /// <param name="userName">Username of the user.</param>
        /// <returns>List of cart products.</returns>
        List<Cart> GetCart(string userName);

        /// <summary>
        /// Adds a product to the user's cart or updates its quantity.
        /// </summary>
        /// <param name="cart">Cart details.</param>
        void AddToCart(Cart cart);

        /// <summary>
        /// Removes all cart products of a particular user.
        /// </summary>
        /// <param name="userName">Username of the user.</param>
        void RemoveCart(string userName);

        /// <summary>
        /// Removes selected products from the user's cart.
        /// </summary>
        /// <param name="userName">Username of the user.</param>
        /// <param name="productNames">Names of products to be removed.</param>
        void RemoveCartItems(string userName, List<string> productNames);
    }
}