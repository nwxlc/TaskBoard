using MediatR;

namespace TaskBoard.Application.Sprints.Commands;

public class CreateSprintCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Comment { get; set; }
    public Guid ProjectId { get; set; }
}