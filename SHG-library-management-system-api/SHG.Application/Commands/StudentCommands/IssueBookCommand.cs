using MediatR;
using Microsoft.AspNetCore.Identity;
using SHG.Infrastructure;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.StudentCommands;

public record IssueBookCommand(int BookId, Guid StudentId, DateTime Start, DateTime End) : IRequest<bool>;

public class IssueBookCommandHandler : IRequestHandler<IssueBookCommand, bool>
{
    private readonly UserManager<User> _userManager;
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public IssueBookCommandHandler(UserManager<User> userManager, IBookRepository bookRepository,IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(IssueBookCommand request, CancellationToken cancellationToken)
    {
        var originalBook = await _bookRepository.Find(request.BookId);
        var student = await _userManager.FindByIdAsync(request.StudentId.ToString());   

        if (originalBook == null || student == null)
        {
            return false;
        }

        student.Books.Add(new Book
        {
            Title = originalBook.Title,
            Description = originalBook.Description,
            Image = originalBook.Image,
            Author = originalBook.Author,
            AuthorId = originalBook.AuthorId,
            IssueStartDate = request.Start,
            IssueEndDate = request.End,
            Categories = originalBook.Categories,
            Users = originalBook.Users,
        });

        await _unitOfWork.SaveAsync(cancellationToken);

        return true;
    }
}
