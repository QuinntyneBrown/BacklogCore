using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class GetTechnologyByIdRequest : IRequest<GetTechnologyByIdResponse>
{
    public Guid TechnologyId { get; set; }
}

public class GetTechnologyByIdResponse : ResponseBase
{
    public TechnologyDto? Technology { get; set; }
}

public class GetTechnologyByIdHandler : IRequestHandler<GetTechnologyByIdRequest, GetTechnologyByIdResponse>
{
    private readonly IBacklogDbContext _context;

    public GetTechnologyByIdHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetTechnologyByIdResponse> Handle(GetTechnologyByIdRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            Technology = (await _context.Technologies.SingleOrDefaultAsync(x => x.TechnologyId == request.TechnologyId, cancellationToken))?.ToDto()
        };
    }

}