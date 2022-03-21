using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog.Core
{
    public class UpdateStoryAcceptanceCriteria
    {
        public class Request : IRequest<Response>
        {
            public Guid StoryId { get; set; }
            public string AcceptanceCriteria { get; set; }
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

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Story = story.ToDto()
                };
            }

        }
    }
}
