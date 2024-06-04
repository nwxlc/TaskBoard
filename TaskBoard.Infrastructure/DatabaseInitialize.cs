using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Enums;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Infrastructure;

public static class DatabaseInitialize
{
    public static void Initialize(ModelBuilder modelBuilder)
    {
        Role[] roles =
        [
            new()
            {
                Id = Guid.Parse("DDFE6BCB-67E6-47A6-83D0-4B792D4B8B12"),
                Name = RoleEnum.User.ToString()
            },
            new()
            {
                Id = Guid.Parse("2A282C2D-2EF6-4FCB-AB1F-0145EFDC2B18"),
                Name = RoleEnum.Manager.ToString()
            },
            new Role()
            {
                Id = Guid.Parse("993162DF-8F06-473E-8D78-A4B65234E349"),
                Name = RoleEnum.Admin.ToString()
            }
        ];

        modelBuilder.Entity<Role>().HasData(roles);

        Permission[] permissions =
        [
            new()
            {
                Id = Guid.Parse("8FDBAE05-E08C-42D9-878A-6A27231CA40B"),
                Name = PermissionEnum.ReadProject.ToString()
            },
            new()
            {
                Id = Guid.Parse("F219A2C2-2778-4267-AC45-FABDC4B8CEED"),
                Name = PermissionEnum.CreateProject.ToString()
            },
            new()
            {
                Id = Guid.Parse("C35ECCFC-95F0-48B0-B14A-5A2F15F9EA99"),
                Name = PermissionEnum.AddUserToProject.ToString()
            },
            new()
            {
                Id = Guid.Parse("5DFBAFA1-7997-4B28-BC09-94238B5879FA"),
                Name = PermissionEnum.ReadSprint.ToString()
            },
            new()
            {
                Id = Guid.Parse("6FB65AE9-9570-48D0-88DA-1AE56FA2C13A"),
                Name = PermissionEnum.CreateSprint.ToString()
            },
            new()
            {
                Id = Guid.Parse("561FA1B1-5379-416B-8F7A-D4023621C56C"),
                Name = PermissionEnum.AddUserToSprint.ToString()
            },
            new()
            {
                Id = Guid.Parse("72493E93-F2D5-4226-A855-619ECF918B8A"),
                Name = PermissionEnum.ReadProblem.ToString()
            },
            new()
            {
                Id = Guid.Parse("52227FC7-C9EB-4CDB-9453-9262A6E38267"),
                Name = PermissionEnum.CreateProblem.ToString()
            },
            new()
            {
                Id = Guid.Parse("A56EC29F-7AE5-4D25-9178-86FA53075D6E"),
                Name = PermissionEnum.AddUserToProblem.ToString()
            },
            new()
            {
                Id = Guid.Parse("3240C4C5-E0A8-4A40-80DF-52BC8F082111"),
                Name = PermissionEnum.BlockUser.ToString()
            }
        ];

        modelBuilder.Entity<Permission>().HasData(permissions);

        RolePermission[] rolePermissions =
        [
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.Admin.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.BlockUser.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.Admin.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.ReadProject.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.Admin.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.CreateProject.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.Admin.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.CreateSprint.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.Admin.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.ReadSprint.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.Admin.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.AddUserToSprint.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.Admin.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.ReadProblem.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.Admin.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.CreateProblem.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.Admin.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.AddUserToProblem.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.Admin.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.AddUserToProject.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.Manager.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.ReadSprint.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.Manager.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.ReadProblem.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.Manager.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.ReadProject.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.Manager.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.AddUserToProject.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.User.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.AddUserToProject.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.User.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.AddUserToProject.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.User.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.AddUserToProject.ToString()).Id
            },
            new()
            {
                RoleId = roles.Single(r => r.Name == RoleEnum.User.ToString()).Id,
                PermissionId = permissions.Single(p => p.Name == PermissionEnum.AddUserToProject.ToString()).Id
            }
        ];
    }

}