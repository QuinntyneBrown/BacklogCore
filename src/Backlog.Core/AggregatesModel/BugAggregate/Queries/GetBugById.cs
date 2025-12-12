using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;

public class GetBugByIdRequest : IRequest<GetBugByIdResponse>
{
    public Guid BugId { get; set; }
}

public class GetBugByIdResponse : ResponseBase
{
    public BugDto? Bug { get; set; }
}

public class GetBugByIdHandler : IRequestHandler<GetBugByIdRequest, GetBugByIdResponse>
{
    private readonly IBacklogDbContext _context;

    public GetBugByIdHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetBugByIdResponse> Handle(GetBugByIdRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            Bug = (await _context.Bugs.SingleOrDefaultAsync(x => x.BugId == request.BugId))?.ToDto()
        };
    }

}
}
