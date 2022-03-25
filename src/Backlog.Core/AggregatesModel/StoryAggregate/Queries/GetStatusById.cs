using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

using Backlog.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetStatusById
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
                return new()
                {
                    Status = (await _context.Statuses.SingleOrDefaultAsync(x => x.StatusId == request.StatusId)).ToDto()
                };
            }

        }
    }
}
