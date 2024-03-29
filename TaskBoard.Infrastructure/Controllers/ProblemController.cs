using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Problems.Commands;
using TaskBoard.Application.Problems.Queries;
using TaskBoard.Contracts;
using TaskBoard.Infrastructure.Contracts.Problem;

namespace TaskBoard.Infrastructure.Controllers;

public class ProblemController : Controller
{
    private readonly IMediator _mediator;

    public ProblemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ProblemResponse[]>> Search(string title, int page, int pageSize)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);

        var searchProblem = new SearchProblemByTitleQuery()
        {
            Title = title,
            Page = page, 
            PageSize = pageSize
        };

        var problems = await _mediator.Send(searchProblem);

        var response = problems
            .Select(problem => new ProblemResponse(problem.Id, problem.Title, problem.Description, problem.Comment))
            .ToArray();

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<ProblemResponse>> Get(Guid guid)
    {
        var query = new GetProblemByIdQuery
        {
            Id = guid
        };
        
        var problem = await _mediator.Send(query);

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

        var problemId = await _mediator.Send(problem);
        return Ok(new { Id = problemId });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> Update(Guid id, ProblemRequest problemRequest)
    {
        var updateProblem = new UpdateProblemCommand
        {
            Id = id,
            Title = problemRequest.Title,
            Description = problemRequest.Description,
            Comment = problemRequest.Comment
        };
        
        var problemId = await _mediator.Send(updateProblem);

        return Ok(problemId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteProblem = new DeleteProblemCommand
        {
            Id = id
        };
        
        await _mediator.Send(deleteProblem.Id);
        
        return NoContent();
    }
}