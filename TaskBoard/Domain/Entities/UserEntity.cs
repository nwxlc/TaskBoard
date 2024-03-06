using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace TaskBoard.Domain.Entities;

public class UserEntity : IdentityUser
{
    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserEntity> manager)
    {
        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        return userIdentity;
    }
}