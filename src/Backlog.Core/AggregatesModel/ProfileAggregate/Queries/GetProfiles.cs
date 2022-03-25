using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetProfilesRequest : IRequest<GetProfilesResponse> { }

    public class GetProfilesResponse : ResponseBase
    {
        public List<ProfileDto>? Profiles { get; set; }
    }

    public class GetProfilesHandler : IRequestHandler<GetProfilesRequest, GetProfilesResponse>
    {
        private readonly IBacklogDbContext _context;

        public GetProfilesHandler(IBacklogDbContext context)
            => _context = context;

        public async Task<GetProfilesResponse> Handle(GetProfilesRequest request, CancellationToken cancellationToken)
        {
            return new()
            {
                Profiles = await _context.Profiles.Select(x => x.ToDto()).ToListAsync()
            };
        }
    }
}
