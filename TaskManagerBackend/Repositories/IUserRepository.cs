using TaskManagerBackend.Models;
namespace TaskManagerBackend.Repositories;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByUsernameAsync(string username);
    Task<string?> Validate(string username, string passwordHash);
}