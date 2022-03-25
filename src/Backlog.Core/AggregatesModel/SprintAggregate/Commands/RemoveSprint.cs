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
    public class RemoveSprint
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
                var sprint = await _context.Sprints.SingleAsync(x => x.SprintId == request.SprintId);
                
                _context.Sprints.Remove(sprint);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Sprint = sprint.ToDto()
                };
            }
            
        }
    }
}
