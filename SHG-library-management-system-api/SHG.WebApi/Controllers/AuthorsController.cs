using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHG.WebApi.Models;
using SHG.Application.Commands.AuthorCommands;
using SHG.Application.Queries.AuthorQueries;

namespace SHG.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AuthorModel model)
    {
        var result = await _mediator.Send(new AddAuthorCommand(model.Name, model.Lastname));

        return Ok(result);
    }

    //Add AuthorDetails endpoint
    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetAuthorQuery(id));

        return Ok(result);
    }

    // ToDo: edit this to update authors name and lastname at the same time
    [Authorize(Roles = "Admin")]
    [HttpPut("{id:int}/name")]
    public async Task<IActionResult> UpdateNameAsync(int id, AuthorUpdateNameModel model)
    {
        var result = await _mediator.Send(new UpdateAuthorNameCommand(id, model.Name));

        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id:int}/lastname")]
    public async Task<IActionResult> UpdateLastnameAsync(int id, AuthorUpdateLastnameModel model)
    {
        var result = await _mediator.Send(new UpdateAuthorLastnameCommand(id, model.Lastname));

        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _mediator.Send(new DeleteAuthorCommand(id));

        return Ok(result);
    }
}
