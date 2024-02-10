using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHG.Application.Commands.AuthCommands;
using SHG.WebApi.Models;

namespace SHG.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("[Controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> SignUpAsync(UserModel model)
    {
        var cmd = new SignUpCommand(model.Email, model.Password);

        var user = await _mediator.Send(cmd);
        if (user != null)
        {
            return Ok(user);
        }

        return BadRequest("Couldn't create an user");
    }
}
