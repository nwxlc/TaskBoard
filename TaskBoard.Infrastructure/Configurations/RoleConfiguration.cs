using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.HasMany(r => r.Permissions)
            .WithMany()
            .UsingEntity<RolePermission>(
                l => l.HasOne<Permission>().WithMany().HasForeignKey(e => e.PermissionId),
                r => r.HasOne<Role>().WithMany().HasForeignKey(e => e.RoleId));


        builder
            .Navigation(r => r.Permissions)
            .AutoInclude();
    }
}