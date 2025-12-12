using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class GetSprintsByStoryIdRequest : IRequest<GetSprintsByStoryIdResponse>
{
    public Guid StoryId { get; set; }
}

public class GetSprintsByStoryIdResponse : ResponseBase
{
    public List<SprintDto>? Sprints { get; set; }
}

public class GetSprintsByStoryIdHandler : IRequestHandler<GetSprintsByStoryIdRequest, GetSprintsByStoryIdResponse>
{
    private readonly IBacklogDbContext _context;

    public GetSprintsByStoryIdHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetSprintsByStoryIdResponse> Handle(GetSprintsByStoryIdRequest request, CancellationToken cancellationToken)
    {
        var sprints = _context.Sprints.Include(x => x.SprintStories)
            .Where(x => x.SprintStories.Any(x => x.StoryId == request.StoryId));

        return new()
        {
            Sprints = sprints.Select(x => x.ToDto()).ToList()
        };
    }

}