using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;

public class RemoveCompetencyLevelRequest : IRequest<RemoveCompetencyLevelResponse>
{
    public Guid CompetencyLevelId { get; set; }
}

public class RemoveCompetencyLevelResponse : ResponseBase
{
    public CompetencyLevelDto? CompetencyLevel { get; set; }
}

public class RemoveCompetencyLevelHandler : IRequestHandler<RemoveCompetencyLevelRequest, RemoveCompetencyLevelResponse>
{
    private readonly IBacklogDbContext _context;

    public RemoveCompetencyLevelHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<RemoveCompetencyLevelResponse> Handle(RemoveCompetencyLevelRequest request, CancellationToken cancellationToken)
    {
        var competencyLevel = await _context.CompetencyLevels.SingleAsync(x => x.CompetencyLevelId == request.CompetencyLevelId);

        _context.CompetencyLevels.Remove(competencyLevel);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            CompetencyLevel = competencyLevel.ToDto()
        };
    }

}