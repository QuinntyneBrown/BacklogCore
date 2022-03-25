using Backlog.SharedKernel;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{

    public class AddSprintStoryValidator : AbstractValidator<AddSprintStoryRequest>
    {
        public AddSprintStoryValidator()
        {
            RuleFor(request => request.SprintId).NotNull();
            RuleFor(request => request.StoryId).NotNull();
        }
        
    }

    public class AddSprintStoryRequest : IRequest<AddSprintStoryResponse>
    {
        public Guid SprintId { get; set; }
        public Guid StoryId { get; set; }
    }

    public class AddSprintStoryResponse : ResponseBase
    {
        public SprintDto? Sprint { get; set; }
    }

    public class AddSprintStoryHandler : IRequestHandler<AddSprintStoryRequest, AddSprintStoryResponse>
    {
        private readonly IBacklogDbContext _context;
        
        public AddSprintStoryHandler(IBacklogDbContext context)
            => _context = context;
        
        public async Task<AddSprintStoryResponse> Handle(AddSprintStoryRequest request, CancellationToken cancellationToken)
        {
            var sprint = await _context.Sprints.SingleOrDefaultAsync(x => x.SprintId == request.SprintId);

            var story = await _context.Stories.SingleOrDefaultAsync(_ => _.StoryId == request.StoryId);

            story?.Apply(new UpdateStoryStatus(SharedKernelConstants.StoryStatus.Assigned));

            sprint?.Apply(new AddSprintStory(request.StoryId));
                
            await _context.SaveChangesAsync(cancellationToken);
                
            return new ()
            {
                Sprint = sprint?.ToDto()
            };
        }
            
    }

}
