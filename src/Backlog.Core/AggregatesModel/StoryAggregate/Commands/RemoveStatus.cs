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
    public class RemoveStatus
    {
        public class Request : IRequest<Response>
        {
            public Guid StatusId { get; set; }
        }

        public class Response : ResponseBase
        {
            public StatusDto Status { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;

            public Handler(IBacklogDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var status = await _context.Statuses.SingleAsync(x => x.StatusId == request.StatusId);

                _context.Statuses.Remove(status);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Status = status.ToDto()
                };
            }

        }
    }
}
