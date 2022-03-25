using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Backlog.SharedKernel;

using Backlog.SharedKernel;

namespace Backlog.Core
{
    public class RemoveTechnology
    {
        public class Request : IRequest<Response>
        {
            public Guid TechnologyId { get; set; }
        }

        public class Response : ResponseBase
        {
            public TechnologyDto Technology { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;

            public Handler(IBacklogDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var technology = await _context.Technologies.SingleAsync(x => x.TechnologyId == request.TechnologyId);

                _context.Technologies.Remove(technology);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Technology = technology.ToDto()
                };
            }

        }
    }
}
