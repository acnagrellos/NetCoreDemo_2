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

        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
