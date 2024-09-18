namespace ProjectAPI.Models;

/// <summary>
/// Represents a project within the system.
/// </summary>
public class Project
{
    public int ProjectId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    /// Gets or sets the collection of employees assigned to the project.
    /// A project can have multiple employees assigned to it.
    /// This property is optional and can be null.
    public ICollection<Employee>? Employees { get; set; }
}

