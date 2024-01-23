using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SHG.Infrastructure;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureLogging(config => config.SetMinimumLevel(LogLevel.Error));

builder.ConfigureServices((hostBuilderContext, sc) =>
{
    sc.AddInfrastructure(hostBuilderContext.Configuration);

});

builder.Build()
       .Run();



