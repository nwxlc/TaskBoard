using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Domain.Models;

namespace TaskBoard.Infrastructure.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(a => a.Id);

        builder
            .HasMany(a => a.Sprints)
            .WithOne(a => a.Project)
            .HasForeignKey(a => a.ProjectId);
    }
}