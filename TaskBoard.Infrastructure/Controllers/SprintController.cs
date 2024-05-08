using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Sprints.Commands;
using TaskBoard.Application.Sprints.Queries;
using TaskBoard.Infrastructure.Contracts.Sprint;

namespace TaskBoard.Infrastructure.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "SprintAccess")]
public class SprintController : Controller
{
    private readonly IMediator _mediator;

    public SprintController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("Search")]
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
             .Select(sprint => new SprintResponse(sprint.Id, sprint.Title, sprint.Description, sprint.Comment, sprint.StartDate))
             .ToArray();

         return Ok(response);
     }

      [HttpGet("Get/{id:guid}")]
     public async Task<ActionResult<SprintResponse>> Get(Guid guid)
     {
         var query = new GetSprintByIdQuery()
         {
             Id = guid
         };
         
         var sprint = await _mediator.Send(query);

         var response = new SprintResponse(sprint.Id, sprint.Title, sprint.Description, sprint.Comment, sprint.StartDate);

         return Ok(response);
     }
     
     [HttpPost("Create")]
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
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteSprintCommand = new DeleteSprintCommand()
        {
            Id = id
        };
        
        await _mediator.Send(deleteSprintCommand.Id);
        
        return NoContent();
    }   
}