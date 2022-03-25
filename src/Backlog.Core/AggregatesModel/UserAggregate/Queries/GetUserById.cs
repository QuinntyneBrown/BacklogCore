using Backlog.Api.Interfaces;
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
    {
        public Guid UserId { get; set; }
    }

    public class GetUserByIdResponse : ResponseBase
    {
        public UserDto? User { get; set; }
    }

    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IBacklogDbContext _context;

        public GetUserByIdHandler(IBacklogDbContext context)
            => _context = context;

        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            return new()
            {
                User = (await _context.Users.SingleOrDefaultAsync(x => x.UserId == request.UserId))?.ToDto()
            };
        }
    }
}
