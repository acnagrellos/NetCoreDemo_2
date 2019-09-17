using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdersApp.Domain.Core;

namespace OrdersApp.Domain.Data.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(DatabaseConstants.CustomerTable);

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Surname).IsRequired();
            builder.Property(c => c.Email).IsRequired();
        }
    }
}
