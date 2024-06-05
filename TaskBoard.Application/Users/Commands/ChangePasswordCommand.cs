using MediatR;

namespace TaskBoard.Application.Users.Commands;

public class ChangePasswordCommand : IRequest<Guid>
{
    public string Email { get; set; }

    public string Password { get; set; }

    public string Token { get; set; }
}