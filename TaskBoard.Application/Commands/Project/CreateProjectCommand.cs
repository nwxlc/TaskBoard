namespace TaskBoard.Application.Commands.Project;

public class CreateProjectCommand
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}