using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersApp.Domain.Core
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public Order Order {get; set; }
    }
}
