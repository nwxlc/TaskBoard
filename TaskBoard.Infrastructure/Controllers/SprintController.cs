using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Sprints.Commands;
using TaskBoard.Application.Sprints.Queries;
using TaskBoard.Infrastructure.Contracts.Sprint;

namespace TaskBoard.Infrastructure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SprintController : Controller
{
    private readonly IMediator _mediator;

    public SprintController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("Search")]
    [Authorize(Roles = "ReadSprint")]
    public async Task<ActionResult<SprintResponse[]>> Search(string title, int page, int pageSize)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);

        var searchSprint = new SearchSprintByTitleQuery()
        {
            Title = title,
            Page = page,
            PageSize = pageSize
        };

        var sprints = await _mediator.Send(searchSprint);

        var response = sprints
            .Select(sprint =>
                new SprintResponse(sprint.Id, sprint.Title, sprint.Description, sprint.Comment, sprint.StartDate))
            .ToArray();

        return Ok(response);
    }

    [HttpGet("Get/{id:guid}")]
    [Authorize(Roles = "ReadSprint")]
    public async Task<ActionResult<SprintResponse>> Get(Guid guid)
    {
        var query = new GetSprintByIdQuery()
        {
            Id = guid
        };

        var sprint = await _mediator.Send(query);

        var response =
            new SprintResponse(sprint.Id, sprint.Title, sprint.Description, sprint.Comment, sprint.StartDate);

        return Ok(response);
    }

    [HttpPost("Create")]
    [Authorize(Roles = "CreateSprint")]
    public async Task<ActionResult<Guid>> Create([FromBody]SprintRequest sprintRequest)
    {
        var sprint = new CreateSprintCommand()
        {
            Title = sprintRequest.Title,
            Description = sprintRequest.Description,
            Comment = sprintRequest.Comment,
            ProjectId = sprintRequest.ProjectId
        };

        var sprintId = await _mediator.Send(sprint);
        return Ok(new { Id = sprintId });
    }

    [HttpPut("Update/{id:guid}")]
    [Authorize(Roles = "CreateSprint")]
    public async Task<ActionResult<Guid>> Update(Guid id, [FromBody]SprintRequest sprintRequest)
    {
        var updateSprint = new UpdateSprintCommand()
        {
            Id = id,
            Title = sprintRequest.Title,
            Description = sprintRequest.Description,
            Comment = sprintRequest.Comment
        };

        var sprintId = await _mediator.Send(updateSprint);

        return Ok(sprintId);
    }

    [HttpDelete("Delete/{id:guid}")]
    [Authorize(Roles = "CreateSprint")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteSprintCommand = new DeleteSprintCommand()
        {
            Id = id
        };

        await _mediator.Send(deleteSprintCommand.Id);

        return NoContent();
    }

    [Authorize(Roles = "AddUserToSprint")]
    public async Task<IActionResult> AddUser(Guid id, string email)
    {
        var addUser = new AddUserToSprintCommand()
        {
            SprintId = id,
            UserEmail = email
        };

        await _mediator.Send(addUser);

        return Ok();
    }

    [Authorize]
    public async Task<IActionResult> ReadFile(Guid id)
    {
        var path = Path.Combine();

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        var url = $"~/StaticFiles/Sprints/id";

        return Redirect(url);
    }

    public async Task<IActionResult> AddFile(Guid fileId, Guid sprintId)
    {
        var command = new AddFileToSprintCommand()
        {
            FileId = fileId,
            SprintId = sprintId
        };

        await _mediator.Send(command);

        return Ok();
    }
}