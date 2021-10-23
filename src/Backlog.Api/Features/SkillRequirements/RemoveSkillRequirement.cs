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
    public class RemoveSkillRequirement
    {
        public class Request: IRequest<Response>
        {
            public Guid SkillRequirementId { get; set; }
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
                var skillRequirement = await _context.SkillRequirements.SingleAsync(x => x.SkillRequirementId == request.SkillRequirementId);
                
                _context.SkillRequirements.Remove(skillRequirement);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    SkillRequirement = skillRequirement.ToDto()
                };
            }
            
        }
    }
}
