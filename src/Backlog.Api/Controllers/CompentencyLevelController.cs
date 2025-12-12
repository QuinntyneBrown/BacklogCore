using Backlog.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;

namespace Backlog.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CompetencyLevelController
{
    private readonly IMediator _mediator;

    public CompetencyLevelController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet("{competencyLevelId}", Name = "GetCompetencyLevelById")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetCompetencyLevelByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCompetencyLevelByIdResponse>> GetById([FromRoute] Guid competencyLevelId)
    {
        var request = new GetCompetencyLevelByIdRequest { CompetencyLevelId = competencyLevelId };
        var response = await _mediator.Send(request);

        if (response.CompetencyLevel == null)
        {
            return new NotFoundObjectResult(request.CompetencyLevelId);
        }

        return response;
    }

    [HttpGet(Name = "GetCompetencyLevels")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetCompetencyLevelsResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCompetencyLevelsResponse>> Get()
        => await _mediator.Send(new GetCompetencyLevelsRequest());

    [HttpPost(Name = "CreateCompetencyLevel")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CreateCompetencyLevelResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateCompetencyLevelResponse>> Create([FromBody] CreateCompetencyLevelRequest request)
        => await _mediator.Send(request);

    [HttpGet("page/{pageSize}/{index}", Name = "GetCompetencyLevelsPage")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetCompetencyLevelsPageResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCompetencyLevelsPageResponse>> Page([FromRoute] int pageSize, [FromRoute] int index)
    {
        var request = new GetCompetencyLevelsPageRequest { Index = index, PageSize = pageSize };

        return await _mediator.Send(request);
    }

    [HttpPut(Name = "UpdateCompetencyLevel")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateCompetencyLevelResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateCompetencyLevelResponse>> Update([FromBody] UpdateCompetencyLevelRequest request)
        => await _mediator.Send(request);

    [HttpDelete("{competencyLevelId}", Name = "RemoveCompetencyLevel")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(RemoveCompetencyLevelResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<RemoveCompetencyLevelResponse>> Remove([FromRoute] Guid competencyLevelId)
    {
        var request = new RemoveCompetencyLevelRequest {  CompetencyLevelId = competencyLevelId };

        return await _mediator.Send(request);
    }
}