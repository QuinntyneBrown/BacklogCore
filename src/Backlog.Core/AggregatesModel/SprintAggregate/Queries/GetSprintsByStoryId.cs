
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog.Core
{
    public class GetSprintsByStoryId
    {
        public class Request : IRequest<Response>
        {
            public Guid StoryId { get; set; }
        }

        public class Response : ResponseBase
        {
            public List<SprintDto> Sprints { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;

            public Handler(IBacklogDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var sprints = _context.Sprints.Include(x => x.SprintStories)
                    .Where(x => x.SprintStories.Any(x => x.StoryId == request.StoryId));

                return new()
                {
                    Sprints = sprints.Select(x => x.ToDto()).ToList()
                };
            }

        }
    }
}
