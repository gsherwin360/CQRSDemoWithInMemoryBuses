namespace CQRSDemoWithInMemoryBuses.Commands
{
    public sealed record CreateProductCommand(
        string Name,
        string Category,
        string Description,
        float Price)
        : ICommand<Guid>;
}