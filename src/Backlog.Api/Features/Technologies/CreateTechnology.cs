using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Models;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Api.Features
{
    public class CreateTechnology
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Technology).NotNull();
                RuleFor(request => request.Technology).SetValidator(new TechnologyValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public TechnologyDto Technology { get; set; }
        }

        public class Response: ResponseBase
        {
            public TechnologyDto Technology { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;
        
            public Handler(IBacklogDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var technology = new Technology(new(request.Technology.Name, request.Technology.Description));
                
                _context.Technologies.Add(technology);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    Technology = technology.ToDto()
                };
            }
            
        }
    }
}
