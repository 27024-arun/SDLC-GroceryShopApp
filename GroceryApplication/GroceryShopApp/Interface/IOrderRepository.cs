using GroceryShopApp.Model;

namespace GroceryShopApp.Interface
{
    /// <summary>
    /// Defines the operations for the order repository.
    /// </summary>
    internal interface IOrderRepository
    {
        /// <summary>
        /// Adds a new order to the repository.
        /// </summary>
        /// <param name="order">Order details.</param>
        void AddOrder(Order order);

        /// <summary>
        /// Retrieves all the orders.
        /// </summary>
        /// <returns>List of all orders.</returns>
        List<Order> GetAllOrders();

        /// <summary>
        /// Retrieves orders of a particular user.
        /// </summary>
        /// <param name="userName">Username of the user.</param>
        /// <returns>List of user orders.</returns>
        List<Order> GetUserOrders(string userName);
    }
}