using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Backlog.Api.Extensions;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Backlog.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Api.Features
{
    public class GetSkillRequirementsPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<SkillRequirementDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;
        
            public Handler(IBacklogDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from skillRequirement in _context.SkillRequirements
                    select skillRequirement;
                
                var length = await _context.SkillRequirements.CountAsync();
                
                var skillRequirements = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = skillRequirements
                };
            }
            
        }
    }
}
