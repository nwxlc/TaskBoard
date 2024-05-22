namespace TaskBoard.Infrastructure.Contracts.Sprint;

public record SprintResponse(
    Guid Id,
    string Title,
    string Description,
    string Comment,
    DateTime StartDate);