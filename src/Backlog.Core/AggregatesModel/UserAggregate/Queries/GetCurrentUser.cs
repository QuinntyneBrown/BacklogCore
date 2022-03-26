using Backlog.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backlog.Core
{
    public class GetCurrentUserRequest: IRequest<GetCurrentUserResponse> { }

    public class GetCurrentUserResponse
    {
        public UserDto? User { get; set; }
    }

    public class GetCurrentUserHandler : IRequestHandler<GetCurrentUserRequest, GetCurrentUserResponse>
    {
        private readonly IBacklogDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetCurrentUserHandler(IBacklogDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<GetCurrentUserResponse> Handle(GetCurrentUserRequest request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext.User.Identity ==  null || !_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return new ();
            }

            var userId = new Guid(_httpContextAccessor.HttpContext.User.FindFirst(SharedKernelConstants.ClaimTypes.UserId).Value);

            User user = _context.Users
                .Single(x => x.UserId == userId);

            return new()
            {
                User = user.ToDto()
            };
        }
    }
}
