using System.Net;
using System.Threading.Tasks;
using Backlog.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{userId}", Name = "GetUserByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetUserByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetUserByIdResponse>> GetById([FromRoute]GetUserByIdRequest request)
        {
            var response = await _mediator.Send(request);
        
            if (response.User == null)
            {
                return new NotFoundObjectResult(request.UserId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetUsersRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetUsersResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetUsersResponse>> Get()
            => await _mediator.Send(new GetUsersRequest());
        
        [HttpPost(Name = "CreateUserRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateUserResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateUserResponse>> Create([FromBody]CreateUserRequest request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetUsersPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetUsersPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetUsersPageResponse>> Page([FromRoute]GetUsersPageRequest request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateUserRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateUserResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateUserResponse>> Update([FromBody]UpdateUserRequest request)
            => await _mediator.Send(request);
        
        [HttpDelete("{userId}", Name = "RemoveUserRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveUserResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveUserResponse>> Remove([FromRoute]RemoveUserRequest request)
            => await _mediator.Send(request);

        [AllowAnonymous]
        [HttpPost("token", Name = "AuthenticateRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(AuthenticateResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate([FromBody] AuthenticateRequest request)
            => await _mediator.Send(request);

    }
}
