using GroceryShopApp.Repository;

namespace GroceryShopApp.Services
{
    /// <summary>
    /// Handles the business logics for the wishlist.
    /// </summary>
    internal class WishlistServices
    {
        private readonly WishlistRepository _wishlistRepository;
        private readonly ProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="WishlistServices"/> class.
        /// </summary>
        /// <param name="wishlistRepository">Repository of the wishlist.</param>
        /// <param name="productRepository">Repository of the products.</param>
        public WishlistServices(WishlistRepository wishlistRepository, ProductRepository productRepository)
        {
            this._wishlistRepository = wishlistRepository;
            this._productRepository = productRepository;
        }
    }
}