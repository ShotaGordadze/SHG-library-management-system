using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace SHG.Application;

public static class DIExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddScoped<TokenService>();

        return services;
    }
}
