using Backlog.Api.Extensions;
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class GetDigitalAssetsPageRequest : IRequest<GetDigitalAssetsPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
}

public class GetDigitalAssetsPageResponse : ResponseBase
{
    public int Length { get; set; }
    public List<DigitalAssetDto>? Entities { get; set; }
}

public class GetDigitalAssetsPageHandler : IRequestHandler<GetDigitalAssetsPageRequest, GetDigitalAssetsPageResponse>
{
    private readonly IBacklogDbContext _context;

    public GetDigitalAssetsPageHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetDigitalAssetsPageResponse> Handle(GetDigitalAssetsPageRequest request, CancellationToken cancellationToken)
    {
        var query = from digitalAsset in _context.DigitalAssets
                    select digitalAsset;

        var length = await _context.DigitalAssets.CountAsync();

        var digitalAssets = await query.Page(request.Index, request.PageSize)
            .Select(x => x.ToDto()).ToListAsync();

        return new()
        {
            Length = length,
            Entities = digitalAssets
        };
    }

}