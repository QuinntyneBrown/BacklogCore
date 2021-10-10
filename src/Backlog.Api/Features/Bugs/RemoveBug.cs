using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Backlog.Api.Models;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Api.Features
{
    public class RemoveBug
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
                var bug = await _context.Bugs.SingleAsync(x => x.BugId == request.BugId);

                _context.Bugs.Remove(bug);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Bug = bug.ToDto()
                };
            }

        }
    }
}
