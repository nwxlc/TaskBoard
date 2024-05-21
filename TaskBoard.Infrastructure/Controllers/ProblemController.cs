using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Problems.Commands;
using TaskBoard.Application.Problems.Queries;
using TaskBoard.Application.Users.Commands;
using TaskBoard.Infrastructure.Contracts.Problem;

namespace TaskBoard.Infrastructure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProblemController : Controller
{
    private readonly IMediator _mediator;

    public ProblemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("Search")]
    [Authorize(Roles = "ReadProblem")]
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

    [HttpGet("Get/{id:guid}")]
    [Authorize(Roles = "ReadProblem")]
    public async Task<ActionResult<ProblemResponse>> Get(Guid id)
    {
        var query = new GetProblemByIdQuery
        {
            Id = id
        };
    
        var problem = await _mediator.Send(query);
    
        var response = new ProblemResponse(problem.Id, problem.Title, problem.Description, problem.Comment);
    
        return Ok(response);
    }
    
    [HttpPost("Create")]
    [Authorize(Roles = "CreateProblem")]
    public async Task<ActionResult<Guid>> Create([FromBody] ProblemRequest problemRequest)
    {
        var problem = new CreateProblemCommand
        {
            Title = problemRequest.Title,
            Description = problemRequest.Description,
            Comment = problemRequest.Comment,
            SprintId = problemRequest.SprintId
        };
    
        var problemId = await _mediator.Send(problem);
        return Ok(new { Id = problemId });
    }
    
    [HttpPut("Update/{id:guid}")]
    [Authorize(Roles = "CreateProblem")]
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
    
    [HttpDelete("Delete/{id:guid}")]
    [Authorize(Roles = "CreateProblem")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteProblem = new DeleteProblemCommand
        {
            Id = id
        };
    
        await _mediator.Send(deleteProblem.Id);
    
        return NoContent();
    }
    
    [Authorize(Roles = "AddUserToProblem")]
    public async Task<IActionResult> AddUser(Guid id, string email)
    {
        var addUser = new AddUserToProblemCommand()
        {
            ProblemId = id,
            UserEmail = email
        };

        await _mediator.Send(addUser);

        return Ok();
    }
}