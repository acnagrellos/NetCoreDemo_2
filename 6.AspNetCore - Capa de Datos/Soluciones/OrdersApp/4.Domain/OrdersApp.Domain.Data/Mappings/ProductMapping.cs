using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdersApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersApp.Domain.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(p => p.OrderDetails).WithOne(o => o.Product);
        }
    }
}
