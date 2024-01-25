using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SHG.Infrastructure.Database;
using SHG.Infrastructure.Repositories;

namespace SHG.Infrastructure;

public static class DIExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryDbContext>((sc, options) => { options.UseNpgsql(configuration.GetConnectionString("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=InventoryManagement;Pooling=true;")); }) ;

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();


        return services;
    }
}
