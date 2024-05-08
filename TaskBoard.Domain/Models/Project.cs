using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Domain.Models;

public class Project
{
    private Project(Guid id, string title, string description)
    {
        Id = id;
        SetTitle(title);
        SetDescription(description);
    }

    public Guid Id { get; set; }

    public string Title { get; private set; }
    
    public string Description { get; private set; }

    public List<Sprint> Sprints { get; set; }
    
    public List<User> ProjectUsers { get; set; }

    public static Project Create(string title, string description)
    {
        var project = new Project(Guid.NewGuid(), title, description);

        return project;
    }
    
    public void SetTitle(string title)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        Title = title;
    }
    
    public void SetDescription(string description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        Description = description;
    }

    public void AddUser(User user)
    {
        if (user == null)
        {
            throw new Exception("Error");
        }
        ProjectUsers.Add(user);
    }
}