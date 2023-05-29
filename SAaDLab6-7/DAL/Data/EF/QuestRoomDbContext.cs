using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SAaDLab4_5.DAL.Models;


namespace SAaDLab4_5.DAL.Data.EF;
public class QuestRoomDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Quest> Quests { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;

    public EntityTypeConfiguration.OrderEntityTypeConfiguration OrderEntityTypeConfiguration
    {
        get => default;
        set
        {
        }
    }

    public EntityTypeConfiguration.CustomerEntityTypeConfiguration CustomerEntityTypeConfiguration
    {
        get => default;
        set
        {
        }
    }

    public EntityTypeConfiguration.QuestEntityTypeConfiguration QuestEntityTypeConfiguration
    {
        get => default;
        set
        {
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new()
        {
            ["Server"] = @".\sqlexpress",
            ["DataBase"] = "QuestRoom",
            ["Trusted_Connection"] = true,
            ["TrustServerCertificate"] = true
        };

        optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuestRoomDbContext).Assembly);
    }
}


