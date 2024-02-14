using MediatR;
using Microsoft.AspNetCore.Identity;
using SHG.Infrastructure.Database.Entities;

namespace SHG.Application.Commands.IdentityCommands;

public record DeleteRoleCommand(Guid Id) : IRequest<bool>;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, bool>
{
    private readonly RoleManager<Role> _roleManager;

    public DeleteRoleCommandHandler(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _roleManager.FindByIdAsync(request.Id.ToString());

        if (result != null)
        {
            await _roleManager.DeleteAsync(result);

            return true;
        }

        return false;
    }
}

