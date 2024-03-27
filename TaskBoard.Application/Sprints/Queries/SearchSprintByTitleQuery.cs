using MediatR;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Sprints.Queries;

public class SearchSprintByTitleQuery : IRequest<Sprint[]>
{
    public string Title { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}