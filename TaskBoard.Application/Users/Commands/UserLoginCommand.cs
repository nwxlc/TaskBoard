using MediatR;

namespace TaskBoard.Application.Users.Commands;

public class UserLoginCommand : IRequest<(Guid userId, string tokenResponse)>
{
    public string Email { get; set; }
    public string Password { get; set; }
}