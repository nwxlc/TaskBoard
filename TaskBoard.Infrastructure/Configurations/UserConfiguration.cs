using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Domain.Models;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity<UserRole>(
                l => l.HasOne<Role>().WithMany().HasForeignKey(r => r.RoleId),
                r => r.HasOne<User>().WithMany().HasForeignKey(u => u.UserId));

        builder
            .Navigation(p => p.Roles)
            .AutoInclude();
    }
}