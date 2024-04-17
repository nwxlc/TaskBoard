using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaskBoard.Domain.Models;
using TaskBoard.Domain.Models.Users;
using TaskBoard.Infrastructure.Authentication;
using TaskBoard.Infrastructure.Configurations;

namespace TaskBoard.Infrastructure;

public class AppDbContext : DbContext
{
    private readonly IOptions<AuthorizationOptions> _authorization;
    
    public AppDbContext(DbContextOptions<AppDbContext> options, 
        IOptions<AuthorizationOptions> authorizationOptions)
        : base(options)
    {
        _authorization = authorizationOptions;
    }
    
    public DbSet<Project> Projects { get; set; }
    public DbSet<Sprint> Sprints { get; set; }
    public DbSet<Problem> Problems { get; set; }
    //public DbSet<File> Files { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(_authorization.Value));
    }
}