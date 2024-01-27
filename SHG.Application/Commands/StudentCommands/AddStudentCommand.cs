using MediatR;
using SHG.Application.Dtos;

namespace SHG.Application.Commands.StudentCommands;

public record AddStudentCommand() : IRequest<StudentDto>;

public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, StudentDto>
{
    public Task<StudentDto> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}


