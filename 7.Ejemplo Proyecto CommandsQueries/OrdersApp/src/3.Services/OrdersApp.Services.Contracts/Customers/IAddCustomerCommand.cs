using OrdersApp.Domain.Models;
using System.Threading.Tasks;

namespace OrdersApp.Services.Contracts.Customers
{
    public interface IAddCustomerCommand
    {
        Task<int> Handler(CustomerDto customerDto);
    }
}
