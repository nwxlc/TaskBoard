using Microsoft.EntityFrameworkCore;
using TaskBoard;
using TaskBoard.Domain;
using TaskBoard.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Configuration.Bind("Project", new Config());
Console.WriteLine(Config.ConnectionString);
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(Config.ConnectionString));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();