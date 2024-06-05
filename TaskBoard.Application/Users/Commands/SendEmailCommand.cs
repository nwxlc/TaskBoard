using MediatR;

namespace TaskBoard.Application.Users.Commands;

public class SendEmailCommand : IRequest<string>
{
    public string Email { get; set; }
}