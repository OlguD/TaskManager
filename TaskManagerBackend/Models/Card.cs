namespace TaskManagerBackend.Models;

public class Card
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? DueDate = null;
    public int BoardId { get; set; }
    public Board Board { get; set; }
}