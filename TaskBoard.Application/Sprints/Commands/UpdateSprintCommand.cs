using MediatR;

namespace TaskBoard.Application.Sprints.Commands;

public class UpdateSprintCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Comment { get; set; }
}