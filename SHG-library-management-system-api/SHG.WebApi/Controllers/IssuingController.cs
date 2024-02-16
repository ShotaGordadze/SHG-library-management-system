using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHG.Application.Commands.StudentCommands;
using SHG.WebApi.Models;

namespace SHG.WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class IssuingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IssuingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> IssueAsync([FromBody] BookIssueModel model)
        {
            if (model == null)
            {
                return BadRequest("Request body is null");
            }
            var cmd = new IssueBookCommand(model.BookId, model.StudentId, model.IssueStartDate, model.IssueEndDate);

            var result = await _mediator.Send(cmd);

            if (!result)
            {
                return NotFound();
            }

            return Ok("Book issued successfully");
        }
    }
}

