using MediatR;

namespace TaskBoard.Application.Users.Commands;

public class UserLoginCommand : IRequest<string>
{
    public string Email { get; set; }
    public string Password { get; set; }
}