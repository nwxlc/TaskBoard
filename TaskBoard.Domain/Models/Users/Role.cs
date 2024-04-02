using Microsoft.AspNetCore.Identity;

namespace TaskBoard.Domain.Models.Users;

public class Role : IdentityRole
{
    public ICollection<User> Users { get; set; }
    
    public ICollection<Permission> Permissions { get; set; }
}