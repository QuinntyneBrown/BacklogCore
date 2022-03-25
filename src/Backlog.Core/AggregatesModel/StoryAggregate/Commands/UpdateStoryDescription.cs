using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class UpdateStoryDescriptionRequest : IRequest<UpdateStoryDescriptionResponse>
    {
        public Guid StoryId { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateStoryDescriptionResponse : ResponseBase
    {
        public StoryDto? Story { get; set; }
    }

    public class UpdateStoryDescriptionHandler : IRequestHandler<UpdateStoryDescriptionRequest, UpdateStoryDescriptionResponse>
    {
        private readonly IBacklogDbContext _context;

        public UpdateStoryDescriptionHandler(IBacklogDbContext context)
            => _context = context;

        public async Task<UpdateStoryDescriptionResponse> Handle(UpdateStoryDescriptionRequest request, CancellationToken cancellationToken)
        {
            var story = await _context.Stories.SingleAsync(x => x.StoryId == request.StoryId);

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateStoryDescriptionResponse()
            {
                Story = story.ToDto()
            };
        }

    }

}
