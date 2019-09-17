using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdersApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersApp.Domain.Data.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(o => o.OrderDetails).WithOne(o => o.Order);
            builder.HasOne(o => o.Ticket)
                   .WithOne(o => o.Order)
                   .HasForeignKey<Order>(b => b.TicketId);
        }
    }
}
