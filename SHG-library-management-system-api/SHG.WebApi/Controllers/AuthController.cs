using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHG.Application.Commands.AuthCommands;
using SHG.WebApi.Models;

namespace SHG.WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Sign Up")]
    public async Task<IActionResult> SignUpAsync(SignUpModel model)
    {
        var cmd = new SignUpCommand(model.Email, model.Password);

        var user = await _mediator.Send(cmd);
        if (user != null)
        {
            return Ok(user);
        }

        return BadRequest("Couldn't create an user");
    }

    [HttpPost("Sign in")]
    public async Task<IActionResult> SignInAsync(SignInModel model)
    {
        var userToken = await _mediator.Send(new SignInCommand(model.Email, model.Password));

        if (userToken is null)
        {
            return BadRequest();
        }

        return Ok(userToken);
    }
}
