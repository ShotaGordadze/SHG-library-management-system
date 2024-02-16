//using MediatR;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using SHG.Application.Dtos;
//using SHG.Infrastructure;
//using SHG.Infrastructure.Database.Entities;
//using SHG.Infrastructure.Repositories;

//namespace SHG.Application.Commands.StudentCommands;

//public record AddStudentCommand(string Name, string Email) : IRequest<StudentDto?>;

//public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, StudentDto?>
//{
//    private readonly UserManager<User> _userManager;

//    public AddStudentCommandHandler(UserManager<User> userManager)
//    {
//        _userManager = userManager;
//    }

//    public async Task<StudentDto?> Handle(AddStudentCommand request, CancellationToken cancellationToken)
//    {
//        if (_userManager.FindByEmailAsync(request.Email) == null)
//        {
//            return null;
//        }

//        var student = new User
//        {
//            Name = request.Name,
//            Email = request.Email,
//        };

//        await _studentRepository.Store(student);
//        await _unitOfWork.SaveAsync(cancellationToken);

//        student = await _studentRepository.Query(x => x.Id == student.Id)
//                                          .Include(x => x.Books)
//                                          .FirstAsync();

//        return new StudentDto
//        {
//            Name = student.Name,
//            Email = student.Email,
//            Books = student.Books
//        };
//    }
//}


