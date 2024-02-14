﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using SHG.Infrastructure.Database.Entities;

namespace SHG.Application.Commands.IdentityCommands;

public record AddRoleCommand(string RoleName) : IRequest<bool>;

public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, bool>
{
    private readonly RoleManager<Role> _roleManager;

    public AddRoleCommandHandler(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<bool> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        if (!await _roleManager.RoleExistsAsync(request.RoleName))
        {
            var role = new Role
            {
                Name = request.RoleName,
            };
            await _roleManager.CreateAsync(role);

            return true;
        }

        return false;
    }
}

