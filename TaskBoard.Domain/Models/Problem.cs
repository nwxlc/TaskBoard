using System.Diagnostics.CodeAnalysis;

namespace TaskBoard.Domain.Models;

public class Problem
{
    private Problem(Guid id, string title, string description, string comment, bool isComplete)
    {
        Id = id;
        SetTitle(title);
        SetDescription(description);
        SetComment(comment);
        IsComplete = isComplete;
    }

    public Guid Id { get; set; }

    public Sprint? Sprint { get; set; }
    
    public Guid SprintId { get; set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Comment { get; private set; }

    public bool IsComplete { get; set; }

    //public List<File> Files { get; set; }
    
    public static Problem Create(string title, string description, string comment)
    {
        var problem = new Problem(Guid.NewGuid(), title, description, comment, false);

        return problem;
    }

    [MemberNotNull(nameof(Title))]
    public void SetTitle(string title)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        Title = title;
    }

    public void SetComplete()
    {
        IsComplete = true;
    }

    [MemberNotNull(nameof(Description))]
    public void SetDescription(string description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        Description = description;
    }

    [MemberNotNull(nameof(Comment))]
    public void SetComment(string comment)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(comment);
        Comment = comment;
    }
}