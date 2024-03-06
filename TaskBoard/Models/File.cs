namespace TaskBoard.Models;

public class File
{
    public Guid Id { get; set; }
    
    public string Url { get; set; }
    
    public List<Sprint> Sprints { get; set; }
    
    public List<Problem> Tasks { get; set; }
}