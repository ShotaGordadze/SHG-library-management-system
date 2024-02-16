using MediatR;
using Microsoft.AspNetCore.Identity;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.StudentCommands;

public record DeleteStudentCommand(Guid StudentId) : IRequest<int>;

public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, int>
{
    private readonly UserManager<User> _userManager;

    public DeleteStudentCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _userManager.FindByIdAsync(request.StudentId.ToString());

        if (student == null)
        {
            return -1;
        }

        await _userManager.DeleteAsync(student);

        return 0;
    }
}


