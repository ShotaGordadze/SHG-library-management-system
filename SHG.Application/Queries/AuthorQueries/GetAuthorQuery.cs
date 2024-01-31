using MediatR;
using Microsoft.EntityFrameworkCore;
using SHG.Application.Dtos;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Queries.AuthorQueries;

public record GetAuthorQuery(int Id) : IRequest<AuthorDto>;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, AuthorDto>
{
    private readonly IAuthorRepository _authorRepository;

    public GetAuthorQueryHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<AuthorDto> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.Query(x => x.Id == request.Id)
                                              .FirstAsync(cancellationToken);

        return new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            Lastname = author.Lastname,
            Books = author.Books,
        };
    }
}


