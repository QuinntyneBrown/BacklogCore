using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetBugById
    {
        public class Request : IRequest<Response>
        {
            public Guid BugId { get; set; }
        }

        public class Response : ResponseBase
        {
            public BugDto Bug { get; set; }
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
                    Bug = (await _context.Bugs.SingleOrDefaultAsync(x => x.BugId == request.BugId)).ToDto()
                };
            }

        }
    }
}
