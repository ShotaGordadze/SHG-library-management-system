using Microsoft.EntityFrameworkCore;
using SHG.Application;
using SHG.Infrastructure;
using SHG.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryDbContext>((sc, options) =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

app.MapGet("/security/getMessage",
() => "Hello World!").RequireAuthorization();

await using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
await InfrastructureHandler.InitDbContext(scope.ServiceProvider.GetRequiredService<LibraryDbContext>(), scope.ServiceProvider);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
