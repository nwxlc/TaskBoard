using MediatR;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Problems.Queries;

public class GetProblemByIdQuery : IRequest<Problem>
{
    public Guid Id { get; set; }
}