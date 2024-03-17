namespace TaskBoard.Application.Commands;

public class ProjectCommand
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}