namespace TaskBoard.Domain.Models.Users;

public class Role 
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}