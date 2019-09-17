using OrdersApp.Domain.Models;
using OrdersApp.Services.Contracts;
using OrdersApp.Services.Contracts.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersApp.Services.Core
{
    public class CustomersService : ICustomersService
    {
        private readonly IGetCustomersQuery _getCustomersQuery;
        private readonly IAddCustomerCommand _addCustomerCommand;
        public CustomersService(
            IGetCustomersQuery getCustomersQuery,
            IAddCustomerCommand addCustomerCommand)
        {
            _getCustomersQuery = getCustomersQuery;
            _addCustomerCommand = addCustomerCommand;
        }

        public Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            return _getCustomersQuery.Execute();
        }

        public Task<int> AddCustomer(CustomerDto customerDto)
        {
            return _addCustomerCommand.Handler(customerDto);
        }
    }
}
