using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Problems.Commands;
using TaskBoard.Application.Problems.Handlers;
using TaskBoard.Contracts;
using TaskBoard.Infrastructure.Contracts.Problem;

namespace TaskBoard.Infrastructure.Controllers;

public class ProblemController : Controller
{
    private readonly CreateProblemHandler _createProblemHandler;
    private readonly DeleteProblemHandler _deleteProblemHandler;
    private readonly GetByIdProblemHandler _getByIdProblemHandler;
    private readonly SearchByTitleProblemHandler _searchByTitleProblemHandler;
    private readonly UpdateProblemHandler _updateProblemHandler;

    public ProblemController(CreateProblemHandler createProblemHandler, 
        DeleteProblemHandler deleteProblemHandler, 
        GetByIdProblemHandler getByIdProblemHandler, 
        SearchByTitleProblemHandler searchByTitleProblemHandler, 
        UpdateProblemHandler updateProblemHandler)
    {
        _createProblemHandler = createProblemHandler;
        _deleteProblemHandler = deleteProblemHandler;
        _getByIdProblemHandler = getByIdProblemHandler;
        _searchByTitleProblemHandler = searchByTitleProblemHandler;
        _updateProblemHandler = updateProblemHandler;
    }

    [HttpGet]
    public async Task<ActionResult<ProblemResponse[]>> Search(string title, int page, int pageSize)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);

        var problem = await _searchByTitleProblemHandler.SearchByTitle(title, page, pageSize);

        var response = new ProblemResponse(problem.Id, problem.Title, problem.Description, problem.Comment);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<ProblemResponse>> Get(Guid guid)
    {
        var problem = await _getByIdProblemHandler.GetById(guid);

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

        var problemId = await _createProblemHandler.Create(problem);
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
        
        var problemId = await _updateProblemHandler.Update(updateProblem);

        return Ok(problemId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteProblemHandler.Delete(id);
        
        return NoContent();
    }
}