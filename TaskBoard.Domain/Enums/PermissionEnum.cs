namespace TaskBoard.Domain.Enums;

public enum PermissionEnum
{
    ReadProject = 1,
    CreateProject = 2,
    AddUserToProject = 3,
    ReadSprint = 4,
    CreateSprint = 5, 
    AddUserToSprint = 6,
    ReadProblem = 7,
    CreateProblem = 8,
    AddUserToProblem = 9,
    
    BlockUser = 10
}