using MediatR;
using Microsoft.EntityFrameworkCore;
using SHG.Application.Dtos;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Queries.StudentQueries;

public record GetStudentQuery(int Id) : IRequest<StudentDto>;

public class FindStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentDto>
{
    private readonly IStudentRepository _studentRepository;

    public FindStudentQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<StudentDto> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.Query(x => x.Id == request.Id)
                                              .FirstAsync(cancellationToken);

        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            Books = student.Books,
        };
    }
}


