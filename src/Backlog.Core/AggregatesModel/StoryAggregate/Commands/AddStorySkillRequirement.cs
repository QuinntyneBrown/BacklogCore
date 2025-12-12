using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class AddStorySkillRequirementRequest : IRequest<AddStorySkillRequirementResponse>
{
    public Guid StoryId { get; set; }
    public string? Technology { get; set; }
    public string? CompetencyLevel { get; set; }
}

public class AddStorySkillRequirementResponse : ResponseBase
{
    public StoryDto? Story { get; set; }
}

public class AddStorySkillRequirementHandler : IRequestHandler<AddStorySkillRequirementRequest, AddStorySkillRequirementResponse>
{
    private readonly IBacklogDbContext _context;

    public AddStorySkillRequirementHandler(IBacklogDbContext context)
    {
        _context = context;
    }

    public async Task<AddStorySkillRequirementResponse> Handle(AddStorySkillRequirementRequest request, CancellationToken cancellationToken)
    {

        var story = await _context.Stories
            .Include(x => x.SkillRequirements)
            .SingleAsync(x => x.StoryId == request.StoryId);

        var skillRequirement = new SkillRequirement(request.Technology, request.CompetencyLevel);

        story.Apply(new AddSkillRequirement(skillRequirement));

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Story = story.ToDto()
        };
    }
}
}
