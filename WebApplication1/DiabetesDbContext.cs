using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1;

public class DiabetesDbContext : DbContext
{
    public DiabetesDbContext(DbContextOptions<DiabetesDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Data> Datas { get; set; }
    public DbSet<Meal> Meals { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<Data>().ToTable("Data");
        modelBuilder.Entity<Meal>().ToTable("Meal");
    }
    
    
}