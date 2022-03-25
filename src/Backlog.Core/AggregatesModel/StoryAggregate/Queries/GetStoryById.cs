using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

using Backlog.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetStoryById
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
                return new()
                {
                    Story = (await _context.Stories
                    .Include(x => x.SkillRequirements)
                    .Include(x => x.DependsOn)
                    .SingleOrDefaultAsync(x => x.StoryId == request.StoryId)).ToDto()
                };
            }

        }
    }
}
