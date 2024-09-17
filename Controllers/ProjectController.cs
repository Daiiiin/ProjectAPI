using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProjectController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Project
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
    {
        return await _context.Projects.Include(p => p.Employees).ToListAsync();
    }

    // GET: api/Project/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetProject(int id)
    {
        var project = await _context.Projects.Include(p => p.Employees).FirstOrDefaultAsync(p => p.ProjectId == id);
        // var project = await _context.Projects
        //     .Include(p => p.Employees ?? new List<Employee>())  // Handle null Employees collection
        //     .ToListAsync();

        if (project == null)
        {
            return NotFound();
        }

        return project;
    }

    // POST: api/Project
    [HttpPost]
    public async Task<ActionResult<Project>> PostProject(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProject), new { id = project.ProjectId }, project);
    }

    // PUT: api/Project/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProject(int id, Project project)
    {
        if (id != project.ProjectId)
        {
            return BadRequest();
        }

        _context.Entry(project).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/Project/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project == null)
        {
            return NotFound();
        }

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
