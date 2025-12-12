using Backlog.SharedKernel;
using FluentValidation;
using MediatR;

namespace Backlog.Core;

public class UpdateStoryJiraUrlValidator : AbstractValidator<UpdateStoryJiraUrlRequest>
{
    public UpdateStoryJiraUrlValidator()
    {
        RuleFor(request => request.Story).NotNull();
        RuleFor(request => request.Story).SetValidator(new StoryValidator());
    }
}

public class UpdateStoryJiraUrlRequest : IRequest<UpdateStoryJiraUrlResponse>
{
    public StoryDto? Story { get; set; }
}

public class UpdateStoryJiraUrlResponse : ResponseBase
{
    public StoryDto? Story { get; set; }
}

public class UpdateStoryJiraUrlHandler : IRequestHandler<UpdateStoryJiraUrlRequest, UpdateStoryJiraUrlResponse>
{
    private readonly IBacklogDbContext _context;

    public UpdateStoryJiraUrlHandler(IBacklogDbContext context)
    {
        _context = context;
    }

    public async Task<UpdateStoryJiraUrlResponse> Handle(UpdateStoryJiraUrlRequest request, CancellationToken cancellationToken)
    {

        var story = await _context.Stories.FindAsync(request.Story.StoryId);

        story.Apply(new UpdateStoryJiraUrl(request.Story.JiraUrl));

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Story = story.ToDto()
        };
    }
}

}
