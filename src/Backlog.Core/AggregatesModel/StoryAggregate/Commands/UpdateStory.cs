using Backlog.SharedKernel;
using FluentValidation;
using MediatR;

namespace Backlog.Core;

public class UpdateStoryValidator : AbstractValidator<UpdateStoryRequest>
{
    public UpdateStoryValidator()
    {
        RuleFor(request => request.Story).NotNull();
        RuleFor(request => request.Story).SetValidator(new StoryValidator());
    }
}

public class UpdateStoryRequest : IRequest<UpdateStoryResponse>
{
    public StoryDto? Story { get; set; }
}

public class UpdateStoryResponse : ResponseBase
{
    public StoryDto? Story { get; set; }
}

public class UpdateStoryHandler : IRequestHandler<UpdateStoryRequest, UpdateStoryResponse>
{
    private readonly IBacklogDbContext _context;

    public UpdateStoryHandler(IBacklogDbContext context)
    {
        _context = context;
    }

    public async Task<UpdateStoryResponse> Handle(UpdateStoryRequest request, CancellationToken cancellationToken)
    {

        var story = await _context.Stories.FindAsync(request.Story.StoryId);

        story.Apply(new UpdateStory(
            request.Story.Name,
            request.Story.Title,
            request.Story.Description,
            request.Story.AcceptanceCriteria,
            request.Story.JiraUrl,
            request.Story.Effort));

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Story = story.ToDto()
        };
    }
}