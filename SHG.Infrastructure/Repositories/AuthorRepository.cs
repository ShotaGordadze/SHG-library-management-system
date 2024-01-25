using Microsoft.EntityFrameworkCore;
using SHG.Infrastructure.Database;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories.Abstraction;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace SHG.Infrastructure.Repositories;

public interface IAuthorRepository : IRepository<Author>
{
}

public class AuthorRepository : IRepository<Author>
{
    private readonly LibraryDbContext _libraryDbContext;

    public AuthorRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Author> Find(int id)
    {
        return await _libraryDbContext.Authors.FirstAsync(a => a.Id == id);
    }

    public IQueryable<Author> Query(Expression<Func<Author, bool>>? expression = null)
    {
        return expression != null ?
            _libraryDbContext.Authors.Where(expression) :
            _libraryDbContext.Authors.AsQueryable();    
    }

    public async Task Store(Author document)
    {
        await _libraryDbContext.Authors.AddAsync(document);
    }

    public void Delete(Author document)
    {
        _libraryDbContext.Authors.Remove(document);
    }
}
