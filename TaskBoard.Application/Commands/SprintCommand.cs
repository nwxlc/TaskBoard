namespace TaskBoard.Application.Commands;

public class SprintCommand
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Comment { get; set; }
}