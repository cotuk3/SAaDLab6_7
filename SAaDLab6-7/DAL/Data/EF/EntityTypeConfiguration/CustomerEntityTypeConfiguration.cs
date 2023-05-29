using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAaDLab4_5.DAL.Models;

namespace SAaDLab4_5.DAL.Data.EF.EntityTypeConfiguration;
public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .ToTable("Customers");

        builder
        .HasMany(t => t.Orders)
        .WithOne(t => t.Customer)
        .HasForeignKey(t => t.CustomerId)
        .HasPrincipalKey(t => t.Id);
    }
}
