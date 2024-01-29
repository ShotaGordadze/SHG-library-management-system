using MediatR;
using Microsoft.EntityFrameworkCore;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.BookCommands;

public record AddBookCommand(string Title, int AuthorId) : IRequest<BookDto>;

public class AddBookCommandHandler : IRequestHandler<AddBookCommand, BookDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;

    public AddBookCommandHandler(IUnitOfWork unitOfWork, IBookRepository bookRepository)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
    }

    public async Task<BookDto> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Title = request.Title,
            AuthorId = request.AuthorId,
            CreateDate = DateTime.Now
        };

        await _bookRepository.Store(book);
        await _unitOfWork.SaveAsync(cancellationToken);

        book = await _bookRepository.Query(x => x.Id == book.Id)
                                    .Include(x => x.Author)
                                    .FirstAsync(cancellationToken);

        return new BookDto
        {
            Title = book.Title,
            Description = book.Description,
            Author = book.Author,
        };
    }
}


