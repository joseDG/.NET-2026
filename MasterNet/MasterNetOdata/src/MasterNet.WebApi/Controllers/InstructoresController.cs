using MasterNet.Application.Core;
using MasterNet.Application.Instructores.GetInstructores;
using MasterNet.Application.Instructores.InstructorCreate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static MasterNet.Application.Instructores.GetInstructores.GetInstructoresQuery;

namespace MasterNet.WebApi.Controllers;

[ApiController]
[Route("api/instructores")]
public class InstructoresController : ControllerBase
{
    private readonly ISender _sender;

    public InstructoresController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<PagedList<InstructorResponse>>> PaginationInstructor
    (
        [FromQuery] GetInstructoresRequest request,
        CancellationToken cancellationToken
    )
    {
        var query = new GetInstructoresQueryRequest
        {
            InstructorRequest = request
        };
        var resultados = await _sender.Send(query, cancellationToken);
        return resultados.IsSuccess ? Ok(resultados.Value) : NotFound();
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Guid>> CreateInstructor
    (
        [FromBody] InstructorCreateCommand.InstructorCreateCommandRequest request,
        CancellationToken cancellationToken
    )
    {
        var result = await _sender.Send(request, cancellationToken);

        if (result != Guid.Empty)
        {
            return CreatedAtAction(nameof(CreateInstructor), new { id = result }, result);
        }

        return BadRequest("Error creating instructor");
    }
}