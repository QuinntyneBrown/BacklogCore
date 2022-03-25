using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetCurrentSprintRequest : IRequest<GetCurrentSprintResponse> { }

    public class GetCurrentSprintResponse : ResponseBase
    {
        public SprintDto? Sprint { get; set; }
    }

    public class GetCurrentSprintHandler : IRequestHandler<GetCurrentSprintRequest, GetCurrentSprintResponse>
    {
        private readonly IBacklogDbContext _context;
        
        public GetCurrentSprintHandler(IBacklogDbContext context)
            => _context = context;
        
        public async Task<GetCurrentSprintResponse> Handle(GetCurrentSprintRequest request, CancellationToken cancellationToken)
        {
            return new () {
                Sprint = (await _context.Sprints
                .Include(x => x.SprintStories)
                .FirstOrDefaultAsync(x => x.Start < DateTime.Now && x.End > DateTime.Now, cancellationToken))?.ToDto()
            };
        }    
    }
}
