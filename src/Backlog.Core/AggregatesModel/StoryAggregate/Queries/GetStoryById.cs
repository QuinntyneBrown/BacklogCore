using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;

public class GetStoryByIdRequest : IRequest<GetStoryByIdResponse>
{
    public Guid StoryId { get; set; }
}

public class GetStoryByIdResponse : ResponseBase
{
    public StoryDto? Story { get; set; }
}

public class GetStoryByIdHandler : IRequestHandler<GetStoryByIdRequest, GetStoryByIdResponse>
{
    private readonly IBacklogDbContext _context;

    public GetStoryByIdHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetStoryByIdResponse> Handle(GetStoryByIdRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            Story = (await _context.Stories
            .Include(x => x.SkillRequirements)
            .Include(x => x.DependsOn)
            .SingleOrDefaultAsync(x => x.StoryId == request.StoryId, cancellationToken))?.ToDto()
        };
    }
}