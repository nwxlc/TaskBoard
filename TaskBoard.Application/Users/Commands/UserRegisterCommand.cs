using MediatR;

namespace TaskBoard.Application.Users.Commands;

public class UserRegisterCommand : IRequest<Guid>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}