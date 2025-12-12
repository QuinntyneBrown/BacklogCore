using Backlog.Api.Extensions;
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;

public class GetStatusesPageRequest : IRequest<GetStatusesPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
}

public class GetStatusesPageResponse : ResponseBase
{
    public int Length { get; set; }
    public List<StatusDto>? Entities { get; set; }
}

public class GetStatusesPageHandler : IRequestHandler<GetStatusesPageRequest, GetStatusesPageResponse>
{
    private readonly IBacklogDbContext _context;

    public GetStatusesPageHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetStatusesPageResponse> Handle(GetStatusesPageRequest request, CancellationToken cancellationToken)
    {
        var query = from status in _context.Statuses
                    select status;

        var length = await _context.Statuses.CountAsync(cancellationToken);

        var statuses = await query.Page(request.Index, request.PageSize)
            .Select(x => x.ToDto()).ToListAsync();

        return new()
        {
            Length = length,
            Entities = statuses
        };
    }

}