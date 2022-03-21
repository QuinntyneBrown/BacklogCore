using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Backlog.Core;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Core
{
    public class RemoveStory
    {
        public class Request : IRequest<Response>
        {
            public Guid StoryId { get; set; }
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

                _context.Stories.Remove(story);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Story = story.ToDto()
                };
            }

        }
    }
}
