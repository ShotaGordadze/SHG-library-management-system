using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHG.Application.Commands.IdentityCommands;
using SHG.WebApi.Models;

namespace SHG.WebApi.Controllers
{
    [ApiController]
    [Route("Controller/Role")]
    public class AddRoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

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
    }
}
