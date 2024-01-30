using MediatR;
using Microsoft.AspNetCore.Mvc;

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


}
