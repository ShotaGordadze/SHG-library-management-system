using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SHG.Infrastructure.Database;

namespace SHG.Infrastructure;

public static class DIExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryDbContext>((sc, options) => { options.UseNpgsql(configuration.GetConnectionString("")); }) ;

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

}
