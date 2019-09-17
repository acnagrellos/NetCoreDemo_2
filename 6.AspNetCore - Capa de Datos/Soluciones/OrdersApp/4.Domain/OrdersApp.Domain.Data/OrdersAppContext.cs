using Microsoft.EntityFrameworkCore;
using OrdersApp.Domain.Core;
using OrdersApp.Domain.Data.Mappings;

namespace OrdersApp.Domain.Data
{
    public class OrdersAppContext : DbContext
    {
        public OrdersAppContext(DbContextOptions<OrdersAppContext> options)
            : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ticket> Ticket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
