using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class GetStatusesRequest : IRequest<GetStatusesResponse> { }

public class GetStatusesResponse : ResponseBase
{
    public List<StatusDto>? Statuses { get; set; }
}

public class GetStatusesHandler : IRequestHandler<GetStatusesRequest, GetStatusesResponse>
{
    private readonly IBacklogDbContext _context;

    public GetStatusesHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetStatusesResponse> Handle(GetStatusesRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            Statuses = await _context.Statuses.Select(x => x.ToDto()).ToListAsync(cancellationToken)
        };
    }

}