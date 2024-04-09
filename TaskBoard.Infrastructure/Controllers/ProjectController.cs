using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Projects.Commands;
using TaskBoard.Application.Projects.Queries;
using TaskBoard.Infrastructure.Contracts.Project;

namespace TaskBoard.Infrastructure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : Controller
{
     private readonly IMediator _mediator;

     public ProjectController(IMediator mediator)
     {
         _mediator = mediator;
     }

     [HttpGet("Search")]
     public async Task<ActionResult<ProjectResponse[]>> Search(string title, int page, int pageSize)
     {
         ArgumentException.ThrowIfNullOrEmpty(title);

         var searchProject = new SearchProjectByTitleQuery()
         {
             Title = title,
             Page = page, 
             PageSize = pageSize
         };

         var projects = await _mediator.Send(searchProject);

         var response = projects
             .Select(project => new ProjectResponse(project.Id, project.Title, project.Description))
             .ToArray();

         return Ok(response);
     }
     
     [HttpGet("Get/{id}")]
     public async Task<ActionResult<ProjectResponse>> Get(Guid id)
     {
         var query = new GetProjectByIdQuery
         {
             Id = id
         };
         
         var project = await _mediator.Send(query);
     
         var response = new ProjectResponse(project.Id, project.Title, project.Description);
     
         return Ok(response);
     }
     
     [HttpPost("Create")]
     public async Task<ActionResult<Guid>> Create([FromBody]ProjectRequest projectRequest)
     {
         var project = new CreateProjectCommand()
         {
             Title = projectRequest.Title,
             Description = projectRequest.Description
         };

         var projectId = await _mediator.Send(project);
         return Ok(new { Id = projectId });
     }

     [HttpPut("Update/{id:guid}")]
     public async Task<ActionResult<Guid>> Update(Guid id, [FromBody]ProjectRequest projectRequest)
     {
         var updateProject = new UpdateProjectCommand()
         {
             Id = id,
             Title = projectRequest.Title,
             Description = projectRequest.Description,
         };
         
         var projectId = await _mediator.Send(updateProject);

         return Ok(projectId);
     }

     [HttpDelete("Delete/{id:guid}")]
     public async Task<IActionResult> Delete(Guid id)
     {
         var deleteProject = new DeleteProjectCommand()
         {
             Id = id
         };
         
         await _mediator.Send(deleteProject.Id);
         
         return NoContent();
     }   
}