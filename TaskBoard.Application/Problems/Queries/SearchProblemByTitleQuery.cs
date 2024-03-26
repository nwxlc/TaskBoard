namespace TaskBoard.Application.Problems.Queries;

public class SearchProblemByTitleQuery
{
    public string Title { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}