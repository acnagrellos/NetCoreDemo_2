using OrdersApp.Domain.Core;
using OrdersApp.Domain.Data;
using OrdersApp.Domain.Models;
using OrdersApp.Services.Contracts.Customers;
using System.Threading.Tasks;

namespace OrdersApp.Services.Commands
{
    public class AddCustomerCommand : IAddCustomerCommand
    {
        private readonly OrdersAppContext _context;
        public AddCustomerCommand(OrdersAppContext context)
        {
            _context = context;
        }

        public async Task<int> Handler(CustomerDto customerDto)
        {
            var customer = new Customer(
                customerDto.Name, 
                customerDto.Surname, 
                customerDto.Age, 
                customerDto.Email, 
                customerDto.Gender);

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }
    }
}
