using Microsoft.EntityFrameworkCore;
using SAaDLab4_5.DAL.Models;

namespace SAaDLab4_5.DAL.Data.EF.EntityTypeConfiguration;
public class QuestEntityTypeConfiguration : IEntityTypeConfiguration<Quest>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Quest> builder)
    {
        builder.
            Property(t => t.TimeToComplete)
            .HasPrecision(0);

        builder
            .Property(t => t.Price)
            .HasColumnType("money")
            .HasPrecision(0);

        int id = 0;
        builder
            .HasData(
            new Quest[]
            {
                new Quest{Id = ++id, Name = "Quest1", ParticipantsQuantity = 4, Price = 1500, TimeToComplete = new(1,30,0)}
                ,new Quest {Id = ++id, Name = "Quest2", ParticipantsQuantity = 2, Price = 2500, TimeToComplete = new(2,20,0)}
                ,new Quest{Id = ++id, Name = "Quest3", ParticipantsQuantity = 4, Price = 1250, TimeToComplete = new(1,0,0)}
                ,new Quest {Id = ++id, Name = "Quest4", ParticipantsQuantity = 4, Price = 1700, TimeToComplete = new(2,0,0)}
            }
            );


    }
}
