using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;

public class RemoveTechnologyRequest : IRequest<RemoveTechnologyResponse>
{
    public Guid TechnologyId { get; set; }
}

public class RemoveTechnologyResponse : ResponseBase
{
    public TechnologyDto? Technology { get; set; }
}

public class RemoveTechnologyHandler : IRequestHandler<RemoveTechnologyRequest, RemoveTechnologyResponse>
{
    private readonly IBacklogDbContext _context;

    public RemoveTechnologyHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<RemoveTechnologyResponse> Handle(RemoveTechnologyRequest request, CancellationToken cancellationToken)
    {
        var technology = await _context.Technologies.SingleAsync(x => x.TechnologyId == request.TechnologyId);

        _context.Technologies.Remove(technology);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Technology = technology.ToDto()
        };
    }

}