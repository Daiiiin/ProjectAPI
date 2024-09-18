using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;

/// <summary>
/// Represents the application's database context, responsible for interacting with the database.
/// </summary>
public class AppDbContext : DbContext
{
    public DbSet<Project>? Projects { get; set; }
    public DbSet<Employee>? Employees { get; set; }

    /// Initializes a new instance of the AppDbContext class with the specified options.
    /// <param name="options">The options used by the DbContext.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    /// Configures the model relationships and constraints using the ModelBuilder.
    /// Establishes a relationship between Employee and Project,
    /// where an employee belongs to a project, and a project can have multiple employees.
    /// <param name="modelBuilder">The ModelBuilder used to configure model relationships.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Project)
            .WithMany(p => p.Employees)
            .HasForeignKey(e => e.ProjectId);
    }
}
