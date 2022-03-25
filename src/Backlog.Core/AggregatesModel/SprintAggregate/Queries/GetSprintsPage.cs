using Backlog.Api.Extensions;
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetSprintsPageRequest : IRequest<GetSprintsPageResponse>
    {
        public int PageSize { get; set; }
        public int Index { get; set; }
    }

    public class GetSprintsPageResponse : ResponseBase
    {
        public int Length { get; set; }
        public List<SprintDto>? Entities { get; set; }
    }

    public class GetSprintsPageHandler : IRequestHandler<GetSprintsPageRequest, GetSprintsPageResponse>
    {
        private readonly IBacklogDbContext _context;
        
        public GetSprintsPageHandler(IBacklogDbContext context)
            => _context = context;
        
        public async Task<GetSprintsPageResponse> Handle(GetSprintsPageRequest request, CancellationToken cancellationToken)
        {
            var query = from sprint in _context.Sprints
                select sprint;
                
            var length = await _context.Sprints.CountAsync();
                
            var sprints = await query.Page(request.Index, request.PageSize)
                .Select(x => x.ToDto()).ToListAsync(cancellationToken);
                
            return new()
            {
                Length = length,
                Entities = sprints
            };
        }
            
    }

}
