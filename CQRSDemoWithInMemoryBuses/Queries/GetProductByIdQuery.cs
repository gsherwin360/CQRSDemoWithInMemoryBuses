using CQRSDemoWithInMemoryBuses.Domain;

namespace CQRSDemoWithInMemoryBuses.Queries
{
    public sealed record GetProductByIdQuery(Guid id) : IQuery<Product>;

    public sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, Product>
    {
        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken = default)
        {
            var product = ProductManager.GetAllProducts().SingleOrDefault(c => c.Id == request.id);
            return Task.FromResult(product);
        }
    }
}