using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OrdersApp.Domain.Core;
using OrdersApp.Domain.Data.Mappings;

namespace OrdersApp.Domain.Data
{
    public class OrdersAppContext : DbContext
    {
        public OrdersAppContext(DbContextOptions<OrdersAppContext> options)
            : base(options)
        { }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientsMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
