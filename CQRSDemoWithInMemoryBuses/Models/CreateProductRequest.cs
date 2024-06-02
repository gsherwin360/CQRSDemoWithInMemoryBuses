namespace CQRSDemoWithInMemoryBuses.Models
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }
    }
}