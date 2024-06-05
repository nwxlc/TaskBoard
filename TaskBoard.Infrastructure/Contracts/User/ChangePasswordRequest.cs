namespace TaskBoard.Infrastructure.Contracts.User;

public record ChangePasswordRequest(
    string Email,
    string Password,
    string Token);