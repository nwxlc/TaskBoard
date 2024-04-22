namespace TaskBoard.Infrastructure.Contracts.User;

public record AuthenticateResponse(
    Guid Id,
    string Token);