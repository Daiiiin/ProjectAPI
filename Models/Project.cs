namespace ProjectAPI.Models;

public class Project
{
    public int ProjectId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public ICollection<Employee>? Employees { get; set; }
}
