using MediatR;
using Microsoft.EntityFrameworkCore;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.AuthorCommands;

//Add Birthdate
public record AddAuthorCommand(string name, string lastname) : IRequest<AuthorDto>;

public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, AuthorDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthorRepository _authorRepository;

    public AddAuthorCommandHandler(IUnitOfWork unitOfWork, IAuthorRepository authorRepository)
    {
        _unitOfWork = unitOfWork;
        _authorRepository = authorRepository;
    }

    public async Task<AuthorDto> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = new Author
        {
            Name = request.name,
            Lastname = request.lastname
        };

        await _authorRepository.Store(author);

        await _unitOfWork.SaveAsync(cancellationToken);

        author = await _authorRepository.Query(x => x.Id == author.Id)
                                        .FirstAsync(cancellationToken);

        return new AuthorDto
        {
            Id = author.Id,
            Name = request.name,
            Lastname = request.lastname
        };
    }
}

