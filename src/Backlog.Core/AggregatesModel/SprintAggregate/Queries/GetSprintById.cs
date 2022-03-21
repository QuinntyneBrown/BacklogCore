using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetSprintById
    {
        public class Request: IRequest<Response>
        {
            public Guid SprintId { get; set; }
        }

        public class Response: ResponseBase
        {
            public SprintDto Sprint { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;
        
            public Handler(IBacklogDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Sprint = (await _context.Sprints.SingleOrDefaultAsync(x => x.SprintId == request.SprintId)).ToDto()
                };
            }
            
        }
    }
}
