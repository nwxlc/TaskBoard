using Microsoft.EntityFrameworkCore;
using TaskBoard;
using TaskBoard.Application.Interfaces.Auth;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Infrastructure;
using TaskBoard.Infrastructure.Authentification;
using TaskBoard.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();

services.AddSwaggerGen();

services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

configuration.Bind("Project", new Config());
services.AddDbContext<AppDbContext>(options => options.UseNpgsql(Config.ConnectionString));

services.AddScoped<IProblemRepository, ProblemRepository>();
services.AddScoped<IProjectRepository, ProjectRepository>();
services.AddScoped<ISprintRepository, SprintRepository>();
services.AddScoped<IUserRepository, UserRepository>();

services.AddScoped<IJwtProvider, JwtProvider>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}*/

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/

app.Run();