using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopii.Domain.Commands.v1.Products.CreateProduct;
using Shopii.Domain.Commands.v1.Products.GetProductsPaginated;

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
                return Created(result.Id, result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("paged")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProducts([FromHeader] int pageNumber, int pageSize)
        {
            try
            {
                var result = await Mediator.Send(new GetProductsPaginatedCommand { PageNumber = pageNumber, PageSize = pageSize });
                return result.Products.Any() ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
