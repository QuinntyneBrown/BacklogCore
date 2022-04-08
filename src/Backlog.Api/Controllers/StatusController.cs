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
    public class StatusController
    {
        private readonly IMediator _mediator;

        public StatusController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{statusId}", Name = "GetStatusById")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStatusByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStatusByIdResponse>> GetById([FromRoute]Guid statusId)
        {
            var request = new GetStatusByIdRequest { StatusId = statusId };

            var response = await _mediator.Send(request);

            if (response.Status == null)
            {
                return new NotFoundObjectResult(request.StatusId);
            }

            return response;
        }

        [HttpGet(Name = "GetStatuses")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStatusesResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStatusesResponse>> Get()
            => await _mediator.Send(new GetStatusesRequest());

        [HttpPost(Name = "CreateStatus")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateStatusResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateStatusResponse>> Create([FromBody] CreateStatusRequest request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetStatusesPage")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStatusesPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStatusesPageResponse>> Page([FromRoute] int pageSize, [FromRoute] int index)
        {
            var request = new GetStatusesPageRequest { Index = index, PageSize = pageSize };

            return await _mediator.Send(request);
        }

        [HttpPut(Name = "UpdateStatus")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateStatusResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateStatusResponse>> Update([FromBody] UpdateStatusRequest request)
            => await _mediator.Send(request);

        [HttpDelete("{statusId}", Name = "RemoveStatus")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveStatusResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveStatusResponse>> Remove([FromRoute] Guid statusId)
        {
            var request = new RemoveStatusRequest { StatusId = statusId };

            return await _mediator.Send(request);
        }
    }
}
