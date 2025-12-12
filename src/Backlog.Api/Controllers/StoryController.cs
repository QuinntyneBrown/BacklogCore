using Backlog.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Backlog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoryController
{
    private readonly IMediator _mediator;

    public StoryController(IMediator mediator)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        _mediator = mediator;
    }


    [HttpGet("search/{query}", Name = "SearchStories")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(SearchStoriesResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<SearchStoriesResponse>> SearchStories([FromRoute] string query)
    {
        var request = new SearchStoriesRequest { Query = query };

        return await _mediator.Send(request);
    }


    [HttpGet("{storyId}", Name = "GetStoryById")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetStoryByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetStoryByIdResponse>> GetById([FromRoute] Guid storyId)
    {
        var request = new GetStoryByIdRequest { StoryId = storyId };

        var response = await _mediator.Send(request);

        if (response.Story == null)
        {
            return new NotFoundObjectResult(request.StoryId);
        }

        return response;
    }

    [HttpGet(Name = "GetStories")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetStoriesResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetStoriesResponse>> Get()
        => await _mediator.Send(new GetStoriesRequest());

    [HttpPost(Name = "CreateStory")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CreateStoryResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateStoryResponse>> Create([FromBody] CreateStoryRequest request)
        => await _mediator.Send(request);

    [HttpPost("skill-requirement", Name = "AddStorySkillRequirement")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(AddStorySkillRequirementResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<AddStorySkillRequirementResponse>> AddStorySkillRequirement([FromBody] AddStorySkillRequirementRequest request)
        => await _mediator.Send(request);

    [HttpPut("depends-on", Name = "UpdateStoryDependsOn")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateStoryDependsOnResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateStoryDependsOnResponse>> UpdateStoryDependsOn([FromBody] UpdateStoryDependsOnRequest request)
        => await _mediator.Send(request);

    [HttpPut("status", Name = "UpdateStoryStatus")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateStoryStatusResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateStoryStatusResponse>> UpdateStoryStatus([FromBody] UpdateStoryStatusRequest request)
        => await _mediator.Send(request);

    [HttpGet("page/{pageSize}/{index}", Name = "GetStoriesPage")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetStoriesPageResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetStoriesPageResponse>> Page([FromRoute] int pageSize, [FromRoute] int index)
    {
        var request = new GetStoriesPageRequest { Index = index, PageSize = pageSize };

        return await _mediator.Send(request);
    }



    [HttpPut(Name = "UpdateStory")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateStoryDescriptionResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateStoryResponse>> Update([FromBody] UpdateStoryRequest request)
        => await _mediator.Send(request);

    [HttpPut("jira", Name = "UpdateStoryJiraUrl")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateStoryJiraUrlResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateStoryJiraUrlResponse>> UpdateJiraUrl([FromBody] UpdateStoryJiraUrlRequest request)
        => await _mediator.Send(request);

    [HttpDelete("{storyId}", Name = "RemoveStory")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(RemoveStoryResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<RemoveStoryResponse>> Remove([FromRoute] Guid storyId)
    {
        var request = new RemoveStoryRequest { StoryId = storyId };

        return await _mediator.Send(request);
    }        
}
