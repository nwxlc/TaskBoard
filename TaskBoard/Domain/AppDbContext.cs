using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Domain;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }
    
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<SprintEntity> Sprints { get; set; }
    public DbSet<ProblemEntity> Problems { get; set; }
    public DbSet<FileEntity> Files { get; set; }
}