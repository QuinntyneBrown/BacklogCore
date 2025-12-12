using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;

public class GetStatusByIdRequest : IRequest<GetStatusByIdResponse>
{
    public Guid StatusId { get; set; }
}

public class GetStatusByIdResponse : ResponseBase
{
    public StatusDto? Status { get; set; }
}

public class GetStatusByIdHandler : IRequestHandler<GetStatusByIdRequest, GetStatusByIdResponse>
{
    private readonly IBacklogDbContext _context;

    public GetStatusByIdHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetStatusByIdResponse> Handle(GetStatusByIdRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            Status = (await _context.Statuses.SingleOrDefaultAsync(x => x.StatusId == request.StatusId, cancellationToken))?.ToDto()
        };
    }
}