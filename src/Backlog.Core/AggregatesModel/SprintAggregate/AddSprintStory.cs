using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog.Api.Features
{
    public class AddSprintStory
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.SprintId).NotNull();
                RuleFor(request => request.StoryId).NotNull();
            }
        
        }

        public class Request: IRequest<Response>
        {
            public Guid SprintId { get; set; }
            public Guid StoryId { get; set; }
        }

        public class Response: ResponseBase
        {
            public SprintDto Sprint { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;
        
            public Handler(IBacklogDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var sprint = await _context.Sprints.SingleOrDefaultAsync(x => x.SprintId == request.SprintId);

                var story = await _context.Stories.SingleOrDefaultAsync(_ => _.StoryId == request.StoryId);

                story.Apply(new DomainEvents.UpdateStoryStatus(Constants.StoryStatus.Assigned));

                sprint.Apply(new DomainEvents.AddSprintStory(request.StoryId));
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    Sprint = sprint.ToDto()
                };
            }
            
        }
    }
}
