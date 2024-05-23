namespace TaskBoard.Infrastructure.Contracts.User;

public record AddRoleRequest(
    Guid RoleId,
    Guid UserId);