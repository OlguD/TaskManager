using Microsoft.EntityFrameworkCore;
using TaskManagerBackend.Data;
using TaskManagerBackend.Models;
namespace TaskManagerBackend.Repositories;

public class BoardRepository : IBoardRepository
{
    private readonly AppDbContext _context;
    
    public BoardRepository(AppDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<Board> CreateBoardAsync(string title, int projectId, Card[] cards)
    {
        if (!string.IsNullOrEmpty(title) && projectId != null)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project != null)
            {
                var newBoard = new Board
                {
                    Title = title,
                    ProjectId = projectId,
                    Project = project,
                    Cards = cards?.ToList() ?? new List<Card>()
                };    
                _context.Boards.Add(newBoard);
                await _context.SaveChangesAsync();
                return newBoard;
            }
            else
            {
                throw new ArgumentException("Project not found.");
            } 
        }
        else
        {
            throw new ArgumentException("Title and Project cannot be null or empty.");
        }
    }

    public async Task<bool> DeleteBoardAsync(int id)
    {
        var boardToDelete = await _context.Boards.FirstOrDefaultAsync(b => b.Id == id);
        if (boardToDelete != null)
        {
            _context.Boards.Remove(boardToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
    
    public async Task<Board?> GetBoardByIdAsync(int id)
    {
        return await _context.Boards
            .FirstOrDefaultAsync(b => b.Id == id);
    }
    
    public async Task<IEnumerable<Board>> GetBoardsByProjectIdAsync(int projectId)
    {
        return await _context.Boards
            .Where(b => b.ProjectId == projectId)
            .ToListAsync();
    }
}