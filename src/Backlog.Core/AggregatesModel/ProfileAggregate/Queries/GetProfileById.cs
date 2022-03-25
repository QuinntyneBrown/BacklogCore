using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetProfileByIdRequest : IRequest<GetProfileByIdResponse>
    {
        public Guid ProfileId { get; set; }
    }

    public class GetProfileByIdResponse : ResponseBase
    {
        public ProfileDto? Profile { get; set; }
    }

    public class GetProfileByIdHandler : IRequestHandler<GetProfileByIdRequest, GetProfileByIdResponse>
    {
        private readonly IBacklogDbContext _context;

        public GetProfileByIdHandler(IBacklogDbContext context)
            => _context = context;

        public async Task<GetProfileByIdResponse> Handle(GetProfileByIdRequest request, CancellationToken cancellationToken)
        {
            return new()
            {
                Profile = (await _context.Profiles.SingleOrDefaultAsync(x => x.ProfileId == request.ProfileId, cancellationToken))?.ToDto()
            };
        }
    }
}
