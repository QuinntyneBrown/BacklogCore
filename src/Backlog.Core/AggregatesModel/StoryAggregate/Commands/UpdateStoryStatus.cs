using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Backlog.Api.Features
{
    public class UpdateStoryStatus
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.StoryId).NotNull();
                RuleFor(request => request.Status).NotNull()
                    .Custom((status,validationContext) =>
                    {
                        if(!Constants.StoryStatus.All.Contains(status))
                        {
                            validationContext.AddFailure("Invalid Status");
                        }
                    });
            }
        }

        public class Request : IRequest<Response>
        {
            public Guid StoryId { get; set; }
            public string Status { get; set; }
        }

        public class Response : ResponseBase
        {
            public StoryDto Story { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;

            public Handler(IBacklogDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var story = await _context.Stories.SingleAsync(x => x.StoryId == request.StoryId);

                story.Apply(new DomainEvents.UpdateStoryStatus(request.Status));

                await _context.SaveChangesAsync(cancellationToken);

                return new ()
                {
                    Story = story.ToDto()
                };
            }

        }
    }
}
