using GroceryShopApp.Model;

namespace GroceryShopApp.Interface
{
    /// <summary>
    /// Defines the operations for the wishlist repository.
    /// </summary>
    internal interface IWishlistRepository
    {
        /// <summary>
        /// Retrieves all wishlist products of a particular user.
        /// </summary>
        /// <param name="userName">Username of the user.</param>
        /// <returns>List of wishlist products.</returns>
        List<Cart> GetWishlist(string userName);

        /// <summary>
        /// Adds a product to the user's wishlist.
        /// </summary>
        /// <param name="cart">Wishlist product details.</param>
        void AddToWishlist(Cart cart);

        /// <summary>
        /// Removes a product from the user's wishlist.
        /// </summary>
        /// <param name="userName">Username of the user.</param>
        /// <param name="productName">Name of the product.</param>
        void RemoveFromWishlist(string userName, string productName);
    }
}