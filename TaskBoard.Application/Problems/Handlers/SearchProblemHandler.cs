using Microsoft.EntityFrameworkCore;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Problems.Handlers;

public class SearchProblemHandler
{
    private readonly IProblemRepository _problemRepository;

    public SearchProblemHandler(IProblemRepository problemRepository)
    {
        _problemRepository = problemRepository;
    }

    public async Task<Problem[]> SearchByTitle(string title, int page, int pageSize)
    {
        return await _problemRepository.SearchByTitle(title, page, pageSize);
    }
}