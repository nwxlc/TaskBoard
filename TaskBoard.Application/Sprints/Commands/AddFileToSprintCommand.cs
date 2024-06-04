using MediatR;

namespace TaskBoard.Application.Sprints.Commands;

public class AddFileToSprintCommand : IRequest<Guid>
{
    public Guid SprintId { get; set; }

    public Guid FileId { get; set; }
}