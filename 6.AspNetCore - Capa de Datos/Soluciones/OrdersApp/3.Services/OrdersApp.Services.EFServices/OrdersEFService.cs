using OrdersApp.Domain.Data;
using OrdersApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrdersApp.Domain.Models;
using OrdersApp.Domain.Core;

namespace OrdersApp.Services.EFServices
{
    public class OrdersEFService : IOrdersService
    {
        private readonly OrdersAppContext _context;
        public OrdersEFService(OrdersAppContext context)
        {
            _context = context;
        }

        public async Task<OrderDto> GetOrder(string code)
        {
            var order = await _context.Orders
                                      .Include(o => o.OrderDetails)
                                      .ThenInclude(detail => detail.Product)
                                      .FirstOrDefaultAsync(o => o.Ticket.Code == code);
            return order.ToMapper();
        }

        public async Task<Order> CreateOrder(int clientId, IEnumerable<OrderDetailDto>orderDetailsIds)
        {
            var client = await _context.Clients.FindAsync(clientId);
            var productIds = orderDetailsIds.Select(detail => detail.ProductId).ToList();
            var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();

            var orderDetails = orderDetailsIds.Select(detail =>
                new OrderDetail(detail.Quantity, products.FirstOrDefault(p => p.Id == detail.ProductId)));

            var order = new Order(client, orderDetails);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task PaidOrder(string code)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(orderDomain => orderDomain.Ticket.Code == code);
            order.Paid();
            await _context.SaveChangesAsync();
        }
    }
}
