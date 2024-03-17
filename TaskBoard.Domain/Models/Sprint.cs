namespace TaskBoard.Domain.Models;

public class Sprint
{
    public Sprint(Guid id, DateTime startDate, string title, string description, string comment)
    {
        Id = id;
        StartDate = startDate;
        Title = title;
        Description = description;
        Comment = comment;
    }

    public Guid Id { get; set; }
    
    public Project Project { get; set; }
    
    public Guid ProjectId { get; set; } 
    
    public DateTime StartDate { get; set; } 
    
    public DateTime EndDate { get; set; }
    
    public string Title { get; set; } 

    public string Description { get; set; } 
    
    public string Comment { get; set; }
    
    public List<Problem> Problems { get; set; }
    
    //public List<File> Files { get; set; }
}