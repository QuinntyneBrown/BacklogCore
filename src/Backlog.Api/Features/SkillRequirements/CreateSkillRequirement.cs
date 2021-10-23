using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Models;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Api.Features
{
    public class CreateSkillRequirement
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.SkillRequirement).NotNull();
                RuleFor(request => request.SkillRequirement).SetValidator(new SkillRequirementValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public SkillRequirementDto SkillRequirement { get; set; }
        }

        public class Response: ResponseBase
        {
            public SkillRequirementDto SkillRequirement { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;
        
            public Handler(IBacklogDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var skillRequirement = new SkillRequirement();
                
                _context.SkillRequirements.Add(skillRequirement);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    SkillRequirement = skillRequirement.ToDto()
                };
            }
            
        }
    }
}
