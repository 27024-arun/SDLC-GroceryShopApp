using GroceryShopApp.Model;

namespace GroceryShopApp.Interface
{
    /// <summary>
    /// Defines the operations for the product repository.
    /// </summary>
    internal interface IProductRepository
    {
        /// <summary>
        /// Retrieves all the products from the files.
        /// </summary>
        /// <returns>Products from files.</returns>
        List<Product> GetAllProducts();

        /// <summary>
        /// Updates the stock quantity of a purchased product.
        /// </summary>
        /// <param name="productName">Name of the product.</param>
        /// <param name="quantity">Quantity to be reduced.</param>
        void UpdateProductStock(string productName, int quantity);

        /// <summary>
        /// Sets the available stock quantity of a product.
        /// </summary>
        /// <param name="productName">Name of the product.</param>
        /// <param name="quantity">New stock quantity.</param>
        /// <returns>Returns whether the stock was updated or not.</returns>
        bool SetProductStock(string productName, int quantity);

        /// <summary>
        /// Adds the given quantity to the existing stock of a product.
        /// </summary>
        /// <param name="productName">Name of the product.</param>
        /// <param name="quantity">Quantity to be added.</param>
        /// <returns>Returns whether the stock was updated or not.</returns>
        bool AddProductStock(string productName, int quantity);

        /// <summary>
        /// Retrieves products whose stock is at or below the low-stock limit.
        /// </summary>
        /// <returns>List of low-stock products.</returns>
        List<Product> GetLowStockProducts();
    }
}