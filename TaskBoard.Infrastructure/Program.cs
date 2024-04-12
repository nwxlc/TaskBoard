using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskBoard;
using TaskBoard.Application.Interfaces.Auth;
using TaskBoard.Application.Interfaces.Repositories;
using TaskBoard.Application.Users.Handlers;
using TaskBoard.Infrastructure;
using TaskBoard.Infrastructure.Authentication;
using TaskBoard.Infrastructure.Extensions;
using TaskBoard.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();

services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
services.AddEndpointsApiExplorer();
services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(UserRegisterHandler).Assembly);
});

services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
services.Configure<AuthorizationOptions>(configuration.GetSection(nameof(AuthorizationOptions)));

configuration.Bind("Project", new Config());
services.AddDbContext<AppDbContext>(options => options.UseNpgsql(Config.ConnectionString));

services.AddScoped<IProblemRepository, ProblemRepository>();
services.AddScoped<IProjectRepository, ProjectRepository>();
services.AddScoped<ISprintRepository, SprintRepository>();
services.AddScoped<IUserRepository, UserRepository>();

services.AddApiAuthentication(configuration);

services.AddScoped<IJwtProvider, JwtProvider>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(routeBuilder => { routeBuilder.MapControllers(); });

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/

app.Run();