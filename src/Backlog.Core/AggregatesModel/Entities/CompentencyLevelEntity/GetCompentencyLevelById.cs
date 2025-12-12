using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;

public class GetCompetencyLevelByIdRequest : IRequest<GetCompetencyLevelByIdResponse>
{
    public Guid CompetencyLevelId { get; set; }
}

public class GetCompetencyLevelByIdResponse : ResponseBase
{
    public CompetencyLevelDto? CompetencyLevel { get; set; }
}

public class GetCompetencyLevelByIdHandler : IRequestHandler<GetCompetencyLevelByIdRequest, GetCompetencyLevelByIdResponse>
{
    private readonly IBacklogDbContext _context;

    public GetCompetencyLevelByIdHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetCompetencyLevelByIdResponse> Handle(GetCompetencyLevelByIdRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            CompetencyLevel = (await _context.CompetencyLevels.SingleOrDefaultAsync(x => x.CompetencyLevelId == request.CompetencyLevelId)).ToDto()
        };
    }

}