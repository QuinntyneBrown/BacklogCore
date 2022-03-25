using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class UpdateStoryAcceptanceCriteriaRequest : IRequest<UpdateStoryAcceptanceCriteriaResponse>
    {
        public Guid StoryId { get; set; }
        public string? AcceptanceCriteria { get; set; }
    }

    public class UpdateStoryAcceptanceCriteriaResponse : ResponseBase
    {
        public StoryDto? Story { get; set; }
    }

    public class UpdateStoryAcceptanceCriteriaHandler : IRequestHandler<UpdateStoryAcceptanceCriteriaRequest, UpdateStoryAcceptanceCriteriaResponse>
    {
        private readonly IBacklogDbContext _context;

        public UpdateStoryAcceptanceCriteriaHandler(IBacklogDbContext context)
            => _context = context;

        public async Task<UpdateStoryAcceptanceCriteriaResponse> Handle(UpdateStoryAcceptanceCriteriaRequest request, CancellationToken cancellationToken)
        {
            var story = await _context.Stories.SingleAsync(x => x.StoryId == request.StoryId);

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateStoryAcceptanceCriteriaResponse()
            {
                Story = story.ToDto()
            };
        }

    }
    
}
