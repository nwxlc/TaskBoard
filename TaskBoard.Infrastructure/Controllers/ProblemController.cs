using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Commands;
using TaskBoard.Application.Interfaces.Service;
using TaskBoard.Contracts;

namespace TaskBoard.Infrastructure.Controllers;

public class ProblemController : Controller
{
    private readonly IProblemService _problemService;

    public ProblemController(IProblemService problemService)
    {
        _problemService = problemService;
    }

    [HttpPost]
    public async Task<IActionResult>Create([FromBody]ProblemRequest problemRequest)
    {
        var problem = new ProblemCommand
        {
            Id = Guid.NewGuid(),
            Title = problemRequest.Title,
            Description = problemRequest.Decription,
            Comment = problemRequest.Comment,
            Status = false
        };

        await _problemService.Create(problem);
        return Ok("");
    }
}