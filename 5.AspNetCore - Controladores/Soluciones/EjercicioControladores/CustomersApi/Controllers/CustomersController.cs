using CustomersApi.Services;
using CustomersApi.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ICustomersService customersService, ILogger<CustomersController> logger)
        {
            _customersService = customersService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAlls()
        {
            var clients = await _customersService.GetAlls();
            return Ok(clients);
        }

        [HttpGet("bypage")]
        public async Task<ActionResult> GetByPage(int page)
        {
            var clientsTask = _customersService.GetItemsPerPage(page);
            var countTask = _customersService.Count();

            await Task.WhenAll(clientsTask, countTask);

            return Ok(new
            {
                Items = clientsTask.Result,
                Count = countTask.Result
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> Get(int id)
        {
            var client = await _customersService.Get(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPut]
        public async Task<ActionResult> Put(CustomerDto customer)
        {
            await _customersService.Update(customer);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CustomerDto customer)
        {
            var id = await _customersService.Create(customer);
            return Created($"/customers/{id}", id);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogWarning("Se va a borrar un cliente");
            await _customersService.Delete(id);
            return Ok();
        }
    }
}
