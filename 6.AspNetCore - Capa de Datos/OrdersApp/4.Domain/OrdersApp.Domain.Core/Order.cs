using System.Collections.Generic;

namespace OrdersApp.Domain.Core
{
    public class Order
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public Client Client { get; set; }
        public Ticket Ticket { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
