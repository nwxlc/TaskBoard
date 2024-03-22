namespace TaskBoard.Application.Sprints.Commands;

public class CreateSprintCommand
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Comment { get; set; }
}