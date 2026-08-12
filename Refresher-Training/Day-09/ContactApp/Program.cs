using ContactApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Registers MVC controllers in the dependency injection container.
/// </summary>
builder.Services.AddControllers();

/// <summary>
/// Registers AppDbContext with Entity Framework Core
/// and configures SQL Server using the connection string
/// from appsettings.json.
/// </summary>
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ContactDbConnection")));

var app = builder.Build();

/// <summary>
/// Enables HTTPS redirection for incoming HTTP requests.
/// </summary>
app.UseHttpsRedirection();

/// <summary>
/// Enables authorization middleware.
/// </summary>
app.UseAuthorization();

/// <summary>
/// Maps controller endpoints to the application's request pipeline.
/// </summary>
app.MapControllers();

app.Run();