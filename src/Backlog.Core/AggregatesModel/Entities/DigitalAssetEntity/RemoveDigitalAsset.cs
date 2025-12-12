using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class RemoveDigitalAssetRequest : IRequest<RemoveDigitalAssetResponse>
{
    public Guid DigitalAssetId { get; set; }
}

public class RemoveDigitalAssetResponse : ResponseBase
{
    public DigitalAssetDto? DigitalAsset { get; set; }
}

public class RemoveDigitalAssetHandler : IRequestHandler<RemoveDigitalAssetRequest, RemoveDigitalAssetResponse>
{
    private readonly IBacklogDbContext _context;

    public RemoveDigitalAssetHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<RemoveDigitalAssetResponse> Handle(RemoveDigitalAssetRequest request, CancellationToken cancellationToken)
    {
        var digitalAsset = await _context.DigitalAssets.SingleAsync(x => x.DigitalAssetId == request.DigitalAssetId);

        _context.DigitalAssets.Remove(digitalAsset);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            DigitalAsset = digitalAsset.ToDto()
        };
    }

}

}
