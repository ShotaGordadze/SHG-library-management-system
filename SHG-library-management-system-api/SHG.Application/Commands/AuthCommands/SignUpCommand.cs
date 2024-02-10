using MediatR;
using Microsoft.AspNetCore.Identity;
using SHG.Infrastructure;
using SHG.Infrastructure.Database.Entities;

namespace SHG.Application.Commands.AuthCommands;

public record SignUpCommand(string Email, string Password) : IRequest<User?>;

public class SignUpCommandHandler : IRequestHandler<SignUpCommand, User?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public SignUpCommandHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task<User?> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        if (_userManager.FindByEmailAsync(request.Email) == null)
        {
            return null;
        }

        var idpUserResult = await _userManager.CreateAsync(new User
        {
            UserName = request.Email,
            Email = request.Email,
        }, request.Password);

        if (!idpUserResult.Succeeded)
        {
            return null;
        }

        var idpUser = await _userManager.FindByEmailAsync(request.Email);
        if (idpUser != null) await _userManager.AddToRoleAsync(idpUser, "Client");

        return idpUser;
    }
}
