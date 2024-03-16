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

    public async Task Create(Problem model)
    {
            var problem = new Problem
            {
                Id = model.Id,
                Title = model.Title,
                Decription = model.Decription,
                Comment = model.Comment,
                Status = model.Status
            };

            await _problemRepository.Create(problem);
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
        problemToUpdateEntity.Decription = description;
        problemToUpdateEntity.Comment = comment;
        problemToUpdateEntity.Status = status;
        
        return await _problemRepository.Update(problemToUpdateEntity);
    }

    public async Task Delete(Guid id)
    {
        await _problemRepository.Delete(id);
    }
}