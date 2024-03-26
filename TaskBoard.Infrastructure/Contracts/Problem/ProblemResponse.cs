namespace TaskBoard.Infrastructure.Contracts.Problem;

public record ProblemResponse(
    Guid Id,
    string Title,
    string Description,
    string Comment);