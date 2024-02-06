using MediatR;
using Microsoft.EntityFrameworkCore;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.StudentCommands;

public record AddStudentCommand(string Name, string Email) : IRequest<StudentDto>;

public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, StudentDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentRepository _studentRepository;

    public AddStudentCommandHandler(IUnitOfWork unitOfWork, IStudentRepository studentRepository)
    {
        _unitOfWork = unitOfWork;
        _studentRepository = studentRepository;
    }

    public async Task<StudentDto> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        var student = new Student
        {
            Name = request.Name,
            Email = request.Email,
            CreateDate = DateTime.Now.ToUniversalTime(),
        };

        await _studentRepository.Store(student);
        await _unitOfWork.SaveAsync(cancellationToken);

        student = await _studentRepository.Query(x => x.Id == student.Id)
                                          .Include(x => x.Books)
                                          .FirstAsync();

        return new StudentDto
        {
            Name = student.Name,
            Email = student.Email,
            Books = student.Books
        };
    }
}


