using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog.Api.Features
{
    public class GetCurrentSprint
    {
        public class Request: IRequest<Response>
        { }

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
                    Sprint = (await _context.Sprints
                    .Include(x => x.SprintStories)
                    .FirstOrDefaultAsync(x => x.Start < DateTime.Now && x.End > DateTime.Now)).ToDto()
                };
            }
            
        }
    }
}
