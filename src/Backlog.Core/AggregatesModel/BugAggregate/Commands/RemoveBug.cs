using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class RemoveBugRequest : IRequest<RemoveBugResponse>
    {
        public Guid BugId { get; set; }
    }

    public class RemoveBugResponse : ResponseBase
    {
        public BugDto Bug { get; set; }

        public RemoveBugResponse(BugDto bug)
        {
            Bug = bug;
        }
    }

    public class RemoveBugHandler : IRequestHandler<RemoveBugRequest, RemoveBugResponse>
    {
        private readonly IBacklogDbContext _context;

        public RemoveBugHandler(IBacklogDbContext context)
            => _context = context;

        public async Task<RemoveBugResponse> Handle(RemoveBugRequest request, CancellationToken cancellationToken)
        {
            var bug = await _context.Bugs.SingleAsync(x => x.BugId == request.BugId, cancellationToken);

            _context.Bugs.Remove(bug);

            await _context.SaveChangesAsync(cancellationToken);

            return new (bug.ToDto());
        }
    }
}
