using MediatR;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.AuthorCommands;

public record UpdateAuthorNameCommand(int AuthorId, string AuthorName) : IRequest<AuthorDto>;

public class UpdateAuthorNameCommandHandler : IRequestHandler<UpdateAuthorNameCommand, AuthorDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthorRepository _authorRepository;

    public UpdateAuthorNameCommandHandler(IUnitOfWork unitOfWork, IAuthorRepository authorRepository)
    {
        _unitOfWork = unitOfWork;
        _authorRepository = authorRepository;
    }

    public async Task<AuthorDto> Handle(UpdateAuthorNameCommand request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.Find(request.AuthorId);

        if (author == null)
        {
            throw new ArgumentException(nameof(author));
        }

        author.Name = request.AuthorName;

        await _unitOfWork.SaveAsync(cancellationToken);

        return new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            Lastname = author.Lastname,
        };
    }
}
