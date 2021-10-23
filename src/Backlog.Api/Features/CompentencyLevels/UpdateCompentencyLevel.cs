using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Api.Features
{
    public class UpdateCompentencyLevel
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.CompentencyLevel).NotNull();
                RuleFor(request => request.CompentencyLevel).SetValidator(new CompentencyLevelValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public CompentencyLevelDto CompentencyLevel { get; set; }
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
                var compentencyLevel = await _context.CompentencyLevels.SingleAsync(x => x.CompentencyLevelId == request.CompentencyLevel.CompentencyLevelId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    CompentencyLevel = compentencyLevel.ToDto()
                };
            }
            
        }
    }
}
