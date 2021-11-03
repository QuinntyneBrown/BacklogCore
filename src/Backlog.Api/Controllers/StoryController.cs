using Backlog.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Backlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoryController
    {
        private readonly IMediator _mediator;

        public StoryController(IMediator mediator)
            => _mediator = mediator;


        [HttpGet("search/{query}", Name = "SearchStoriesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(SearchStories.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SearchStories.Response>> SearchStories([FromRoute] SearchStories.Request request)
            => await _mediator.Send(request);


        [HttpGet("{storyId}", Name = "GetStoryByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStoryById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStoryById.Response>> GetById([FromRoute] GetStoryById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Story == null)
            {
                return new NotFoundObjectResult(request.StoryId);
            }

            return response;
        }

        [HttpGet(Name = "GetStoriesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStories.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStories.Response>> Get()
            => await _mediator.Send(new GetStories.Request());

        [HttpPost(Name = "CreateStoryRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateStory.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateStory.Response>> Create([FromBody] CreateStory.Request request)
            => await _mediator.Send(request);

        [HttpPost("skill-requirement", Name = "AddStorySkillRequirementRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(AddStorySkillRequirement.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AddStorySkillRequirement.Response>> AddStorySkillRequirement([FromBody] AddStorySkillRequirement.Request request)
            => await _mediator.Send(request);

        [HttpPut("depends-on", Name = "UpdateStoryDependsOnRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateStoryDependsOn.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateStoryDependsOn.Response>> UpdateStoryDependsOn([FromBody] UpdateStoryDependsOn.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetStoriesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStoriesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStoriesPage.Response>> Page([FromRoute] GetStoriesPage.Request request)
            => await _mediator.Send(request);



        [HttpPut(Name = "UpdateStoryRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateStoryDescription.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateStory.Response>> Update([FromBody] UpdateStory.Request request)
            => await _mediator.Send(request);

        [HttpPut("jira", Name = "UpdateStoryJiraUrlRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateStoryJiraUrl.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateStoryJiraUrl.Response>> UpdateJiraUrl([FromBody] UpdateStoryJiraUrl.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{storyId}", Name = "RemoveStoryRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveStory.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveStory.Response>> Remove([FromRoute] RemoveStory.Request request)
            => await _mediator.Send(request);

    }
}
