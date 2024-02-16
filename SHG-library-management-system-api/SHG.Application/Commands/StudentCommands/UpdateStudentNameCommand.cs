using MediatR;
using Microsoft.AspNetCore.Identity;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.StudentCommands;

public record UpdateStudentNameCommand(int StudentId, string StudentName, string StudentLastname) : IRequest<StudentDto?>;

public class UpdateStudentNameCommandHandler : IRequestHandler<UpdateStudentNameCommand, StudentDto?>
{
    private readonly UserManager<User> _userManager;

    public UpdateStudentNameCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<StudentDto?> Handle(UpdateStudentNameCommand request, CancellationToken cancellationToken)
    {
        var student = await _userManager.FindByIdAsync(request.StudentId.ToString());

        if (student == null)
        {
            return null;
        }

        student.Name = request.StudentName;
        student.Lastname = request.StudentLastname;

        //Need extension method for updating student name and lastname

        return new StudentDto
        {
            Name = request.StudentName,
            Lastname = request.StudentLastname,
            Email = student.Email,
            Books = student.Books,
        };
    }
}
