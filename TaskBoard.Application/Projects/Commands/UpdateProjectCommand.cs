namespace TaskBoard.Application.Projects.Commands;

public class UpdateProjectCommand
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}