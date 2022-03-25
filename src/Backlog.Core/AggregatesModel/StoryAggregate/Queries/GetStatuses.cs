using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

using Backlog.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetStatuses
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<StatusDto> Statuses { get; set; }
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
                    Statuses = await _context.Statuses.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
