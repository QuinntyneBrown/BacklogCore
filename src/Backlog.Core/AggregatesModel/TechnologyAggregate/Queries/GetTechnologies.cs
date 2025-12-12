using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class GetTechnologiesRequest : IRequest<GetTechnologiesResponse> { }

public class GetTechnologiesResponse : ResponseBase
{
    public List<TechnologyDto>? Technologies { get; set; }
}

public class GetTechnologiesHandler : IRequestHandler<GetTechnologiesRequest, GetTechnologiesResponse>
{
    private readonly IBacklogDbContext _context;

    public GetTechnologiesHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetTechnologiesResponse> Handle(GetTechnologiesRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            Technologies = await _context.Technologies.Select(x => x.ToDto()).ToListAsync(cancellationToken)
        };
    }

}
}
