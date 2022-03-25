using Backlog.SharedKernel;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
        public class UpdateStoryStatusValidator : AbstractValidator<UpdateStoryStatusRequest>
        {
            public UpdateStoryStatusValidator()
            {
                RuleFor(request => request.StoryId).NotNull();
                RuleFor(request => request.Status).NotNull()
                    .Custom((status,validationContext) =>
                    {
                        if(!SharedKernelConstants.StoryStatus.All.Contains(status))
                        {
                            validationContext.AddFailure("Invalid Status");
                        }
                    });
            }
        }

        public class UpdateStoryStatusRequest : IRequest<UpdateStoryStatusResponse>
        {
            public Guid StoryId { get; set; }
            public string? Status { get; set; }
        }

        public class UpdateStoryStatusResponse : ResponseBase
        {
            public StoryDto? Story { get; set; }
        }

        public class UpdateStoryStatusHandler : IRequestHandler<UpdateStoryStatusRequest, UpdateStoryStatusResponse>
        {
            private readonly IBacklogDbContext _context;

            public UpdateStoryStatusHandler(IBacklogDbContext context)
                => _context = context;

            public async Task<UpdateStoryStatusResponse> Handle(UpdateStoryStatusRequest request, CancellationToken cancellationToken)
            {
                var story = await _context.Stories.SingleAsync(x => x.StoryId == request.StoryId);

                story.Apply(new UpdateStoryStatus(request.Status));

                await _context.SaveChangesAsync(cancellationToken);

                return new ()
                {
                    Story = story.ToDto()
                };
            }

        }
}
