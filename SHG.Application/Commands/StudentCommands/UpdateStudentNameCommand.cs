using MediatR;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.StudentCommands;

public record UpdateStudentNameCommand(int StudentId, string StudentName) : IRequest<StudentDto>;

public class UpdateStudentNameCommandHandler : IRequestHandler<UpdateStudentNameCommand, StudentDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentRepository _studentRepository;

    public UpdateStudentNameCommandHandler(IUnitOfWork unitOfWork, IStudentRepository studentRepository)
    {
        _unitOfWork = unitOfWork;
        _studentRepository = studentRepository;
    }

    public async Task<StudentDto> Handle(UpdateStudentNameCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.Find(request.StudentId);

        if (student == null)
        {
            throw new ArgumentException(nameof(student));
        }

        student.Name = request.StudentName;

        await _unitOfWork.SaveAsync(cancellationToken);

        return new StudentDto
        {
            Name = request.StudentName,
            Email = student.Email
        };
    }
}
