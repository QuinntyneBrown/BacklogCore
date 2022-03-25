using Backlog.Api.Interfaces;
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetUsersRequest : IRequest<GetUsersResponse> { }

    public class GetUsersResponse : ResponseBase
    {
        public List<UserDto>? Users { get; set; }
    }

    public class Handler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IBacklogDbContext _context;

        public Handler(IBacklogDbContext context)
            => _context = context;

        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            return new()
            {
                Users = await _context.Users.Select(x => x.ToDto()).ToListAsync(cancellationToken)
            };
        }
    }
}
