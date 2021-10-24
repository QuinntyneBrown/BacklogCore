using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog.Api.Features
{
    public class AddStoryDependencyRelationship
    {

        public class Request : IRequest<Response> { 
            public Guid StoryId { get; set; }
            public string DependsOn { get; set; }
        }

        public class Response: ResponseBase
        {
            public StoryDto Story { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;

            public Handler(IBacklogDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
            
                var story = await _context.Stories.Include(x => x.DependsOn)
                    .SingleAsync(x => x.StoryId == request.StoryId);

                story.Apply(new DomainEvents.AddStoryDependsOn(request.DependsOn));

                await _context.SaveChangesAsync(cancellationToken);
			    
                return new () { 
                    Story = story.ToDto()
                };
            }
        }
    }
}
