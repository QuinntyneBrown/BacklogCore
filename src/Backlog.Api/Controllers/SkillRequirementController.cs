using System.Net;
using System.Threading.Tasks;
using Backlog.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillRequirementController
    {
        private readonly IMediator _mediator;

        public SkillRequirementController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{skillRequirementId}", Name = "GetSkillRequirementByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSkillRequirementById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSkillRequirementById.Response>> GetById([FromRoute]GetSkillRequirementById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.SkillRequirement == null)
            {
                return new NotFoundObjectResult(request.SkillRequirementId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetSkillRequirementsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSkillRequirements.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSkillRequirements.Response>> Get()
            => await _mediator.Send(new GetSkillRequirements.Request());
        
        [HttpPost(Name = "CreateSkillRequirementRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateSkillRequirement.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateSkillRequirement.Response>> Create([FromBody]CreateSkillRequirement.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetSkillRequirementsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSkillRequirementsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSkillRequirementsPage.Response>> Page([FromRoute]GetSkillRequirementsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateSkillRequirementRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateSkillRequirement.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateSkillRequirement.Response>> Update([FromBody]UpdateSkillRequirement.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{skillRequirementId}", Name = "RemoveSkillRequirementRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveSkillRequirement.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveSkillRequirement.Response>> Remove([FromRoute]RemoveSkillRequirement.Request request)
            => await _mediator.Send(request);
        
    }
}
