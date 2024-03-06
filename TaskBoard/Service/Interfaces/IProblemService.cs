using TaskBoard.Domain.Entities;
using TaskBoard.Models;

namespace TaskBoard.Service.Interfaces;

public interface IProblemService
{
    Task Create(Problem model);
    Task<ProblemEntity> GetById(Guid id);
    Task<ProblemEntity> GetByTitle(string title); 
    Task<ProblemEntity> Update(Guid id, string title, string description, string comment, bool status);
    Task Delete(Guid id);
}