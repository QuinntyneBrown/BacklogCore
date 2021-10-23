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
    public class RemoveCompentencyLevel
    {
        public class Request: IRequest<Response>
        {
            public Guid CompentencyLevelId { get; set; }
        }

        public class Response: ResponseBase
        {
            public CompentencyLevelDto CompentencyLevel { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;
        
            public Handler(IBacklogDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var compentencyLevel = await _context.CompentencyLevels.SingleAsync(x => x.CompentencyLevelId == request.CompentencyLevelId);
                
                _context.CompentencyLevels.Remove(compentencyLevel);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    CompentencyLevel = compentencyLevel.ToDto()
                };
            }
            
        }
    }
}
