using OrdersApp.Domain.Core;
using OrdersApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersApp.Services.Contracts
{
    public interface IOrdersService
    {
        Task<OrderDto> GetOrder(string code);
        Task<Order> CreateOrder(int clientId, IEnumerable<OrderDetailDto> orderDetailsIds);
        Task PaidOrder(string code);
    }
}
