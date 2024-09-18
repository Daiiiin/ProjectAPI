namespace ProjectAPI.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents an employee within the system.
    /// </summary>
    public class Employee
    {
        public int EmployeeId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required int ProjectId { get; set; }

        /// Gets or sets the project associated with the employee. This property is optional and can be null.
        /// It is marked with [JsonIgnore] to prevent serialization during JSON operations.
        [JsonIgnore]
        public Project? Project { get; set; }
    }
}
