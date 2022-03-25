using Backlog.SharedKernel;
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class RemoveUserRequest : IRequest<RemoveUserResponse>
    {
        public Guid UserId { get; set; }
    }

    public class RemoveUserResponse : ResponseBase
    {
        public UserDto? User { get; set; }
    }

    public class RemoveUserHandler : IRequestHandler<RemoveUserRequest, RemoveUserResponse>
    {
        private readonly IBacklogDbContext _context;

        public RemoveUserHandler(IBacklogDbContext context)
            => _context = context;

        public async Task<RemoveUserResponse> Handle(RemoveUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleAsync(x => x.UserId == request.UserId);

            _context.Users.Remove(user);

            await _context.SaveChangesAsync(cancellationToken);

            return new RemoveUserResponse()
            {
                User = user.ToDto()
            };
        }

    }
}
