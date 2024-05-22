using MediatR;

namespace TaskBoard.Application.Users.Commands;

public class AddRoleToUserCommand : IRequest
{
    public Guid RoleId { get; set; }

    public Guid UserId { get; set; }
}