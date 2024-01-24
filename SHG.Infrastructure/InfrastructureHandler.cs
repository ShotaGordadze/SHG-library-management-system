﻿using Microsoft.EntityFrameworkCore;
using SHG.Infrastructure.Database;

namespace SHG.Infrastructure;

public static class InfrastructureHandler
{
    public async static Task InitDbContext(LibraryDbContext dbContext, IServiceProvider serviceProvider)
    {
        if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
        {
            await dbContext.Database.MigrateAsync();
        }
    }
}
