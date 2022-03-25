using Backlog.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{bugId}", Name = "GetBugByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBugByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBugByIdResponse>> GetById([FromRoute] GetBugByIdRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.Bug == null)
            {
                return new NotFoundObjectResult(request.BugId);
            }

            return response;
        }

        [HttpGet(Name = "GetBugsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBugsResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBugsResponse>> Get()
            => await _mediator.Send(new GetBugsRequest());

        [HttpPost(Name = "CreateBugRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateBugResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateBugResponse>> Create([FromBody] CreateBugRequest request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetBugsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBugsPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBugsPageResponse>> Page([FromRoute] GetBugsPageRequest request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateBugRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateBugResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateBugResponse>> Update([FromBody] UpdateBugRequest request)
            => await _mediator.Send(request);

        [HttpDelete("{bugId}", Name = "RemoveBugRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveBugResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveBugResponse>> Remove([FromRoute] RemoveBugRequest request)
            => await _mediator.Send(request);

    }
}
