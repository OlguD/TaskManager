namespace TaskManagerBackend.Models;

public class Board
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public List<Card> Cards { get; set; }
}