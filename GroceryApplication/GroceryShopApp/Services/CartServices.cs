using GroceryShopApp.Interface;
using GroceryShopApp.Model;

namespace GroceryShopApp.Services
{
    /// <summary>
    /// Handles the business logics for cart and checkout operations.
    /// </summary>
    internal class CartServices
    {
        private const int MaxProductQuantity = 10;
        private const int MaxCartProducts = 20;

        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartServices"/> class.
        /// </summary>
        /// <param name="cartRepository">Repository of the cart.</param>
        /// <param name="productRepository">Repository of the products.</param>
        /// <param name="orderRepository">Repository of the orders.</param>
        public CartServices(ICartRepository cartRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            this._cartRepository = cartRepository;
            this._productRepository = productRepository;
            this._orderRepository = orderRepository;
        }

        /// <summary>
        /// Adds a product to the user's cart.
        /// </summary>
        /// <param name="userName">Username of the user.</param>
        /// <param name="productName">Name of the product.</param>
        /// <param name="quantity">Quantity to be added.</param>
        /// <returns>Returns whether the product was added or not.</returns>
        internal string AddToCart(string userName, string productName, int quantity)
        {
            if (quantity < 1 || quantity > MaxProductQuantity)
            {
                return "Quantity must be between 1 and 10.";
            }

            Product? product = this._productRepository.GetAllProducts().FirstOrDefault(item => item.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                return "Product not found.";
            }

            if (product.Quantity <= 0)
            {
                return "Product is out of stock.";
            }

            List<Cart> carts = this._cartRepository.GetCart(userName);
            Cart? existingCart = carts.FirstOrDefault(item => item.Product.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            int cartQuantity = quantity;
            if (existingCart != null)
            {
                cartQuantity += existingCart.CartQuantity;
            }
            else if (carts.Count >= MaxCartProducts)
            {
                return "Cart cannot contain more than 20 different products.";
            }

            if (cartQuantity > MaxProductQuantity)
            {
                return "Maximum quantity allowed per product is 10.";
            }

            if (cartQuantity > product.Quantity)
            {
                return $"Only {product.Quantity} quantity is available.";
            }

            Cart cart = new Cart
            {
                UserName = userName,
                Product = product,
                CartQuantity = cartQuantity,
            };

            this._cartRepository.AddToCart(cart);
            return "Product added to cart successfully.";
        }

        /// <summary>
        /// Retrieves all products in the user's cart.
        /// </summary>
        /// <param name="userName">Username of the user.</param>
        /// <returns>List of cart products.</returns>
        internal List<Cart> GetCart(string userName)
        {
            return this._cartRepository.GetCart(userName);
        }

        /// <summary>
        /// Calculates the total amount of the user's cart.
        /// </summary>
        /// <param name="userName">Username of the user.</param>
        /// <returns>Total cart amount.</returns>
        internal decimal GetCartTotal(string userName)
        {
            List<Cart> carts = this.GetCart(userName);
            decimal totalAmount = 0;
            foreach (Cart cart in carts)
            {
                totalAmount += cart.Product.Price * cart.CartQuantity;
            }

            return totalAmount;
        }

        /// <summary>
        /// Clears all products from the user's cart.
        /// </summary>
        /// <param name="userName">Username of the user.</param>
        internal void ClearCart(string userName)
        {
            this._cartRepository.RemoveCart(userName);
        }

        /// <summary>
        /// Retrieves the order history of a particular user.
        /// </summary>
        /// <param name="userName">Username of the user.</param>
        /// <returns>List of user orders.</returns>
        internal List<Order> GetUserOrders(string userName)
        {
            return this._orderRepository.GetUserOrders(userName);
        }

        /// <summary>
        /// Processes the checkout of selected products from the user's cart.
        /// </summary>
        /// <param name="userName">Username of the user.</param>
        /// <param name="deliveryAddress">Delivery address.</param>
        /// <param name="deliveryDate">Delivery date.</param>
        /// <param name="deliveryTime">Delivery time slot.</param>
        /// <param name="productNames">Names of products to purchase.</param>
        /// <returns>Returns the order after successful checkout.</returns>
        internal Order? Checkout(string userName, string deliveryAddress, string deliveryDate, string deliveryTime, List<string> productNames)
        {
            List<Cart> carts = this.GetCart(userName).Where(cart => productNames.Contains(cart.Product.Name, StringComparer.OrdinalIgnoreCase)).ToList();
            if (carts.Count == 0)
            {
                return null;
            }

            List<Product> products = this._productRepository.GetAllProducts();

            foreach (Cart cart in carts)
            {
                Product? product = products.FirstOrDefault(item => item.Name.Equals(cart.Product.Name, StringComparison.OrdinalIgnoreCase));
                if (product == null || cart.CartQuantity < 1 || cart.CartQuantity > MaxProductQuantity || product.Quantity < cart.CartQuantity)
                {
                    return null;
                }
            }

            Order order = new Order
            {
                OrderId = this._orderRepository.GetAllOrders().Select(item => item.OrderId).DefaultIfEmpty(0).Max() + 1,
                UserName = userName,
                DeliveryAddress = deliveryAddress,
                DeliveryDate = deliveryDate,
                DeliveryTime = deliveryTime,
                OrderDate = DateTime.Now,
                TotalAmount = 0,
            };

            foreach (Cart cart in carts)
            {
                OrderItem orderItem = new OrderItem
                {
                    ProductName = cart.Product.Name,
                    Price = cart.Product.Price,
                    Quantity = cart.CartQuantity,
                    SubTotal = cart.Product.Price * cart.CartQuantity,
                };

                order.Items.Add(orderItem);
                order.TotalAmount += orderItem.SubTotal;
            }

            foreach (Cart cart in carts)
            {
                this._productRepository.UpdateProductStock(cart.Product.Name, cart.CartQuantity);
            }

            this._orderRepository.AddOrder(order);
            this._cartRepository.RemoveCartItems(userName, productNames);
            return order;
        }
    }
}