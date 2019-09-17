using System;

namespace OrdersApp.Domain.Core
{
    public class Ticket
    {
        private Ticket() { }
        public Ticket(Order order)
        {
            Order = order;
            Code = Guid.NewGuid().ToString();
            Amount = Order.Amount;
            Date = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Code { get; private set; }
        public double Amount { get; private set; }
        public DateTime Date { get; private set; }
        public Order Order {get; private set; }
    }
}
