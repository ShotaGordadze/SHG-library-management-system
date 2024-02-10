using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SHG.Infrastructure.Database;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories;

namespace SHG.Infrastructure;

public static class DIExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryDbContext>((sc, options) => { options.UseNpgsql(configuration.GetConnectionString("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=InventoryManagement;Pooling=true;")); });

        services.AddIdentityCore<User>(config =>
        {
            config.User.RequireUniqueEmail = true;
            config.User.AllowedUserNameCharacters = null;
            config.Password.RequireDigit = true;
            config.Password.RequireLowercase = true;
            config.Password.RequireUppercase = true;
            config.Password.RequireNonAlphanumeric = true;
        })
               .AddRoles<Role>()
               .AddUserManager<UserManager<User>>()
               .AddEntityFrameworkStores<LibraryDbContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();

        return services;
    }
}
