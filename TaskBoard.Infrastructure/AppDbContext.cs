using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Models;
using TaskBoard.Domain.Models.Users;
using File = TaskBoard.Domain.Models.File;

namespace TaskBoard.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    public DbSet<Project> Projects { get; set; }
    
    public DbSet<Sprint> Sprints { get; set; }

    public DbSet<Problem> Problems { get; set; }
    
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Permission> Permissions { get; set; }

    public DbSet<File> Files  { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
        DatabaseInitialize.Initialize(modelBuilder);
    }

}