namespace TaskBoard.Domain.Models.Users;

public class UserPermission
{
    public Guid UserId { get; set; }
    
    public Guid PermissionId { get; set; }
}