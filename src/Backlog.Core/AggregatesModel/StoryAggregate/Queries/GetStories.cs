using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;

public class GetStoriesRequest : IRequest<GetStoriesResponse> { }

public class GetStoriesResponse : ResponseBase
{
    public List<StoryDto>? Stories { get; set; }
}

public class GetStoriesHandler : IRequestHandler<GetStoriesRequest, GetStoriesResponse>
{
    private readonly IBacklogDbContext _context;

    public GetStoriesHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetStoriesResponse> Handle(GetStoriesRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            Stories = await _context.Stories
            .Include(x => x.SkillRequirements)
            .Include(x => x.DependsOn)
            .Select(x => x.ToDto()).ToListAsync()
        };
    }

}