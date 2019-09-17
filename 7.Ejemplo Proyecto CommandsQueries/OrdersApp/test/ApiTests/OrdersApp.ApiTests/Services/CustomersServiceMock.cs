using OrdersApp.Domain.Core;
using OrdersApp.Domain.Models;
using OrdersApp.Domain.Models.Extensions;
using OrdersApp.ApiTests.Extensions;
using OrdersApp.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApp.ApiTests.Services
{
    public class CustomersServiceMock : ICustomersService
    {
        private List<Customer> _customers;

        public CustomersServiceMock()
        {
            _customers = new List<Customer>();
        }

        public async Task<int> AddCustomer(CustomerDto customerDto)
        {
            var customer = new Customer(
                customerDto.Name,
                customerDto.Surname,
                customerDto.Age,
                customerDto.Email,
                customerDto.Gender);
            customer.SetProperty(c => c.Id, this._customers.Count + 1);

            _customers.Add(customer);
            return customer.Id;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            return _customers.Select(c => c.ToMapper());
        }
    }
}
