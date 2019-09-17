using System.Collections.Generic;

namespace OrdersApp.Domain.Models
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public IEnumerable<OrderDetailDto> Details { get; set; }
    }
}
