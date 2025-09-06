using Microsoft.EntityFrameworkCore;
using TaskManagerBackend.Data;
using TaskManagerBackend.Models;

namespace TaskManagerBackend.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Project>> GetAllProjectsAsync(int userId)
    {
        return await _context.Projects
            .Include(p => p.Boards)
            .Where(p => p.OwnerId == userId)
            .ToListAsync();
    }

    public async Task<Project?> GetProjectByIdAsync(int id)
    {
        return await _context.Projects
            .Include(p => p.Boards)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Project> CreateProjectAsync(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task DeleteProjectAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project != null)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}