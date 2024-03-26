namespace TaskBoard.Application.Sprints.Queries;

public class SeachSprintByTitleQuery
{
    public string Title { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}