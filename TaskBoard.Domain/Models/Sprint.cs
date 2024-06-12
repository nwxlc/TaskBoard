using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Domain.Models;

public class Sprint
{
    private Sprint(Guid id, DateTime startDate, string title, string description, string comment, Guid projectId)
    {
        Id = id;
        StartDate = startDate;
        SetTitle(title);
        SetDescription(description);
        SetComment(comment);
        ProjectId = projectId;
    }

    public Guid Id { get; set; }

    public Project Project { get; set; }
    
    public Guid ProjectId { get; set; } 
    
    public DateTime StartDate { get; set; } 
    
    public DateTime EndDate { get; set; }
    
    public string Title { get; private  set; } 

    public string Description { get; private set; } 
    
    public string Comment { get; private set; }
    
    public List<Problem> Problems { get; set; }

    public List<User> SprintUsers { get; set; }
    
    public List<File> Files { get; set; }
    
    public static Sprint Create(string title, string description, string comment, Guid projectId)
    {
        var sprint = new Sprint(Guid.NewGuid(), DateTime.Now, title, description, comment, projectId);

        return sprint;
    }
    
    public void SetTitle(string title)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        Title = title;
    }

    public void SetEndDate()
    {
        EndDate = DateTime.Now;
    }

    public void SetDescription(string description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        Description = description;
    }

    public void SetComment(string comment)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(comment);
        Comment = comment;
    }
    
    public void AddUser(User user)
    {
        if (SprintUsers.Contains(user))
        {
            throw new Exception("User has already been added to sprint");
        }
        
        if (user == null)
        {
            throw new Exception("Error");
        }
        SprintUsers.Add(user);
    }

    public void AddFile(File file)
    {
        if (Files.Contains(file))
        {
            throw new Exception("File has already been added to sprint");
        }
        
        if (file == null)
        {
            throw new Exception("Error");
        }
        Files.Add(file);
    }
}