using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Api.Features
{
    public class GetDependencyRelationships
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<DependencyRelationshipDto> DependencyRelationships { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;
        
            public Handler(IBacklogDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    DependencyRelationships = await _context.DependencyRelationships.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
