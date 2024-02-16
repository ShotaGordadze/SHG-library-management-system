using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SHG.Application.Dtos;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Queries.StudentQueries;

public record GetStudentQuery(Guid Id) : IRequest<StudentDto?>;

public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentDto?>
{
    private readonly UserManager<User> _userManager;

    public GetStudentQueryHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<StudentDto?> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {
        var student = await _userManager.FindByIdAsync(request.Id.ToString());

        if (student == null)
        {
            return null;
        }

        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Lastname = student.Lastname,
            Email = student.Email,
            Books = student.Books,
        };
    }
}


