using OrdersApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrdersApp.Domain.Models
{
    public static class OrderExtensions
    {
        public static OrderDto ToMapper(this Order order)
        {
            return new OrderDto
            {
                OrderId = order.Id,
                Details = order.OrderDetails.Select(detail => new OrderDetailDto
                {
                    ProductId = detail.Product.Id,
                    Quantity = detail.Quantity
                })
            };
        }
    }
}
