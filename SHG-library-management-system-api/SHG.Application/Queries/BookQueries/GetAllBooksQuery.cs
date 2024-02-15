using MediatR;
using Microsoft.IdentityModel.Tokens;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Queries.BookQueries;

public record GetAllBooksQuery() : IRequest<IEnumerable<Book>>;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
{
    private readonly IBookRepository _bookRepository;

    public GetAllBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = _bookRepository.Query().ToList();

        var result = new List<Book>();  

        foreach (var book in books)
        {
            result.Add(book);
        }

        return books;
    }
}


