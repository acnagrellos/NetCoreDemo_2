using OrdersApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersApp.Services.Contracts
{
    public interface ICustomersService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomers();
        Task<int> AddCustomer(CustomerDto customerDto);
    }
}
