using CQRSDemoWithInMemoryBuses.Domain;

namespace CQRSDemoWithInMemoryBuses.Commands
{
    public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
    {
        public Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken = default)
        {
            var product = Product.Create(command.Name, command.Category, command.Description, command.Price);
            ProductManager.AddProduct(product);
            return Task.FromResult(product.Id);
        }
    }
}