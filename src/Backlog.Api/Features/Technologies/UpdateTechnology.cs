using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Api.Features
{
    public class UpdateTechnology
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
                var technology = await _context.Technologies.SingleAsync(x => x.TechnologyId == request.Technology.TechnologyId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Technology = technology.ToDto()
                };
            }
            
        }
    }
}
