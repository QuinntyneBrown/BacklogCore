using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetSprintsRequest : IRequest<GetSprintsResponse> { }

    public class GetSprintsResponse : ResponseBase
    {
        public List<SprintDto>? Sprints { get; set; }
    }

    public class GetSprintsHandler : IRequestHandler<GetSprintsRequest, GetSprintsResponse>
    {
        private readonly IBacklogDbContext _context;
        
        public GetSprintsHandler(IBacklogDbContext context)
            => _context = context;
        
        public async Task<GetSprintsResponse> Handle(GetSprintsRequest request, CancellationToken cancellationToken)
        {
            return new () {
                Sprints = await _context.Sprints.Select(x => x.ToDto()).ToListAsync(cancellationToken)
            };
        }
            
    }

}
