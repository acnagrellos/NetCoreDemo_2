using System.Collections.Generic;
using System.Linq;

namespace OrdersApp.Domain.Core
{
    public class Order
    {
        private Order() { }

        public Order(Client client, IEnumerable<OrderDetail> orderDetails)
        {
            Client = client;
            Amount = orderDetails.Sum(detail => detail.Quantity * detail.Product.Price);
            Ticket = new Ticket(this);
            OrderDetails = orderDetails.ToList();
            State = OrderState.Pending;
        }

        public int Id { get; private set; }
        public double Amount { get; private set; }
        public Client Client { get; private set; }
        public int TicketId { get; private set; }
        public Ticket Ticket { get; private set; }
        public OrderState State { get; private set; }
        public ICollection<OrderDetail> OrderDetails { get; private set; }

        public void Paid()
        {
            State = OrderState.Paid;
        }
    }
}
