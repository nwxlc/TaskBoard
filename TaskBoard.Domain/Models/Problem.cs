namespace TaskBoard.Domain.Models;

public class Problem
{
    public Problem(Guid id, string title, string description, string comment, bool status)
    {
        Id = id;
        Title = title;
        Description = description;
        Comment = comment;
        Status = status;
    }

    public Guid Id { get; set; }
    
    public Sprint? Sprint { get; set; }
    
    public Guid SprintId { get; set; }
    
    public string Title { get; set; }

    public string Description { get; set; }
    
    public string Comment { get; set; }
    
    public bool Status { get; set; }
    
    //public List<File> Files { get; set; }
}