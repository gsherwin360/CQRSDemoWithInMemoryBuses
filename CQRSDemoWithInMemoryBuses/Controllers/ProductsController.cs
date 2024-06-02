using CQRSDemoWithInMemoryBuses.Buses;
using CQRSDemoWithInMemoryBuses.Commands;
using CQRSDemoWithInMemoryBuses.Domain;
using CQRSDemoWithInMemoryBuses.Models;
using CQRSDemoWithInMemoryBuses.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemoWithInMemoryBuses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public ProductsController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus ?? throw new ArgumentNullException(nameof(commandBus));
            _queryBus = queryBus ?? throw new ArgumentNullException(nameof(queryBus));
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var createProductCommand = new CreateProductCommand(
                request.Name,
                request.Category,
                request.Description,
                request.Price);

            var productId = await _commandBus.Send<CreateProductCommand, Guid>(createProductCommand);

            return this.CreatedAtAction(nameof(GetProduct), new { id = productId }, productId);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _queryBus.Query<GetAllProductsQuery, List<Product>>(new GetAllProductsQuery());

            return this.Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var result = await _queryBus.Query<GetProductByIdQuery, Product>(new GetProductByIdQuery(id));

            return result is not null ? this.Ok(result) : this.NotFound();
        }
    }
}