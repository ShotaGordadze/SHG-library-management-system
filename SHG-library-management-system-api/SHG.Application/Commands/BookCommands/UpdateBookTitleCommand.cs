using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.BookCommands;

public record UpdateBookTitleCommand(int BookId, string Title) : IRequest<BookDto>;

public class UpdateBookTitleCommandHandler : IRequestHandler<UpdateBookTitleCommand, BookDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;

    public UpdateBookTitleCommandHandler(IUnitOfWork unitOfWork, IBookRepository bookRepository)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
    }

    public async Task<BookDto> Handle(UpdateBookTitleCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.Find(request.BookId);

        if (book == null)
        {
            throw new ArgumentException(nameof(book));
        }

        book.Title = request.Title;

        await _unitOfWork.SaveAsync(cancellationToken);

        book = await _bookRepository.Query(x => x.Id == request.BookId)
                                    .Include(x => x.Author)
                                    .FirstAsync(cancellationToken);

        return new BookDto
        {
            Title = book.Title,
            Author = book.Author.Name + " " + book.Author.Lastname,
            Description = book.Description
        };
    }
}
