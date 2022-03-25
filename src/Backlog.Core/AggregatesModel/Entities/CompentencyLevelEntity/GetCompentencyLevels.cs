using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetCompetencyLevelsRequest : IRequest<GetCompetencyLevelsResponse> { }

    public class GetCompetencyLevelsResponse : ResponseBase
    {
        public List<CompetencyLevelDto>? CompetencyLevels { get; set; }
    }

    public class GetCompetencyLevelsHandler : IRequestHandler<GetCompetencyLevelsRequest, GetCompetencyLevelsResponse>
    {
        private readonly IBacklogDbContext _context;

        public GetCompetencyLevelsHandler(IBacklogDbContext context)
            => _context = context;

        public async Task<GetCompetencyLevelsResponse> Handle(GetCompetencyLevelsRequest request, CancellationToken cancellationToken)
        {
            return new()
            {
                CompetencyLevels = await _context.CompetencyLevels.Select(x => x.ToDto()).ToListAsync(cancellationToken)
            };
        }

    }
    
}
