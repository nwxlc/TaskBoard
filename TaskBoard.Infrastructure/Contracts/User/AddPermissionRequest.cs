namespace TaskBoard.Infrastructure.Contracts.User;

public record AddPermissionRequest(
    Guid PermissionId,
    Guid UserId);