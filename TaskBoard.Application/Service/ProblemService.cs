using TaskBoard.Application.Commands;
using TaskBoard.Application.Interfaces.Service;
using TaskBoard.Domain.Interfaces;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Service;

public class ProblemService : IProblemService
{
    private readonly IProblemRepository _problemRepository;

    public ProblemService(IProblemRepository problemRepository)
    {
        _problemRepository = problemRepository;
    }

    public async Task<Guid> Create(ProblemCommand problemCommand)
    {
        ArgumentNullException.ThrowIfNull(problemCommand);
        
        var problem = new Problem (
            problemCommand.Id, 
            problemCommand.Title, 
            problemCommand.Description, 
            problemCommand.Comment, 
            problemCommand.Status 
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
    
    public async Task<Problem> Update(Guid id, string title, string description, string comment, bool status)
    {
        var problemToUpdateEntity = await _problemRepository.GetById(id) 
                                    ?? throw new Exception();

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