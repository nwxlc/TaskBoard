using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Domain.Entities;

public class ProblemEntity
{
    public Guid Id { get; set; }
    
    public SprintEntity? Sprint { get; set; }
    
    public Guid SprintId { get; set; }
    
    public string Title { get; set; }

    public string Decription { get; set; }
    
    public string Comment { get; set; }
    
    public bool Status { get; set; }
    
    public List<FileEntity> Files { get; set; }
}