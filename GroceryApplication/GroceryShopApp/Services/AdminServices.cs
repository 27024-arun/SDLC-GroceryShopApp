using System.Security.Cryptography;
using System.Text;
using GroceryShopApp.Interface;
using GroceryShopApp.Model;

namespace GroceryShopApp.Services
{
    /// <summary>
    /// Handles the business logics for the admin.
    /// </summary>
    internal class AdminServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminServices"/> class.
        /// </summary>
        /// <param name="userRepository">Repository of users.</param>
        /// <param name="productRepository">Repository of products.</param>
        /// <param name="orderRepository">Repository of orders.</param>
        public AdminServices(IUserRepository userRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            this._userRepository = userRepository;
            this._productRepository = productRepository;
            this._orderRepository = orderRepository;
        }

        /// <summary>
        /// Checks whether the user is an admin or not.
        /// </summary>
        /// <param name="userName">Username of admin.</param>
        /// <param name="password">Password of admin.</param>
        /// <returns>Returns whether the user is admin or not.</returns>
        internal bool IsAdmin(string userName, string password)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            string hashedPassword = Convert.ToHexString(hash).ToLowerInvariant();
            return this._userRepository.IsUserAdmin(userName, hashedPassword);
        }

        /// <summary>
        /// Retrieves all the customer orders.
        /// </summary>
        /// <returns>List of all orders.</returns>
        internal List<Order> GetAllOrders()
        {
            return this._orderRepository.GetAllOrders();
        }

        /// <summary>
        /// Retrieves products whose stock is low.
        /// </summary>
        /// <returns>List of low-stock products.</returns>
        internal List<Product> GetLowStockProducts()
        {
            return this._productRepository.GetLowStockProducts();
        }

        /// <summary>
        /// Updates the stock quantity of a product.
        /// </summary>
        /// <param name="productName">Name of the product.</param>
        /// <param name="quantity">Stock quantity.</param>
        /// <param name="isAddStock">Whether the quantity should be added to the existing stock.</param>
        /// <returns>Returns whether the stock was updated or not.</returns>
        internal bool UpdateProductStock(string productName, int quantity, bool isAddStock)
        {
            if (string.IsNullOrWhiteSpace(productName) || quantity < 0)
            {
                return false;
            }

            if (isAddStock)
            {
                return this._productRepository.AddProductStock(productName.Trim(), quantity);
            }

            return this._productRepository.SetProductStock(productName.Trim(), quantity);
        }

        /// <summary>
        /// Gets all available products.
        /// </summary>
        /// <returns>List of all products.</returns>
        internal List<Product> GetAllProducts()
        {
            return this._productRepository.GetAllProducts();
        }
    }
}