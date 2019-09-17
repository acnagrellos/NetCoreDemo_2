namespace OrdersApp.Domain.Core
{
    public class OrderDetail
    {
        private OrderDetail() { }
        public OrderDetail(int quantity, Product product)
        {
            Quantity = quantity;
            Product = product;
        }

        public int Id { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
