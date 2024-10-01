using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopii.Domain.Commands.v1.Products.CreateProduct;
using Shopii.Domain.Queries.v1.Product.GetProductByFIlter;

namespace Shopii.API.Controllers
{
    [ApiController]
    [Route("api/v1/product")]
    public class ProductController : ControllerBase
    {
        public IMediator Mediator { get; set; }
        public ILogger Logger { get; set; }

        public ProductController(
            IMediator mediator,
            ILoggerFactory logger)
        {
            Mediator = mediator;
            Logger = logger.CreateLogger<ProductController>();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand request)
        {
            try
            {
                var result = await Mediator.Send(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetProducts([FromHeader] string? name, string? description, decimal? price, DateTime? createdDate)
        {
            try
            {
                var result = await Mediator.Send(new GetProductByFilterQuery(name, description, price, createdDate));
                return result.Products.Any() ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
