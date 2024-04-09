using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Domain.Models;

namespace TaskBoard.Infrastructure.Configurations;

public class SprintConfiguration : IEntityTypeConfiguration<Sprint>
{
    public void Configure(EntityTypeBuilder<Sprint> builder)
    {
        builder.HasKey(a => a.Id);

        builder
            .HasOne(sprint => sprint.Project)
            .WithMany(project => project.Sprints);

        builder
            .HasMany(sprint => sprint.Problems)
            .WithOne(problem => problem.Sprint)
            .HasForeignKey(problem => problem.SprintId);
    }
}