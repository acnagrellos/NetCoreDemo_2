using Microsoft.AspNetCore.Mvc;
using OrdersApp.Api.Configuration;
using OrdersApp.Domain.Models;
using OrdersApp.Domain.Models.Exceptions;
using OrdersApp.Services.Contracts;
using System.Threading.Tasks;

namespace OrdersApp.Api.Core.Controllers
{
    [Route(ApiConstants.BaseUri + "/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;
        private readonly IOrdersService _ordersService;

        public ClientsController(
            IClientsService clientsService,
            IOrdersService ordersService)
        {
            _clientsService = clientsService;
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAlls()
        {
            var clients = await _clientsService.GetAlls();
            return Ok(clients);
        }

        [HttpGet(ApiConstants.IdParamUri)]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            var client = await _clientsService.Get(id);
            return Ok(client);
        }

        [HttpGet("byname")]
        public async Task<ActionResult> GetByName([FromQuery] string name)
        {
            var client = await _clientsService.Get(name);
            return Ok(client);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ClientDto client)
        {
            if (string.IsNullOrEmpty(client.Name) || string.IsNullOrEmpty(client.Surname))
            {
                throw new PreConditionFailedModelException();
            }

            await _clientsService.Update(client);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientDto client)
        {
            if (string.IsNullOrEmpty(client.Name) || string.IsNullOrEmpty(client.Surname))
            {
                throw new PreConditionFailedModelException();
            }

            var id = await _clientsService.Create(client);
            return Created($"/{ApiConstants.BaseUri}/{ApiConstants.ClientUri}/{id}", id);
        }

        [HttpGet(ApiConstants.IdParamUri + "/" + ApiConstants.OrderUri + "/" + ApiConstants.OrderCodeUri)]
        public async Task<ActionResult> GetOrder([FromRoute] int id, [FromRoute] string code)
        {
            var order = await _ordersService.GetOrder(code);
            return Ok(order);
        }

        [HttpPost(ApiConstants.IdParamUri + "/" + ApiConstants.OrderUri)]
        public async Task<ActionResult> CreateOrder([FromRoute] int id, [FromBody] OrderDto order)
        {
            if (order?.Details == null)
            {
                throw new PreConditionFailedModelException();
            }

            var orderCreated = await _ordersService.CreateOrder(id, order.Details);
            return Created($"/{ApiConstants.BaseUri}/{ApiConstants.ClientUri}/{id}/{ApiConstants.OrderUri}/{orderCreated.Ticket.Code}", orderCreated.Ticket.Code);
        }

        [HttpPost(ApiConstants.IdParamUri + "/" + ApiConstants.OrderUri + "/" + ApiConstants.OrderCodeUri + "/" + ApiConstants.ClientPaidUri)]
        public async Task<ActionResult> PaidOrder([FromRoute] string code)
        {
            await _ordersService.PaidOrder(code);
            return Ok();
        }
    }
}
