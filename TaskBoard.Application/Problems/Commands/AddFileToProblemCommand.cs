using MediatR;

namespace TaskBoard.Application.Problems.Commands;

public class AddFileToProblemCommand : IRequest<Guid>
{
    public Guid ProblemId { get; set; }

    public Guid FileId { get; set; }
}