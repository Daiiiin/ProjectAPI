namespace ProjectAPI.Models;

using System.Text.Json.Serialization;


public class Employee
{
    public int EmployeeId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    // Foreign key to Project
    public required int ProjectId { get; set; }

    [JsonIgnore]
    public Project? Project { get; set; }  // Navigation property
}
