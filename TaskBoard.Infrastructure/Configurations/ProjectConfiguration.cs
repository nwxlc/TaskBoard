using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Domain.Models;

namespace TaskBoard.Infrastructure.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(project => project.Id);

        builder
            .HasMany(project => project.Sprints)
            .WithOne(sprint => sprint.Project)
            .HasForeignKey(sprint => sprint.ProjectId);
    }
}