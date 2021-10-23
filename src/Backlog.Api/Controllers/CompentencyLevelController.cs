using System.Net;
using System.Threading.Tasks;
using Backlog.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompentencyLevelController
    {
        private readonly IMediator _mediator;

        public CompentencyLevelController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{compentencyLevelId}", Name = "GetCompentencyLevelByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCompentencyLevelById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCompentencyLevelById.Response>> GetById([FromRoute]GetCompentencyLevelById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.CompentencyLevel == null)
            {
                return new NotFoundObjectResult(request.CompentencyLevelId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetCompentencyLevelsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCompentencyLevels.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCompentencyLevels.Response>> Get()
            => await _mediator.Send(new GetCompentencyLevels.Request());
        
        [HttpPost(Name = "CreateCompentencyLevelRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateCompentencyLevel.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateCompentencyLevel.Response>> Create([FromBody]CreateCompentencyLevel.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetCompentencyLevelsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCompentencyLevelsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCompentencyLevelsPage.Response>> Page([FromRoute]GetCompentencyLevelsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateCompentencyLevelRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateCompentencyLevel.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateCompentencyLevel.Response>> Update([FromBody]UpdateCompentencyLevel.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{compentencyLevelId}", Name = "RemoveCompentencyLevelRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveCompentencyLevel.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveCompentencyLevel.Response>> Remove([FromRoute]RemoveCompentencyLevel.Request request)
            => await _mediator.Send(request);
        
    }
}
