using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Domain.Entities;

public class SprintEntity
{
    public Guid Id { get; set; }
    
    public ProjectEntity? Project { get; set; }
    
    public Guid ProjectId { get; set; } 
    
    public DateTime StartDate { get; set; } 
    
    public DateTime EndDate { get; set; }
    
    public string Title { get; set; } 

    public string Description { get; set; } 
    
    public string Comment { get; set; }
    
    public List<ProblemEntity> Tasks { get; set; }
    
    public List<FileEntity> Files { get; set; }
}