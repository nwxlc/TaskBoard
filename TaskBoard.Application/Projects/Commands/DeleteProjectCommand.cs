using MediatR;

namespace TaskBoard.Application.Projects.Commands;

public class DeleteProjectCommand : IRequest
{
    public Guid Id { get; set; }
}