using TaskManagerBackend.Models;

namespace TaskManagerBackend.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllProjectsAsync(int userId);
    Task<Project?> GetProjectByIdAsync(int id);
    Task<Project> CreateProjectAsync(Project project);
    Task DeleteProjectAsync(int id);
}