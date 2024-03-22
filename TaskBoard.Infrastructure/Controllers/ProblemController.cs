using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Interfaces.Service;
using TaskBoard.Application.Problems.Commands;
using TaskBoard.Contracts;

namespace TaskBoard.Infrastructure.Controllers;

public class ProblemController : Controller
{
    private readonly IProblemService _problemService;

    public ProblemController(IProblemService problemService)
    {
        _problemService = problemService;
    }

    [HttpGet]
    public async Task<ActionResult<ProblemResponse>> Get(string title)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);

        var problem = await _problemService.GetByTitle(title);

        var response = new ProblemResponse(problem.Id, problem.Title, problem.Description, problem.Comment);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<ProblemResponse>> Get(Guid guid)
    {
        var problem = await _problemService.GetById(guid);

        var response = new ProblemResponse(problem.Id, problem.Title, problem.Description, problem.Comment);

        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody]ProblemRequest problemRequest)
    {
        var problem = new CreateProblemCommand
        {
            Title = problemRequest.Title,
            Description = problemRequest.Description,
            Comment = problemRequest.Comment,
        };

        var problemId = await _problemService.Create(problem);
        return Ok(new { Id = problemId });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> Update(Guid id, ProblemRequest problemRequest)
    {
        var problemId = await _problemService.Update(id, 
            problemRequest.Title, 
            problemRequest.Description, 
            problemRequest.Comment, 
            problemRequest.Status);

        return Ok(problemId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _problemService.Delete(id);
        
        return NoContent();
    }
}