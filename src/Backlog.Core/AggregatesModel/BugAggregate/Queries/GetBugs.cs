using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class GetBugsRequest : IRequest<GetBugsResponse> { }

public class GetBugsResponse : ResponseBase
{
    public List<BugDto>? Bugs { get; set; }
}

public class GetBugsHandler : IRequestHandler<GetBugsRequest, GetBugsResponse>
{
    private readonly IBacklogDbContext _context;

    public GetBugsHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetBugsResponse> Handle(GetBugsRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            Bugs = await _context.Bugs.Select(x => x.ToDto()).ToListAsync()
        };
    }

}