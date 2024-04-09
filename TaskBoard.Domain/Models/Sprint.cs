namespace TaskBoard.Domain.Models;

public class Sprint
{
    private Sprint(Guid id, DateTime startDate, string title, string description, string comment)
    {
        Id = id;
        StartDate = startDate;
        SetTitle(title);
        SetDescription(description);
        SetComment(comment);
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
    
    //public List<File> Files { get; set; }
    
    public static Sprint Create(string title, string description, string comment)
    {
        var sprint = new Sprint(Guid.NewGuid(), DateTime.Now, title, description, comment);

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
}