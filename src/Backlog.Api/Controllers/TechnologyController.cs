using Backlog.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{technologyId}", Name = "GetTechnologyByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTechnologyById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTechnologyById.Response>> GetById([FromRoute] GetTechnologyById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Technology == null)
            {
                return new NotFoundObjectResult(request.TechnologyId);
            }

            return response;
        }

        [HttpGet(Name = "GetTechnologiesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTechnologies.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTechnologies.Response>> Get()
            => await _mediator.Send(new GetTechnologies.Request());

        [HttpPost(Name = "CreateTechnologyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateTechnology.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateTechnology.Response>> Create([FromBody] CreateTechnology.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetTechnologiesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTechnologiesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTechnologiesPage.Response>> Page([FromRoute] GetTechnologiesPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateTechnologyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateTechnology.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateTechnology.Response>> Update([FromBody] UpdateTechnology.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{technologyId}", Name = "RemoveTechnologyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveTechnology.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveTechnology.Response>> Remove([FromRoute] RemoveTechnology.Request request)
            => await _mediator.Send(request);

    }
}
