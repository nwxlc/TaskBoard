using TaskBoard.Application.Commands.Problem;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Interfaces.Service;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Service;

public class ProblemService : IProblemService
{
    private readonly IProblemRepository _problemRepository;

    public ProblemService(IProblemRepository problemRepository)
    {
        _problemRepository = problemRepository;
    }

    public async Task<Guid> Create(CreateProblemCommand createProblemCommand)
    {
        ArgumentNullException.ThrowIfNull(createProblemCommand);
        
        var problem = new Problem(
            createProblemCommand.Id, 
            createProblemCommand.Title, 
            createProblemCommand.Description, 
            createProblemCommand.Comment, 
            createProblemCommand.Status 
        );

        await _problemRepository.Create(problem);
        return problem.Id;
    }
    
    public async Task<Problem> GetById(Guid id)
    {
        return await _problemRepository.GetById(id);
    }

    public async Task<Problem> GetByTitle(string title)
    {
        return await _problemRepository.GetByTitle(title);
    }
    
    public async Task<Guid> Update(Guid id, string title, string description, string comment, bool status)
    {
        var problemToUpdateEntity = await _problemRepository.GetById(id);

        problemToUpdateEntity.Title = title;
        problemToUpdateEntity.Description = description;
        problemToUpdateEntity.Comment = comment;
        problemToUpdateEntity.Status = status;
        
        return await _problemRepository.Update(problemToUpdateEntity);
    }

    public async Task Delete(Guid id)
    {
        await _problemRepository.Delete(id);
    }
}