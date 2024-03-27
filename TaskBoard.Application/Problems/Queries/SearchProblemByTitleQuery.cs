using MediatR;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Problems.Queries;

public class SearchProblemByTitleQuery : IRequest<Problem[]>
{
    public string Title { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}