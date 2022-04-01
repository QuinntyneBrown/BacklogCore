using Backlog.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Backlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnologyController
    {
        private readonly IMediator _mediator;

        public TechnologyController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{technologyId}", Name = "GetTechnologyById")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTechnologyByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTechnologyByIdResponse>> GetById([FromRoute] GetTechnologyByIdRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.Technology == null)
            {
                return new NotFoundObjectResult(request.TechnologyId);
            }

            return response;
        }

        [HttpGet(Name = "GetTechnologies")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTechnologiesResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTechnologiesResponse>> Get()
            => await _mediator.Send(new GetTechnologiesRequest());

        [HttpPost(Name = "CreateTechnology")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateTechnologyResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateTechnologyResponse>> Create([FromBody] CreateTechnologyRequest request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetTechnologiesPage")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTechnologiesPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTechnologiesPageResponse>> Page([FromRoute] GetTechnologiesPageRequest request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateTechnology")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateTechnologyResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateTechnologyResponse>> Update([FromBody] UpdateTechnologyRequest request)
            => await _mediator.Send(request);

        [HttpDelete("{technologyId}", Name = "RemoveTechnology")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveTechnologyResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveTechnologyResponse>> Remove([FromRoute] Guid technologyId)
        {
            return await _mediator.Send(new RemoveTechnologyRequest() {  TechnologyId = technologyId });
        }

    }
}
