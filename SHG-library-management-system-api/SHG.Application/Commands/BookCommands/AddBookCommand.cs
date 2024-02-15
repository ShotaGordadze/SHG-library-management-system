using MediatR;
using Microsoft.EntityFrameworkCore;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.BookCommands;

public record AddBookCommand(string Title,string Description,string Image, int AuthorId) : IRequest<BookDto?>;

public class AddBookCommandHandler : IRequestHandler<AddBookCommand, BookDto?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;

    public AddBookCommandHandler(IUnitOfWork unitOfWork, IBookRepository bookRepository, IAuthorRepository authorRepository)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }

    public async Task<BookDto?> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _authorRepository.Find(request.AuthorId);
        }
        catch (Exception)
        {
            return null;
        }

        var book = new Book
        {
            Title = request.Title,
            Description = request.Description,
            Image = request.Image,
            Author = await _authorRepository.Find(request.AuthorId),
            AuthorId = request.AuthorId,
            CreateDate = DateTime.Now.ToUniversalTime()
        };

        await _bookRepository.Store(book);
        await _unitOfWork.SaveAsync(cancellationToken);

        book = await _bookRepository.Query(x => x.Id == book.Id)
                                    .FirstAsync(cancellationToken);

        return new BookDto
        {
            Title = book.Title,
            Image = book.Image,
            Description = book.Description,
            Author = book.Author.Name + " " + book.Author.Lastname,
        };
    }
}


