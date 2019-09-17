using OrdersApp.Domain.Core;
using OrdersApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersApp.Services.Contracts.Customers
{
    public interface IGetCustomersQuery
    {
        Task<IEnumerable<CustomerDto>> Execute();
    }
}
