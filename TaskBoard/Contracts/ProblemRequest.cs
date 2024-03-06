namespace TaskBoard.Contracts;

public record ProblemRequest(
    string Title,
    string Decription,
    string Comment);