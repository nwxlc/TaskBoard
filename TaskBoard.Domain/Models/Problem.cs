using System.Diagnostics.CodeAnalysis;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Domain.Models;

public class Problem
{
    private Problem(Guid id, Guid sprintId, string title, string description, string comment, bool isComplete)
    {
        Id = id;
        SprintId = sprintId;
        SetTitle(title);
        SetDescription(description);
        SetComment(comment);
        IsComplete = isComplete;
    }

    public Guid Id { get; set; }
    
    public Guid SprintId { get; set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Comment { get; private set; }

    public bool IsComplete { get; set; }
    
    public List<User> ProblemUsers { get; set; }

    public List<File> Files { get; set; }
    
    public static Problem Create(string title, string description, string comment, Guid sprintId)
    {
        var problem = new Problem(Guid.NewGuid(), sprintId, title, description, comment, false);

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
    
    public void AddUser(User user)
    {
        if (ProblemUsers.Contains(user))
        {
            throw new Exception("User has already been added to sprint");
        }
        
        if (user == null)
        {
            throw new Exception("Error");
        }
        ProblemUsers.Add(user);
    }
    
    public void AddFile(File file)
    {
        if (Files.Contains(file))
        {
            throw new Exception("File has already been added to problem");
        }
        
        if (file == null)
        {
            throw new Exception("Error");
        }
        Files.Add(file);
    }
}