using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Problems.Handlers;

public class GetByIdProblemHandler
{
    private readonly IProblemRepository _problemRepository;

    public GetByIdProblemHandler(IProblemRepository problemRepository)
    {
        _problemRepository = problemRepository;
    }

    public async Task<Problem> GetById(Guid id)
    {
        return await _problemRepository.GetById(id);
    }
}