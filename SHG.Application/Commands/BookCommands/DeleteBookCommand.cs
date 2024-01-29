using MediatR;
using SHG.Infrastructure;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.BookCommands;

public record DeleteBookCommand(int BookId) : IRequest<int>;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;

    public DeleteBookCommandHandler(IUnitOfWork unitOfWork, IBookRepository bookRepository)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
    }

    public async Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.Find(request.BookId);

        if (book == null)
        {
            return -1;
        }

        _bookRepository.Delete(book);
        await _unitOfWork.SaveAsync(cancellationToken);

        return 0;
    }
}
