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
    public class BugController
    {
        private readonly IMediator _mediator;

        public BugController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{bugId}", Name = "GetBugById")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBugByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBugByIdResponse>> GetById([FromRoute] Guid bugId)
        {
            var request = new GetBugByIdRequest {  BugId = bugId };

            var response = await _mediator.Send(request);

            if (response.Bug == null)
            {
                return new NotFoundObjectResult(request.BugId);
            }

            return response;
        }

        [HttpGet(Name = "GetBugs")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBugsResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBugsResponse>> Get()
            => await _mediator.Send(new GetBugsRequest());

        [HttpPost(Name = "CreateBug")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateBugResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateBugResponse>> Create([FromBody] CreateBugRequest request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetBugsPage")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBugsPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBugsPageResponse>> Page([FromRoute] int pageSize, [FromRoute] int index)
        {
            var request = new GetBugsPageRequest { Index = index, PageSize = pageSize };

            return await _mediator.Send(request);
        }

        [HttpPut(Name = "UpdateBug")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateBugResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateBugResponse>> Update([FromBody] UpdateBugRequest request)
            => await _mediator.Send(request);

        [HttpDelete("{bugId}", Name = "RemoveBug")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveBugResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveBugResponse>> Remove([FromRoute] Guid bugId)
        {
            var request = new RemoveBugRequest {  BugId = bugId };

            return await _mediator.Send(request);
        }

    }
}
