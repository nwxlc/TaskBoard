using MediatR;

namespace TaskBoard.Application.Users.Commands;

public class AddUserToProblemCommand : IRequest<Guid>
{
    public Guid ProblemId { get; set; }

    public string UserEmail { get; set; }
}