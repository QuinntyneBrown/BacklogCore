using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Api.Features
{
    public class GetTechnologies
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<TechnologyDto> Technologies { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;
        
            public Handler(IBacklogDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Technologies = await _context.Technologies.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
