using Microsoft.EntityFrameworkCore;
using SHG.Infrastructure.Database;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories.Abstraction;
using System.Linq.Expressions;

namespace SHG.Infrastructure.Repositories;

public interface IBookRepository : IRepository<Book>
{
}


public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public BookRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Book> Find(int id)
    {
        return await _libraryDbContext.Books.FirstAsync(x => x.Id == id);
    }

    public IQueryable<Book> Query(Expression<Func<Book, bool>>? expression = null)
    {
        return expression != null ?
            _libraryDbContext.Books.Where(expression) :
            _libraryDbContext.Books.AsQueryable();
    }

    public async Task Store(Book document)
    {
        await _libraryDbContext.Books.AddAsync(document);
    }

    public void Delete(Book document)
    {
        _libraryDbContext.Books.Remove(document);
    }
}
