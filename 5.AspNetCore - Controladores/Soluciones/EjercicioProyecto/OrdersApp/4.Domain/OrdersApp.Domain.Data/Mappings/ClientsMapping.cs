using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdersApp.Domain.Core;

namespace OrdersApp.Domain.Data.Mappings
{
    public class ClientsMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Customers");

            builder.Property(client => client.Name).IsRequired();
            builder.Property(client => client.Email).HasMaxLength(50);
            builder.HasMany(client => client.Orders).WithOne(o => o.Client).IsRequired();
        }
    }
}
