using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Api.Features
{
    public class GetStoryStatuses
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<StoryStatusDto> StoryStatuses { get; set; }
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
                    StoryStatuses = await _context.StoryStatuses.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
