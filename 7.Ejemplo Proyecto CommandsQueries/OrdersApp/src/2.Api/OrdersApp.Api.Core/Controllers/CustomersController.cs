using Microsoft.AspNetCore.Mvc;
using OrdersApp.Api.Configuration;
using OrdersApp.Domain.Models;
using OrdersApp.Services.Contracts;
using System.Threading.Tasks;

namespace OrdersApp.Api.Core.Controllers
{
    [ApiController]
    [Route(ApiConstants.BaseUri + "/" + ApiConstants.CustomerUri)]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customerService;
        public CustomersController(ICustomersService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAlls()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult> AddCistomer([FromBody] CustomerDto customerDto)
        {
            var id = await _customerService.AddCustomer(customerDto);
            return Ok(id);
        }
    }
}
