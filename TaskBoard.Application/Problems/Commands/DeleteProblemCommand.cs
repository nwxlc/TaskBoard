using MediatR;

namespace TaskBoard.Application.Problems.Commands;

public class DeleteProblemCommand : IRequest
{
    public Guid Id { get; set; }
}