using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;

public class AppDbContext : DbContext
{
    public DbSet<Project>? Projects { get; set; }
    public DbSet<Employee>? Employees { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // One-to-many relationship between Project and Employee
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Project)
            .WithMany(p => p.Employees)
            .HasForeignKey(e => e.ProjectId);
    }
}
