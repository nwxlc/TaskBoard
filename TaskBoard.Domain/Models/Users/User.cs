using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TaskBoard.Domain.Models.Users;

public class User 
{
    private User(Guid id,string userName, string email, string passwordHash)
    {
        Id = id;
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
    }

    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; }
    
    public bool IsBlocked { get; set; }

    public Guid? ResetPasswordToken { get; set; } 
    
    public ICollection<Role> Roles { get; set; } = new List<Role>();

    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    
    public static User Create(string userName, string email, string password)
    {
        var passwordHash = Generate(password);

        var user = new User(Guid.NewGuid(), userName, email, passwordHash);

        return user;
    }

    public void Block()
    {
        IsBlocked = true;
    }

    public static string Generate(string password) =>
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string password, string hashedPassword) =>
        BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    
    public void AddRole(Role role)
    {
        if (role == null)
        {
            throw new Exception("Error");
        }
        Roles.Add(role);
    }
    
    public void AddPermission(Permission permission)
    {
        if (permission == null)
        {
            throw new Exception("Error");
        }
        Permissions.Add(permission);
    }
}