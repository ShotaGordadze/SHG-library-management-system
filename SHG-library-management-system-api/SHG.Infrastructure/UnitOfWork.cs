﻿using SHG.Infrastructure.Database;
using SHG.Infrastructure.Database.Abstraction;

namespace SHG.Infrastructure;

public interface IUnitOfWork
{
    Task<int> SaveAsync(CancellationToken cancellationToken);
}

public class UnitOfWork : IUnitOfWork
{
    private readonly LibraryDbContext _dbContext;

    public UnitOfWork(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        var entities = _dbContext.ChangeTracker.Entries<Entity>()
                                 .Select(x => x.Entity)
                                 .ToList();

        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
