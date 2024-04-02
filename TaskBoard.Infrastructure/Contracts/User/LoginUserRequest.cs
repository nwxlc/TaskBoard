namespace TaskBoard.Infrastructure.Contracts.User;

public record LoginUserRequest(
    string Email,
    string Password);