using System.Net;
using System.Threading.Tasks;
using Backlog.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemController
    {
        private readonly IMediator _mediator;

        public TaskItemController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{taskItemId}", Name = "GetTaskItemByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTaskItemById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTaskItemById.Response>> GetById([FromRoute] GetTaskItemById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.TaskItem == null)
            {
                return new NotFoundObjectResult(request.TaskItemId);
            }

            return response;
        }

        [HttpGet(Name = "GetTaskItemsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTaskItems.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTaskItems.Response>> Get()
            => await _mediator.Send(new GetTaskItems.Request());

        [HttpPost(Name = "CreateTaskItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateTaskItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateTaskItem.Response>> Create([FromBody] CreateTaskItem.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetTaskItemsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTaskItemsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTaskItemsPage.Response>> Page([FromRoute] GetTaskItemsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateTaskItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateTaskItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateTaskItem.Response>> Update([FromBody] UpdateTaskItem.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{taskItemId}", Name = "RemoveTaskItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveTaskItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveTaskItem.Response>> Remove([FromRoute] RemoveTaskItem.Request request)
            => await _mediator.Send(request);

    }
}
