using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Api.Features
{
    public class GetSkillRequirementById
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
                return new () {
                    SkillRequirement = (await _context.SkillRequirements.SingleOrDefaultAsync(x => x.SkillRequirementId == request.SkillRequirementId)).ToDto()
                };
            }
            
        }
    }
}
