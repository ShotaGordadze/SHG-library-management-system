using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SHG.Application.Commands.BookCommands;
using SHG.Application.Queries.BookQueries;
using SHG.WebApi.Models;

namespace SHG.WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[Authorize]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] BookModel model)
    {
        var result = await _mediator.Send(new AddBookCommand(model.Title, model.AuthorId));

        if (result == null)
        {
            return BadRequest("Couldn't find the author");
        }

        return Ok(result);
    }

    // probably will need http context
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _mediator.Send(new GetAllBooksQuery());

        return Ok(result);
    }
}
