using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Models;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Api.Features
{
    public class CreateSprint
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Sprint).NotNull();
                RuleFor(request => request.Sprint).SetValidator(new SprintValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public SprintDto Sprint { get; set; }
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
                var @event = new DomainEvents.CreateSprint(request.Sprint.Name, request.Sprint.Start, request.Sprint.End);

                var sprint = new Sprint(@event);
                
                _context.Sprints.Add(sprint);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Sprint = sprint.ToDto()
                };
            }
            
        }
    }
}
