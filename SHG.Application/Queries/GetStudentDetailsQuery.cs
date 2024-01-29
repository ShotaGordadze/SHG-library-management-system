using MediatR;
using Microsoft.EntityFrameworkCore;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Queries;

public record GetStudentDetailsQuery(int Id) : IRequest<StudentDetailsDto>;

public class GetStudentDetailsQueryHandler : IRequestHandler<GetStudentDetailsQuery, StudentDetailsDto>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentDetailsQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<StudentDetailsDto> Handle(GetStudentDetailsQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.Query(x => x.Id == request.Id)
                                              .FirstAsync(cancellationToken);

        return new StudentDetailsDto
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            Books = student.Books,
            CreateDate = student.CreateDate,
            LastChangeDate = student.LastChangeDate,
        };
    }
}

