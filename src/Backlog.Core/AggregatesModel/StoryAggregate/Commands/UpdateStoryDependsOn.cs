using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;


public class UpdateStoryDependsOnRequest : IRequest<UpdateStoryDependsOnResponse>
{
    public Guid StoryId { get; set; }
    public List<string> DependsOn { get; set; }
}

public class UpdateStoryDependsOnResponse : ResponseBase
{
    public StoryDto Story { get; set; }
}

public class UpdateStoryDependsOnHandler : IRequestHandler<UpdateStoryDependsOnRequest, UpdateStoryDependsOnResponse>
{
    private readonly IBacklogDbContext _context;

    public UpdateStoryDependsOnHandler(IBacklogDbContext context)
    {
        _context = context;
    }

    public async Task<UpdateStoryDependsOnResponse> Handle(UpdateStoryDependsOnRequest request, CancellationToken cancellationToken)
    {

        var story = await _context.Stories.Include(x => x.DependsOn)
            .SingleAsync(x => x.StoryId == request.StoryId);

        story.Apply(new UpdateDependsOn(request.DependsOn.Select(x => new DependencyRelationship(x)).ToList()));

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Story = story.ToDto()
        };
    }
}

}
