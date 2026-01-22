using System;
using amadeus_api.database.models;
using Microsoft.EntityFrameworkCore;

namespace amadeus_api.database;

public class AmaContext(DbContextOptions<AmaContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectPhase> ProjectPhases { get; set; }
    public DbSet<ProjectTask> ProjectTasks { get; set; }
    public DbSet<RegisteredTaskTime> RegisteredTaskTime { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<TodoTask> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasMany(u => u.Projects)
            .WithOne(p => p.Owner)
            .HasForeignKey(p => p.OwnerId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Todos)
            .WithOne(t => t.Owner)
            .HasForeignKey(t => t.OwnerId);

        modelBuilder.Entity<Project>()
            .HasOne(u => u.Customer)
            .WithMany(p => p.Projects)
            .HasForeignKey(p => p.CustomerId);

        modelBuilder.Entity<Project>()
            .HasMany(u => u.Phases)
            .WithOne(p => p.Project)
            .HasForeignKey(p => p.ProjectId);

        modelBuilder.Entity<Project>()
            .HasMany(u => u.Tasks)
            .WithOne(p => p.Project)
            .HasForeignKey(p => p.ProjectId);

        modelBuilder.Entity<ProjectTask>()
            .HasOne(u => u.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(p => p.ProjectId);

        modelBuilder.Entity<ProjectTask>()
            .HasOne(u => u.Phase)
            .WithMany(p => p.Tasks)
            .HasForeignKey(p => p.ProjectId);

        modelBuilder.Entity<Project>()
            .HasOne(u => u.CMDB)
            .WithOne(p => p.Project);

        

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
