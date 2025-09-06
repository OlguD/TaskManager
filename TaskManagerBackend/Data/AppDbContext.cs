using Microsoft.EntityFrameworkCore;
using TaskManagerBackend.Models;
namespace TaskManagerBackend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Board> Boards { get; set; }
    public DbSet<Card> Cards { get; set; }
}