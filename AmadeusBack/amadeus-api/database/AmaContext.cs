using System;
using amadeus_api.database.models;
using Microsoft.EntityFrameworkCore;

namespace amadeus_api.database;

public class AmaContext(DbContextOptions<AmaContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasMany(u => u.Projects)
            .WithOne(p => p.Owner)
            .HasForeignKey(p => p.OwnerId);

        modelBuilder.Entity<Project>()
            .HasOne(u => u.Customer)
            .WithMany(p => p.Projects)
            .HasForeignKey(p => p.CustomerId);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configBuilder = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"));
        
        IConfiguration Config = configBuilder.Build();
        string connectionString = Config.GetConnectionString("Default") ?? "";
        optionsBuilder.UseNpgsql(connectionString);
    }
}
