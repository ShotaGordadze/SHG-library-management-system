using MediatR;
using Microsoft.AspNetCore.Identity;
using SHG.Infrastructure.Database.Entities;
using System.Runtime.CompilerServices;

namespace SHG.Application.Commands.AuthCommands;

public record SignInCommand(string UserName, string Password) : IRequest<AccessTokenDto?>;

public class SignInCommandHandler : IRequestHandler<SignInCommand, AccessTokenDto?>
{
    private readonly UserManager<User> _userManager;
    private readonly TokenService _tokenService;

    public SignInCommandHandler(UserManager<User> userManager, TokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<AccessTokenDto?> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var idpUser = await _userManager.FindByNameAsync(request.UserName);

        if (idpUser is { UserName: not null } && await _userManager.CheckPasswordAsync(idpUser, request.Password))
        {
            return await _tokenService.GenerateJwtToken(idpUser);
        }

        return null;
    }
}
