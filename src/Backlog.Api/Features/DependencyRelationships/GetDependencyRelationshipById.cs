using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Api.Features
{
    public class GetDependencyRelationshipById
    {
        public class Request: IRequest<Response>
        {
            public Guid DependencyRelationshipId { get; set; }
        }

        public class Response: ResponseBase
        {
            public DependencyRelationshipDto DependencyRelationship { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;
        
            public Handler(IBacklogDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    DependencyRelationship = (await _context.DependencyRelationships.SingleOrDefaultAsync(x => x.DependencyRelationshipId == request.DependencyRelationshipId)).ToDto()
                };
            }
            
        }
    }
}
