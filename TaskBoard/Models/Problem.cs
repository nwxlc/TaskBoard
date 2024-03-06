namespace TaskBoard.Models;

public class Problem
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }

    public string Decription { get; set; }
    
    public string Comment { get; set; }
    
    public bool Status { get; set; }
    
}