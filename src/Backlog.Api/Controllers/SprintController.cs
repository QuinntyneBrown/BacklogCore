using System.Net;
using System.Threading.Tasks;
using Backlog.Core;
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

        [HttpGet("{sprintId}", Name = "GetSprintById")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSprintByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSprintByIdResponse>> GetById([FromRoute]GetSprintByIdRequest request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Sprint == null)
            {
                return new NotFoundObjectResult(request.SprintId);
            }
        
            return response;
        }

        [HttpPut(Name = "UpdateSprint")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateSprintResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateSprintResponse>> Update([FromBody] UpdateSprintRequest request)
            => await _mediator.Send(request);

        [HttpGet(Name = "GetSprints")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSprintsResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSprintsResponse>> Get()
            => await _mediator.Send(new GetSprintsRequest());

        [HttpGet("story/{storyId}", Name = "GetSprintsByStoryId")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSprintsByStoryIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSprintsByStoryIdResponse>> GetSprintsByStoryId([FromRoute] GetSprintsByStoryIdRequest request)
            => await _mediator.Send(request);

        [HttpGet("current", Name = "GetCurrentSprint")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCurrentSprintResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCurrentSprintResponse>> GetCurrent()
            => await _mediator.Send(new GetCurrentSprintRequest());

        [HttpPost(Name = "CreateSprint")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateSprintResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateSprintResponse>> Create([FromBody]CreateSprintRequest request)
            => await _mediator.Send(request);

        [HttpPost("story", Name = "AddSprintStory")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(AddSprintStoryResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AddSprintStoryResponse>> Create([FromBody] AddSprintStoryRequest request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetSprintsPage")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSprintsPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSprintsPageResponse>> Page([FromRoute]GetSprintsPageRequest request)
            => await _mediator.Send(request);
        
        [HttpDelete("{sprintId}", Name = "RemoveSprint")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveSprintResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveSprintResponse>> Remove([FromRoute]RemoveSprintRequest request)
            => await _mediator.Send(request);

    }
}
