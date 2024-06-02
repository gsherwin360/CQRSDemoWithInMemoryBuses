namespace CQRSDemoWithInMemoryBuses.Domain
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Category { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public float Price { get; private set; }

        private Product() { }

        public static Product Create(string name, string category, string description, float price)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }

            if (string.IsNullOrEmpty(category))
            {
                throw new ArgumentException($"'{nameof(category)}' cannot be null or empty.", nameof(category));
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException($"'{nameof(description)}' cannot be null or empty.", nameof(description));
            }

            if (price < 0)
            {
                throw new ArgumentException($"'{nameof(price)}' must be a non-negative value.", nameof(price));
            }

            var product = new Product();
            product.Id = Guid.NewGuid();
            product.Name = name;
            product.Category = category;
            product.Description = description;
            product.Price = price;

            return product;
        }
    }
}