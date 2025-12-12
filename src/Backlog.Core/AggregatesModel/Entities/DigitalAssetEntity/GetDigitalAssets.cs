using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;

public class GetDigitalAssetsRequest : IRequest<GetDigitalAssetsResponse> { }

public class GetDigitalAssetsResponse : ResponseBase
{
    public List<DigitalAssetDto>? DigitalAssets { get; set; }
}

public class GetDigitalAssetsHandler : IRequestHandler<GetDigitalAssetsRequest, GetDigitalAssetsResponse>
{
    private readonly IBacklogDbContext _context;

    public GetDigitalAssetsHandler(IBacklogDbContext context)
        => _context = context;
    public async Task<GetDigitalAssetsResponse> Handle(GetDigitalAssetsRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            DigitalAssets = await _context.DigitalAssets.Select(x => x.ToDto()).ToListAsync(cancellationToken)
        };
    }

}