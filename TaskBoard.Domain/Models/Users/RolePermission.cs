namespace TaskBoard.Domain.Models.Users;

public class RolePermission
{
    public Guid RoleId { get; set; }

    public Guid PermissionId { get; set; }
}