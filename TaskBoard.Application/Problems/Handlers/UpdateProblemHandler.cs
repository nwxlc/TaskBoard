using TaskBoard.Application.Interfaces.Repositories;

namespace TaskBoard.Application.Problems.Handlers;

public class UpdateProblemHandler
{
    private readonly IProblemRepository _problemRepository;

    public UpdateProblemHandler(IProblemRepository problemRepository)
    {
        _problemRepository = problemRepository;
    }

    public async Task<Guid> Update(Guid id, string title, string description, string comment)
    {
        var problemToUpdateEntity = await _problemRepository.GetById(id);
        
        problemToUpdateEntity.SetTitle(title);
        problemToUpdateEntity.SetDescription(description);
        problemToUpdateEntity.SetComment(comment);
        
        return await _problemRepository.Update(problemToUpdateEntity);
    }
}