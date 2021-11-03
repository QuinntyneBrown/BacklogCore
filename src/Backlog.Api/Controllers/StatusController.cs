using Backlog.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Backlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController
    {
        private readonly IMediator _mediator;

        public StatusController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{statusId}", Name = "GetStatusByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStatusById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStatusById.Response>> GetById([FromRoute] GetStatusById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Status == null)
            {
                return new NotFoundObjectResult(request.StatusId);
            }

            return response;
        }

        [HttpGet(Name = "GetStatusesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStatuses.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStatuses.Response>> Get()
            => await _mediator.Send(new GetStatuses.Request());

        [HttpPost(Name = "CreateStatusRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateStatus.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateStatus.Response>> Create([FromBody] CreateStatus.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetStatusesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStatusesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStatusesPage.Response>> Page([FromRoute] GetStatusesPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateStatusRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateStatus.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateStatus.Response>> Update([FromBody] UpdateStatus.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{statusId}", Name = "RemoveStatusRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveStatus.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveStatus.Response>> Remove([FromRoute] RemoveStatus.Request request)
            => await _mediator.Send(request);

    }
}
