using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Models;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Api.Features
{
    public class CreateDependencyRelationship
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.DependencyRelationship).NotNull();
                RuleFor(request => request.DependencyRelationship).SetValidator(new DependencyRelationshipValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public DependencyRelationshipDto DependencyRelationship { get; set; }
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
                var dependencyRelationship = new DependencyRelationship(new(request.DependencyRelationship.TargetId, request.DependencyRelationship.DependsOnId));
                
                _context.DependencyRelationships.Add(dependencyRelationship);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    DependencyRelationship = dependencyRelationship.ToDto()
                };
            }
            
        }
    }
}
