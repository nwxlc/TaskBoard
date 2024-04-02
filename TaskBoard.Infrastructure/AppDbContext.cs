using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Models;
using TaskBoard.Domain.Models.Users;

namespace TaskBoard.Infrastructure;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }
    
    public DbSet<Project> Projects { get; set; }
    public DbSet<Sprint> Sprints { get; set; }
    public DbSet<Problem> Problems { get; set; }
    //public DbSet<File> Files { get; set; }
    public DbSet<User> Users { get; set; }
    
}