using Backlog.Api.Extensions;
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class GetBugsPageRequest : IRequest<GetBugsPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
}

public class GetBugsPageResponse : ResponseBase
{
    public int Length { get; set; }
    public List<BugDto>? Entities { get; set; }
}

public class GetBugsPageHandler : IRequestHandler<GetBugsPageRequest, GetBugsPageResponse>
{
    private readonly IBacklogDbContext _context;

    public GetBugsPageHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetBugsPageResponse> Handle(GetBugsPageRequest request, CancellationToken cancellationToken)
    {
        var query = from bug in _context.Bugs
                    select bug;

        var length = await _context.Bugs.CountAsync();

        var bugs = await query.Page(request.Index, request.PageSize)
            .Select(x => x.ToDto()).ToListAsync();

        return new()
        {
            Length = length,
            Entities = bugs
        };
    }

}