﻿using MediatR;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.AuthorCommands;

public record UpdateAuthorLastnameCommand(int AuthorId, string AuthorLastname) : IRequest<AuthorDto>;

public class UpdateAuthorLastnameCommandHandler : IRequestHandler<UpdateAuthorLastnameCommand, AuthorDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthorRepository _authorRepository;

    public UpdateAuthorLastnameCommandHandler(IUnitOfWork unitOfWork, IAuthorRepository authorRepository)
    {
        _unitOfWork = unitOfWork;
        _authorRepository = authorRepository;
    }

    public async Task<AuthorDto> Handle(UpdateAuthorLastnameCommand request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.Find(request.AuthorId);

        if (author == null)
        {
            throw new ArgumentException(nameof(author));
        }

        author.Lastname = request.AuthorLastname;

        await _unitOfWork.SaveAsync(cancellationToken);

        return new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            Lastname = author.Lastname,
        };
    }
}
