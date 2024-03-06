namespace TaskBoard.Models;

public class Sprint
{
    public Guid Id { get; set; }
    
    public Project? Project { get; set; }
    
    public Guid ProjectId { get; set; } 
    
    public DateTime StartDate { get; set; } 
    
    public DateTime EndDate { get; set; }
    
    public string Title { get; set; } 

    public string Description { get; set; } 
    
    public string Comment { get; set; }
    
    public List<Problem> Tasks { get; set; }
    
    public List<File> Files { get; set; }
}