using System.Net;
using Microsoft.AspNetCore.Mvc;
using OrdersApp.Api.Configuration;
using OrdersApp.Domain.Models;
using OrdersApp.Services.Contracts;
using System.Threading.Tasks;

namespace OrdersApp.Api.Core.Controllers
{
    [Route(ApiConstants.BaseUri + "/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAlls()
        {
            var clients = await _productsService.GetAlls();
            return Ok(clients);
        }

        [HttpGet(ApiConstants.IdParamUri)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            var client = await _productsService.Get(id);
            return Ok(client);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Put([FromBody] ProductDto productDto)
        {
            await _productsService.Update(productDto);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> Post([FromBody] ProductDto productDto)
        {
            var id = await _productsService.Create(productDto);
            return Created($"/{ApiConstants.BaseUri}/{ApiConstants.IdParamUri}/{id}", id);
        }
    }
}
