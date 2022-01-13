using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Shopping.Api.Models;
using Shopping.Api.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shopping.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ProductDbContext _productDbContext;

        public ProductsController(
            ILogger<ProductsController> logger,
            ProductDbContext productDbContext) => (_logger, _productDbContext) = (logger, productDbContext);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(ProductsController.Get)} action performed");

            var products = await _productDbContext
                                    .Products
                                    .Find(it => true)
                                    .ToListAsync(cancellationToken);

            return StatusCode(StatusCodes.Status200OK, new { products });
        }
    }
}
