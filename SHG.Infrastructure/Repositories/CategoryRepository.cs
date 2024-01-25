using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SHG.Infrastructure.Database;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories.Abstraction;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace SHG.Infrastructure.Repositories;

public interface ICategoryInterface : IRepository<Category>
{
}

public class CategoryRepository : IRepository<Category>
{
    private readonly LibraryDbContext _libraryDbContext;

    public CategoryRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Category> Find(int id)
    {
        return await _libraryDbContext.Categories.FirstAsync(c => c.Id == id);
    }

    public IQueryable<Category> Query(Expression<Func<Category, bool>>? expression = null)
    {
        return expression != null ?
            _libraryDbContext.Categories.Where(expression) :
            _libraryDbContext.Categories.AsQueryable();
    }

    public async Task Store(Category document)
    {
        await _libraryDbContext.Categories.AddAsync(document);
    }

    public void Delete(Category document)
    {
        _libraryDbContext.Categories.Remove(document);
    }
}
