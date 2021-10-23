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
    public class RemoveDependencyRelationship
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
                var dependencyRelationship = await _context.DependencyRelationships.SingleAsync(x => x.DependencyRelationshipId == request.DependencyRelationshipId);
                
                _context.DependencyRelationships.Remove(dependencyRelationship);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    DependencyRelationship = dependencyRelationship.ToDto()
                };
            }
            
        }
    }
}
