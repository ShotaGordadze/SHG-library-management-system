using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHG.Api.Models;
using SHG.Application.Commands.AuthorCommands;
using SHG.Application.Queries.AuthorQueries;

namespace SHG.Api.Controllers;
[Authorize]
[ApiController]
[Route("[Controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AuthorModel model)
    {
        var result = await _mediator.Send(new AddAuthorCommand(model.Name, model.Lastname));

        return Ok(result);
    }
    //Add AuthorDetails request
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetAuthorQuery(id));

        return Ok(result);
    }

    [HttpPut("{id:int}/name")]
    public async Task<IActionResult> UpdateNameAsync(int id, AuthorUpdateNameModel model)
    {
        var result = await _mediator.Send(new UpdateAuthorNameCommand(id, model.Name));

        return Ok(result);
    }

    [HttpPut("{id:int}/lastname")]
    public async Task<IActionResult> UpdateLastnameAsync(int id, AuthorUpdateLastnameModel model)
    {
        var result = await _mediator.Send(new UpdateAuthorLastnameCommand(id, model.Lastname));

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _mediator.Send(new DeleteAuthorCommand(id));

        return Ok(result);
    }
}
