using Backlog.Api.Extensions;
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{

    public class GetCompetencyLevelsPageRequest : IRequest<GetCompetencyLevelsPageResponse>
    {
        public int PageSize { get; set; }
        public int Index { get; set; }
    }

    public class GetCompetencyLevelsPageResponse : ResponseBase
    {
        public int Length { get; set; }
        public List<CompetencyLevelDto>? Entities { get; set; }
    }

    public class GetCompetencyLevelsPageHandler : IRequestHandler<GetCompetencyLevelsPageRequest, GetCompetencyLevelsPageResponse>
    {
        private readonly IBacklogDbContext _context;

        public GetCompetencyLevelsPageHandler(IBacklogDbContext context)
            => _context = context;

        public async Task<GetCompetencyLevelsPageResponse> Handle(GetCompetencyLevelsPageRequest request, CancellationToken cancellationToken)
        {
            var query = from competencyLevel in _context.CompetencyLevels
                        select competencyLevel;

            var length = await _context.CompetencyLevels.CountAsync();

            var competencyLevels = await query.Page(request.Index, request.PageSize)
                .Select(x => x.ToDto()).ToListAsync();

            return new()
            {
                Length = length,
                Entities = competencyLevels
            };
        }

    }

}
