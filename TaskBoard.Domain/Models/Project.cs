using System.Security.Cryptography;

namespace TaskBoard.Domain.Models;

public class Project
{
    public Project(Guid id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }

    public Guid Id { get; set; }

    public string Title { get; set; }
    
    public string Description { get; set; }

    public List<Sprint> Sprints { get; set; }
}