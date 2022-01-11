using System.Net;
using System.Threading.Tasks;
using Backlog.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SprintController
    {
        private readonly IMediator _mediator;

        public SprintController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{sprintId}", Name = "GetSprintByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSprintById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSprintById.Response>> GetById([FromRoute]GetSprintById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Sprint == null)
            {
                return new NotFoundObjectResult(request.SprintId);
            }
        
            return response;
        }

        [HttpPut(Name = "UpdateSprintRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateSprint.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateSprint.Response>> Update([FromBody] UpdateSprint.Request request)
            => await _mediator.Send(request);

        [HttpGet(Name = "GetSprintsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSprints.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSprints.Response>> Get()
            => await _mediator.Send(new GetSprints.Request());

        [HttpGet("story/{storyId}", Name = "GetSprintsByStoryIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSprintsByStoryId.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSprintsByStoryId.Response>> GetSprintsByStoryId([FromRoute] GetSprintsByStoryId.Request request)
            => await _mediator.Send(request);

        [HttpGet("current", Name = "GetCurrentSprintRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCurrentSprint.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCurrentSprint.Response>> GetCurrent()
            => await _mediator.Send(new GetCurrentSprint.Request());

        [HttpPost(Name = "CreateSprintRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateSprint.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateSprint.Response>> Create([FromBody]CreateSprint.Request request)
            => await _mediator.Send(request);

        [HttpPost("story", Name = "AddSprintStoryRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(AddSprintStory.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AddSprintStory.Response>> Create([FromBody] AddSprintStory.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetSprintsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSprintsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSprintsPage.Response>> Page([FromRoute]GetSprintsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{sprintId}", Name = "RemoveSprintRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveSprint.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveSprint.Response>> Remove([FromRoute]RemoveSprint.Request request)
            => await _mediator.Send(request);

    }
}
