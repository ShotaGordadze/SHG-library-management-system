using Microsoft.EntityFrameworkCore;
using SHG.Infrastructure.Database;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories.Abstraction;
using System.Linq.Expressions;

namespace SHG.Infrastructure.Repositories;

public interface IStudentRepository : IRepository<Student>
{
}

public class StudentRepository : IStudentRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public StudentRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Student> Find(int id)
    {
       return await _libraryDbContext.Students.FirstAsync(s => s.Id == id);
    }

    public IQueryable<Student> Query(Expression<Func<Student, bool>>? expression = null)
    {
        return expression != null ?
            _libraryDbContext.Students.Where(expression) :
            _libraryDbContext.Students.AsQueryable();
    }

    public async Task Store(Student document)
    {
        await _libraryDbContext.Students.AddAsync(document);
    }

    public void Delete(Student document)
    {
        _libraryDbContext.Students.Remove(document);
    }
}
