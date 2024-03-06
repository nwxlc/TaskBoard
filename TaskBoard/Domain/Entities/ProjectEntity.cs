using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Domain.Entities;

public class ProjectEntity
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Decription { get; set; }

    public List<SprintEntity> Sprints { get; set; }
}