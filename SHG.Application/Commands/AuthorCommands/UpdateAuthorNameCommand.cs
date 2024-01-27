using MediatR;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.AuthorCommands;

public record UpdateAuthorNameCommand(int id, string name) : IRequest<AuthorDto>;

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
        var author = await _authorRepository.Find(request.id);

        if (author == null)
        {
            throw new ArgumentException(nameof(author));
        }

        author.Name = request.name;

        await _unitOfWork.SaveAsync(cancellationToken);

        return new AuthorDto
        {
            Id = author.Id,
            Name = request.name,
            Lastname = author.Lastname,
        };
    }
}
