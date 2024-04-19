using Microsoft.AspNetCore.Identity;
using TaskBoard.Domain.Enums;

namespace TaskBoard.Domain.Models.Users;

public class Role 
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public ICollection<User> Users { get; set; }

    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}