namespace TaskBoard.Models;

public class Project
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Decription { get; set; }

    public List<Sprint> Sprints { get; set; }
}