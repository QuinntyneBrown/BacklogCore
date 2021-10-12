using System.Net;
using System.Threading.Tasks;
using Backlog.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoryStatusController
    {
        private readonly IMediator _mediator;

        public StoryStatusController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{storyStatusId}", Name = "GetStoryStatusByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStoryStatusById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStoryStatusById.Response>> GetById([FromRoute] GetStoryStatusById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.StoryStatus == null)
            {
                return new NotFoundObjectResult(request.StoryStatusId);
            }

            return response;
        }

        [HttpGet(Name = "GetStoryStatusesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStoryStatuses.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStoryStatuses.Response>> Get()
            => await _mediator.Send(new GetStoryStatuses.Request());

        [HttpPost(Name = "CreateStoryStatusRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateStoryStatus.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateStoryStatus.Response>> Create([FromBody] CreateStoryStatus.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetStoryStatusesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStoryStatusesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStoryStatusesPage.Response>> Page([FromRoute] GetStoryStatusesPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateStoryStatusRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateStoryStatus.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateStoryStatus.Response>> Update([FromBody] UpdateStoryStatus.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{storyStatusId}", Name = "RemoveStoryStatusRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveStoryStatus.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveStoryStatus.Response>> Remove([FromRoute] RemoveStoryStatus.Request request)
            => await _mediator.Send(request);

    }
}
