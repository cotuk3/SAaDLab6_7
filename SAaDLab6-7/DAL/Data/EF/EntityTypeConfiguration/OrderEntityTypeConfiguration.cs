using Microsoft.EntityFrameworkCore;
using SAaDLab4_5.DAL.Models;

namespace SAaDLab4_5.DAL.Data.EF.EntityTypeConfiguration;
public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
    {
        builder
            .Property(t => t.Date)
            .HasPrecision(0);
    }
}
