namespace TaskManagerBackend.Models;

public class BoardCreateRequest
{
    public string Title { get; set; }
    public int ProjectId { get; set; }
    public Card[] Cards { get; set; }
}