using MediatR;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.AuthorCommands;

public record DeleteAuthorCommand(int Id) : IRequest<int>;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthorRepository _authorRepository;

    public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork, IAuthorRepository authorRepository)
    {
        _unitOfWork = unitOfWork;
        _authorRepository = authorRepository;
    }

    public async Task<int> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.Find(request.Id);

        if (author == null)
        {
            return -1;
        }

        await _authorRepository.Store(author);
        await _unitOfWork.SaveAsync(cancellationToken);

        return request.Id;
    }
}


