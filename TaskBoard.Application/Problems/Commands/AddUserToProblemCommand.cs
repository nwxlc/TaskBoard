using MediatR;

namespace TaskBoard.Application.Problems.Commands;

public class AddUserToProblemCommand : IRequest<Guid>
{
    public Guid ProblemId { get; set; }

    public string UserEmail { get; set; }
}