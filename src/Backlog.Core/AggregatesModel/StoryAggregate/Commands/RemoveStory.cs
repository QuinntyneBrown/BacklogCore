using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class RemoveStoryRequest : IRequest<RemoveStoryResponse>
{
    public Guid StoryId { get; set; }
}

public class RemoveStoryResponse : ResponseBase
{
    public StoryDto? Story { get; set; }
}

public class RemoveStoryHandler : IRequestHandler<RemoveStoryRequest, RemoveStoryResponse>
{
    private readonly IBacklogDbContext _context;

    public RemoveStoryHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<RemoveStoryResponse> Handle(RemoveStoryRequest request, CancellationToken cancellationToken)
    {
        var story = await _context.Stories.SingleAsync(x => x.StoryId == request.StoryId, cancellationToken);

        _context.Stories.Remove(story);

        await _context.SaveChangesAsync(cancellationToken);

        return new RemoveStoryResponse()
        {
            Story = story.ToDto()
        };
    }
}
}
