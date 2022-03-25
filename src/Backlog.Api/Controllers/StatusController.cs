using Backlog.Core;
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
        [ProducesResponseType(typeof(GetStatusByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStatusByIdResponse>> GetById([FromRoute] GetStatusByIdRequest request)
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
        [ProducesResponseType(typeof(GetStatusesResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStatusesResponse>> Get()
            => await _mediator.Send(new GetStatusesRequest());

        [HttpPost(Name = "CreateStatusRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateStatusResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateStatusResponse>> Create([FromBody] CreateStatusRequest request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetStatusesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStatusesPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStatusesPageResponse>> Page([FromRoute] GetStatusesPageRequest request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateStatusRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateStatusResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateStatusResponse>> Update([FromBody] UpdateStatusRequest request)
            => await _mediator.Send(request);

        [HttpDelete("{statusId}", Name = "RemoveStatusRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveStatusResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveStatusResponse>> Remove([FromRoute] RemoveStatusRequest request)
            => await _mediator.Send(request);

    }
}
