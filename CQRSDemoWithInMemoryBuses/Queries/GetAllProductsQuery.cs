using CQRSDemoWithInMemoryBuses.Domain;

namespace CQRSDemoWithInMemoryBuses.Queries
{
    public sealed record GetAllProductsQuery() : IQuery<List<Product>>;
}