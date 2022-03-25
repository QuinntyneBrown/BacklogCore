using Backlog.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Backlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemController
    {
        private readonly IMediator _mediator;

        public TaskItemController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{taskItemId}", Name = "GetTaskItemById")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTaskItemByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTaskItemByIdResponse>> GetById([FromRoute] GetTaskItemByIdRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.TaskItem == null)
            {
                return new NotFoundObjectResult(request.TaskItemId);
            }

            return response;
        }

        [HttpGet(Name = "GetTaskItems")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTaskItemsResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTaskItemsResponse>> Get()
            => await _mediator.Send(new GetTaskItemsRequest());

        [HttpPost(Name = "CreateTaskItem")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateTaskItemResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateTaskItemResponse>> Create([FromBody] CreateTaskItemRequest request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetTaskItemsPage")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTaskItemsPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTaskItemsPageResponse>> Page([FromRoute] GetTaskItemsPageRequest request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateTaskItem")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateTaskItemResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateTaskItemResponse>> Update([FromBody] UpdateTaskItemRequest request)
            => await _mediator.Send(request);

        [HttpDelete("{taskItemId}", Name = "RemoveTaskItem")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveTaskItemResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveTaskItemResponse>> Remove([FromRoute] RemoveTaskItemRequest request)
            => await _mediator.Send(request);

    }
}
