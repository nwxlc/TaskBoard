using MediatR;

namespace TaskBoard.Application.Users.Commands;

public class AddPermissionToUserCommand : IRequest
{
    public Guid PermissionId { get; set; }

    public Guid UserId { get; set; }
}