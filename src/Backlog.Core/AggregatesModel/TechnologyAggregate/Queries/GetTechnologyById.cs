using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

using Backlog.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetTechnologyById
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
                return new()
                {
                    Technology = (await _context.Technologies.SingleOrDefaultAsync(x => x.TechnologyId == request.TechnologyId)).ToDto()
                };
            }

        }
    }
}
