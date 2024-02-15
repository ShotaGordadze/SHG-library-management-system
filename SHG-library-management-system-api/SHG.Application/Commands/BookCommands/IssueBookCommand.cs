using MediatR;
using Microsoft.AspNetCore.Identity;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.BookCommands;

public record IssueBookCommand(Guid StudentId, int BookId) : IRequest<bool?>;

public class IssueBookCommandHandler : IRequestHandler<IssueBookCommand, bool?>
{
    private readonly IBookRepository _bookRepository;
    private readonly UserManager<User> _userManager;

    public IssueBookCommandHandler(IBookRepository bookRepository, UserManager<User> userManager)
    {
        _bookRepository = bookRepository;
        _userManager = userManager;
    }

    public async Task<bool?> Handle(IssueBookCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var student = await _userManager.FindByIdAsync(request.StudentId.ToString());
            var book = _bookRepository.Find(request.BookId);

            if (student != null && book != null) { }
        }
        catch (Exception)
        {
            return null;
        }
    }
}


