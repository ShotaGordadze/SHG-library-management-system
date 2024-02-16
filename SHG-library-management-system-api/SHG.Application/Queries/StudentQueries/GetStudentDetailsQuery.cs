using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Queries.StudentQueries;

public record GetStudentDetailsQuery(Guid Id) : IRequest<StudentDetailsDto?>;

public class GetStudentDetailsQueryHandler : IRequestHandler<GetStudentDetailsQuery, StudentDetailsDto?>
{
    private readonly UserManager<User> _userManager;

    public GetStudentDetailsQueryHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<StudentDetailsDto?> Handle(GetStudentDetailsQuery request, CancellationToken cancellationToken)
    {
        var student = await _userManager.FindByIdAsync(request.Id.ToString());

        if (student == null)
        {
            return null;
        }

        return new StudentDetailsDto
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email!,
            Books = student.Books,
            CreateDate = student.CreateDate,
            LastChangeDate = student.LastChangeDate,
        };
    }
}

