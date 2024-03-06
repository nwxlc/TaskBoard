using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Domain.Entities;

public class FileEntity
{
    public Guid Id { get; set; }
    
    public string Url { get; set; }
    
    public List<SprintEntity> Sprints { get; set; }
    
    public List<ProblemEntity> Tasks { get; set; }
}