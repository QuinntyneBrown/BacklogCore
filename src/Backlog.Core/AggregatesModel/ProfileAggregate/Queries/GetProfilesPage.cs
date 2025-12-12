using Backlog.Api.Extensions;
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class GetProfilesPageRequest : IRequest<GetProfilesPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
}

public class GetProfilesPageResponse : ResponseBase
{
    public int Length { get; set; }
    public List<ProfileDto>? Entities { get; set; }
}

public class GetProfilesPageHandler : IRequestHandler<GetProfilesPageRequest, GetProfilesPageResponse>
{
    private readonly IBacklogDbContext _context;

    public GetProfilesPageHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetProfilesPageResponse> Handle(GetProfilesPageRequest request, CancellationToken cancellationToken)
    {
        var query = from profile in _context.Profiles
                    select profile;

        var length = await _context.Profiles.CountAsync(cancellationToken);

        var profiles = await query.Page(request.Index, request.PageSize)
            .Select(x => x.ToDto()).ToListAsync();

        return new()
        {
            Length = length,
            Entities = profiles
        };
    }
}
}
