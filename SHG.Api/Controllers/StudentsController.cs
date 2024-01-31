using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SHG.Api.Models;
using SHG.Application.Commands.StudentCommands;

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
        var student = await _mediator.Send(new AddStudentCommand(model.Name, model.Email));

        return Ok(student);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] StudentModel model)
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
