using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;

public class RemoveProfileRequest : IRequest<RemoveProfileResponse>
{
    public Guid ProfileId { get; set; }
}

public class RemoveProfileResponse : ResponseBase
{
    public ProfileDto Profile { get; set; }

    public RemoveProfileResponse(ProfileDto profile)
    {
        Profile = profile;
    }
}

public class RemoveProfileHandler : IRequestHandler<RemoveProfileRequest, RemoveProfileResponse>
{
    private readonly IBacklogDbContext _context;

    public RemoveProfileHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<RemoveProfileResponse> Handle(RemoveProfileRequest request, CancellationToken cancellationToken)
    {
        var profile = await _context.Profiles.SingleAsync(x => x.ProfileId == request.ProfileId);

        _context.Profiles.Remove(profile);

        await _context.SaveChangesAsync(cancellationToken);

        return new (profile.ToDto());
    }
}