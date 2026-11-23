namespace GroceryShopApp.Model
{
    internal class Product
    {
        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }

        public Categories Category { get; set; }

        public int Quantity { get; set; }
    }
}