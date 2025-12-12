using Backlog.SharedKernel;
using FluentValidation;
using MediatR;

namespace Backlog.Core;


public class CreateStoryValidator : AbstractValidator<CreateStoryRequest>
{
    public CreateStoryValidator()
    {
        RuleFor(request => request.Story).NotNull();
        RuleFor(request => request.Story).SetValidator(new StoryValidator());
    }

}

public class CreateStoryRequest : IRequest<CreateStoryResponse>
{
    public StoryDto? Story { get; set; }
}

public class CreateStoryResponse : ResponseBase
{
    public StoryDto? Story { get; set; }
}

public class CreateStoryHandler : IRequestHandler<CreateStoryRequest, CreateStoryResponse>
{
    private readonly IBacklogDbContext _context;

    public CreateStoryHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<CreateStoryResponse> Handle(CreateStoryRequest request, CancellationToken cancellationToken)
    {
        var story = new Story(new(
            request.Story.Name,
            request.Story.Title,
            request.Story.Description,
            request.Story.AcceptanceCriteria,
            request.Story.JiraUrl,
            request.Story.Effort));

        _context.Stories.Add(story);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Story = story.ToDto()
        };
    }

}