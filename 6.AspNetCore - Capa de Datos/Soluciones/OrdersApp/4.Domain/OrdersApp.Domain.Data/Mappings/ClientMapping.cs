using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdersApp.Domain.Core;

namespace OrdersApp.Domain.Data.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Customers");

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Surname).IsRequired();
            builder.Property(c => c.Email).IsRequired();

            builder.HasMany(c => c.Orders)
                   .WithOne(o => o.Client);
        }
    }
}
