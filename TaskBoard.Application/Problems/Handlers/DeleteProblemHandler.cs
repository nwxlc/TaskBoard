using TaskBoard.Application.Interfaces.Repositories;

namespace TaskBoard.Application.Problems.Handlers;

public class DeleteProblemHandler
{
    private readonly IProblemRepository _problemRepository;

    public DeleteProblemHandler(IProblemRepository problemRepository)
    {
        _problemRepository = problemRepository;
    }
    
    public async Task Delete(Guid id)
    {
        await _problemRepository.Delete(id);
    }
}