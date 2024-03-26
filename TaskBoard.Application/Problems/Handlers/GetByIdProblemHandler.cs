using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Problems.Queries;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Problems.Handlers;

public class GetByIdProblemHandler
{
    private readonly IProblemRepository _problemRepository;

    public GetByIdProblemHandler(IProblemRepository problemRepository)
    {
        _problemRepository = problemRepository;
    }

    public async Task<Problem> GetById(GetProblemByIdQuery query)
    {
        return await _problemRepository.GetById(query.Id);
    }
}