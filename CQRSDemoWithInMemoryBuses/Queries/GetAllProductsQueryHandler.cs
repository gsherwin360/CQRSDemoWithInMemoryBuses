using CQRSDemoWithInMemoryBuses.Domain;

namespace CQRSDemoWithInMemoryBuses.Queries
{
    public sealed class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, List<Product>>
    {
        public Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(ProductManager.GetAllProducts());
        }
    }
}