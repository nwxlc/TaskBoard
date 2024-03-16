using Microsoft.AspNetCore.Mvc;
using TaskBoard.Contracts;
using TaskBoard.Models;
using TaskBoard.Service.Interfaces;

namespace TaskBoard.Controllers;

public class ProblemController
{
    private readonly IProblemService _problemService;

    public ProblemController(IProblemService problemService)
    {
        _problemService = problemService;
    }

    [HttpPost]
    public async Task Create([FromBody] ProblemRequest problemRequest)
    {
        var problem = new Problem
        {
            Id = Guid.NewGuid(),
            Title = problemRequest.Title,
            Decription = problemRequest.Decription,
            Comment = problemRequest.Comment,
            Status = false
        };

        await _problemService.Create(problem);
    }
}