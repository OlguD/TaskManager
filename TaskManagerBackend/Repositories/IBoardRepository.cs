using TaskManagerBackend.Models;
namespace TaskManagerBackend.Repositories;

public interface IBoardRepository
{
    Task<Board> CreateBoardAsync(string title, int projectId, Card[] cards);
    Task<bool> DeleteBoardAsync(int id);
    Task<Board?> GetBoardByIdAsync(int id);
    Task<IEnumerable<Board>> GetBoardsByProjectIdAsync(int projectId);
    
}