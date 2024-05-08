using MediatR;

namespace TaskBoard.Application.Users.Commands;

public class AddUserToProjectCommand : IRequest<Guid>
{
    public Guid ProjectId { get; set; }
    public string UserEmail { get; set; }
}