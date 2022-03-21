using Backlog.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Backlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompetencyLevelController
    {
        private readonly IMediator _mediator;

        public CompetencyLevelController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{competencyLevelId}", Name = "GetCompetencyLevelByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCompetencyLevelById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCompetencyLevelById.Response>> GetById([FromRoute] GetCompetencyLevelById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.CompetencyLevel == null)
            {
                return new NotFoundObjectResult(request.CompetencyLevelId);
            }

            return response;
        }

        [HttpGet(Name = "GetCompetencyLevelsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCompetencyLevels.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCompetencyLevels.Response>> Get()
            => await _mediator.Send(new GetCompetencyLevels.Request());

        [HttpPost(Name = "CreateCompetencyLevelRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateCompetencyLevel.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateCompetencyLevel.Response>> Create([FromBody] CreateCompetencyLevel.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetCompetencyLevelsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCompetencyLevelsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCompetencyLevelsPage.Response>> Page([FromRoute] GetCompetencyLevelsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateCompetencyLevelRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateCompetencyLevel.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateCompetencyLevel.Response>> Update([FromBody] UpdateCompetencyLevel.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{competencyLevelId}", Name = "RemoveCompetencyLevelRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveCompetencyLevel.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveCompetencyLevel.Response>> Remove([FromRoute] RemoveCompetencyLevel.Request request)
            => await _mediator.Send(request);

    }
}
