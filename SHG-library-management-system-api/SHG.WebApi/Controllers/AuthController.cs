using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
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
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> CreateTokenAsync(UserModel model)
    {

    }
}
