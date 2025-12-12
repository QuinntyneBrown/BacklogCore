using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Backlog.Core;
public class RemoveStatusRequest : IRequest<RemoveStatusResponse>
{
    public Guid StatusId { get; set; }
}

public class RemoveStatusResponse : ResponseBase
{
    public StatusDto? Status { get; set; }
}

public class RemoveStatusHandler : IRequestHandler<RemoveStatusRequest, RemoveStatusResponse>
{
    private readonly IBacklogDbContext _context;

    public RemoveStatusHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<RemoveStatusResponse> Handle(RemoveStatusRequest request, CancellationToken cancellationToken)
    {
        var status = await _context.Statuses.SingleAsync(x => x.StatusId == request.StatusId, cancellationToken);

        _context.Statuses.Remove(status);

        await _context.SaveChangesAsync(cancellationToken);

        return new RemoveStatusResponse()
        {
            Status = status.ToDto()
        };
    }

}
}
