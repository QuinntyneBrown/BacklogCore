using System.Net;
using System.Threading.Tasks;
using Backlog.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        [ProducesResponseType(typeof(GetBugById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBugById.Response>> GetById([FromRoute] GetBugById.Request request)
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
        [ProducesResponseType(typeof(GetBugs.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBugs.Response>> Get()
            => await _mediator.Send(new GetBugs.Request());

        [HttpPost(Name = "CreateBugRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateBug.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateBug.Response>> Create([FromBody] CreateBug.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetBugsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBugsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBugsPage.Response>> Page([FromRoute] GetBugsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateBugRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateBug.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateBug.Response>> Update([FromBody] UpdateBug.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{bugId}", Name = "RemoveBugRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveBug.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveBug.Response>> Remove([FromRoute] RemoveBug.Request request)
            => await _mediator.Send(request);

    }
}
