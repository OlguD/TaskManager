namespace TaskManagerBackend.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int OwnerId { get; set; }
    public User Owner { get; set; }
    public List<Board> Boards { get; set; }
}