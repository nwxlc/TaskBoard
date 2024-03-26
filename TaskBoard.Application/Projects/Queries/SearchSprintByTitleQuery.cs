namespace TaskBoard.Application.Projects.Queries;

public class SearchSprintByTitleQuery
{
    public string Title { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}