using MediatR;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.StudentCommands;

public record DeleteStudentCommand(int id) : IRequest<int>;

public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentRepository _studentRepository;

    public DeleteStudentCommandHandler(IUnitOfWork unitOfWork, IStudentRepository studentRepository)
    {
        _unitOfWork = unitOfWork;
        _studentRepository = studentRepository;
    }

    public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.Find(request.id);

        if (student == null)
        {
            return -1;
        }

        _studentRepository.Delete(student);
        await _unitOfWork.SaveAsync(cancellationToken);

        return request.id;
    }
}


