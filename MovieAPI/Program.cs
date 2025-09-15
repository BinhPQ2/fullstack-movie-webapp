using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Use connection string from appsettings.json
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDbCS")));

var app = builder.Build();

//Asynchronous method to seed data into our database
using (var scope = app.Services.CreateScope())
{
    var Services = scope.ServiceProvider;
    try
    {
        var context = Services.GetRequiredService<MovieContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error during migration: {ex.Message}");
    }
}

app.MapGet("/", () => "Hello World!");

app.Run();
