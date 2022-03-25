using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{

    public class GetDigitalAssetsByIdsRequest : IRequest<GetDigitalAssetsByIdsResponse>
    {
        public Guid[]? DigitalAssetIds { get; init; }
    }

    public class GetDigitalAssetsByIdsResponse
    {
        public List<DigitalAssetDto>? DigitalAssets { get; set; }
    }

    public class GetDigitalAssetsByIdsHandler : IRequestHandler<GetDigitalAssetsByIdsRequest, GetDigitalAssetsByIdsResponse>
    {
        public IBacklogDbContext _context { get; init; }
        public GetDigitalAssetsByIdsHandler(IBacklogDbContext context) => _context = context;

        public async Task<GetDigitalAssetsByIdsResponse> Handle(GetDigitalAssetsByIdsRequest request, CancellationToken cancellationToken)
            => new ()
            {
                DigitalAssets = await _context.DigitalAssets
                .Where(x => request.DigitalAssetIds.Contains(x.DigitalAssetId))
                .Select(x => x.ToDto())
                .ToListAsync()
            };
    }
}