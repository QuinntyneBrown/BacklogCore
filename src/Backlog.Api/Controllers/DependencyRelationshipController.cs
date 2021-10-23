using System.Net;
using System.Threading.Tasks;
using Backlog.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DependencyRelationshipController
    {
        private readonly IMediator _mediator;

        public DependencyRelationshipController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{dependencyRelationshipId}", Name = "GetDependencyRelationshipByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDependencyRelationshipById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDependencyRelationshipById.Response>> GetById([FromRoute]GetDependencyRelationshipById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.DependencyRelationship == null)
            {
                return new NotFoundObjectResult(request.DependencyRelationshipId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetDependencyRelationshipsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDependencyRelationships.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDependencyRelationships.Response>> Get()
            => await _mediator.Send(new GetDependencyRelationships.Request());
        
        [HttpPost(Name = "CreateDependencyRelationshipRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateDependencyRelationship.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateDependencyRelationship.Response>> Create([FromBody]CreateDependencyRelationship.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetDependencyRelationshipsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDependencyRelationshipsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDependencyRelationshipsPage.Response>> Page([FromRoute]GetDependencyRelationshipsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateDependencyRelationshipRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateDependencyRelationship.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateDependencyRelationship.Response>> Update([FromBody]UpdateDependencyRelationship.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{dependencyRelationshipId}", Name = "RemoveDependencyRelationshipRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveDependencyRelationship.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveDependencyRelationship.Response>> Remove([FromRoute]RemoveDependencyRelationship.Request request)
            => await _mediator.Send(request);
        
    }
}
