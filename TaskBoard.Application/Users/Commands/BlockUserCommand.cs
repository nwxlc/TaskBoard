using MediatR;

namespace TaskBoard.Application.Users.Commands;

public class BlockUserCommand : IRequest
{
    public Guid Id { get; set; }
}