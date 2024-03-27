using MediatR;

namespace TaskBoard.Application.Sprints.Commands;

public class DeleteSprintCommand : IRequest
{
    public Guid Id { get; set; }
}