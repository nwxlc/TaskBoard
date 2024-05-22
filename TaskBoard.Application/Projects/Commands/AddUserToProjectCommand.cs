using MediatR;

namespace TaskBoard.Application.Projects.Commands;

public class AddUserToProjectCommand : IRequest<Guid>
{
    public Guid ProjectId { get; set; }
    public string UserEmail { get; set; }
}