using MediatR;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Problems.Queries;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Problems.Handlers;

public class GetByIdProblemHandler : IRequestHandler<GetProblemByIdQuery, Problem>
{
    private readonly IProblemRepository _problemRepository;

    public GetByIdProblemHandler(IProblemRepository problemRepository)
    {
        _problemRepository = problemRepository;
    }

    public async Task<Problem> Handle(GetProblemByIdQuery query, CancellationToken cancellationToken)
    {
        return await _problemRepository.GetById(query.Id);
    }
}