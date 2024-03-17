namespace TaskBoard.Contracts;

public record ProblemResponse(
    Guid Id,
    string Title,
    string Description,
    string Comment);