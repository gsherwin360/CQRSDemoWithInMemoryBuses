namespace CQRSDemoWithInMemoryBuses.Domain
{
    /// <summary>
    /// Provides functionality for managing products in memory.
    /// </summary>
    public static class ProductManager
    {
        private static readonly List<Product> _productList = new List<Product>();

        public static void AddProduct(Product product)
        {
            if (product is null) throw new ArgumentNullException(nameof(product));

            _productList.Add(product);
        }

        public static List<Product> GetAllProducts()
        {
            return _productList;
        }
    }
}