using MediatR;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Projects.Queries;

public class SearchProjectByTitleQuery : IRequest<Project[]>
{
    public string Title { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}