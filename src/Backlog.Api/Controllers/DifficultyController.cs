using System.Net;
using System.Threading.Tasks;
using Backlog.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DifficultyController
    {
        private readonly IMediator _mediator;

        public DifficultyController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{difficultyId}", Name = "GetDifficultyByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDifficultyById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDifficultyById.Response>> GetById([FromRoute]GetDifficultyById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Difficulty == null)
            {
                return new NotFoundObjectResult(request.DifficultyId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetDifficultiesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDifficulties.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDifficulties.Response>> Get()
            => await _mediator.Send(new GetDifficulties.Request());
        
        [HttpPost(Name = "CreateDifficultyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateDifficulty.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateDifficulty.Response>> Create([FromBody]CreateDifficulty.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetDifficultiesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDifficultiesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDifficultiesPage.Response>> Page([FromRoute]GetDifficultiesPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateDifficultyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateDifficulty.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateDifficulty.Response>> Update([FromBody]UpdateDifficulty.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{difficultyId}", Name = "RemoveDifficultyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveDifficulty.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveDifficulty.Response>> Remove([FromRoute]RemoveDifficulty.Request request)
            => await _mediator.Send(request);
        
    }
}
