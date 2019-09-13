namespace OrdersApp.Domain.Core
{
    public class OrderDetail
    {
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
