using GroceryShopApp.Services;

namespace GroceryShopApp.View
{
    /// <summary>
    /// Performs the view level operations for the wishlist.
    /// </summary>
    internal class WishlistView
    {
        private readonly WishlistServices _wishlistServices;
        private readonly CartServices _cartServices;
        private readonly CartView _cartView;

        /// <summary>
        /// Initializes a new instance of the <see cref="WishlistView"/> class.
        /// </summary>
        /// <param name="wishlistServices">Services of the wishlist.</param>
        /// <param name="cartServices">Services of the cart.</param>
        /// <param name="cartView">View operations of the cart.</param>
        public WishlistView(WishlistServices wishlistServices, CartServices cartServices, CartView cartView)
        {
            this._wishlistServices = wishlistServices;
            this._cartServices = cartServices;
            this._cartView = cartView;
        }
    }
}