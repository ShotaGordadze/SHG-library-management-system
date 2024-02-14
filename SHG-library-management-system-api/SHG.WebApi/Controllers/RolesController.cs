using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHG.Application.Commands.IdentityCommands;
using SHG.WebApi.Identity;
using SHG.WebApi.Models;

namespace SHG.WebApi.Controllers
{
    [ApiController]
    [Route("Controller/Role")]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddAsync(RoleModel model)
        {
            var cmd = new AddRoleCommand(model.Name);

            var result = await _mediator.Send(cmd);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest("Couldn't create role");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            var cmd = new DeleteRoleCommand(Id);

            var result = await _mediator.Send(cmd);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest("Couldn't create role");
        }
    }
}
