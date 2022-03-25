using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class RemoveSprintRequest : IRequest<RemoveSprintResponse>
    {
        public Guid SprintId { get; set; }
    }

    public class RemoveSprintResponse : ResponseBase
    {
        public SprintDto? Sprint { get; set; }
    }

    public class RemoveSprintHandler : IRequestHandler<RemoveSprintRequest, RemoveSprintResponse>
    {
        private readonly IBacklogDbContext _context;
        
        public RemoveSprintHandler(IBacklogDbContext context)
            => _context = context;
        
        public async Task<RemoveSprintResponse> Handle(RemoveSprintRequest request, CancellationToken cancellationToken)
        {
            var sprint = await _context.Sprints.SingleAsync(x => x.SprintId == request.SprintId);
                
            _context.Sprints.Remove(sprint);
                
            await _context.SaveChangesAsync(cancellationToken);
                
            return new ()
            {
                Sprint = sprint.ToDto()
            };
        }
            
    }
}
