using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHG.WebApi.Models;
using SHG.Application.Commands.StudentCommands;
using SHG.Application.Queries;
using SHG.Application.Queries.StudentQueries;

namespace SHG.Api.Controllers;

[ApiController]
[Route("Controller")]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] StudentModel model)
    {
        var result = await _mediator.Send(new AddStudentCommand(model.Name, model.Email));

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetStudentQuery(id));

        return Ok(result);
    }
    //sus
    [HttpGet("{id:int}/details")]
    public async Task<IActionResult> GetDetailsAsync([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetStudentDetailsQuery(id));

        return Ok(result);
    }

    [HttpPut("{id:int}/name")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] StudentUpdateNameModel model)
    {
        var result = await _mediator.Send(new UpdateStudentNameCommand(id, model.Name));

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteStudentCommand(id));

        return Ok(result);
    }
}
