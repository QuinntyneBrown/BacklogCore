using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Api.Features
{
    public class GetCompentencyLevelById
    {
        public class Request: IRequest<Response>
        {
            public Guid CompentencyLevelId { get; set; }
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
                return new () {
                    CompentencyLevel = (await _context.CompentencyLevels.SingleOrDefaultAsync(x => x.CompentencyLevelId == request.CompentencyLevelId)).ToDto()
                };
            }
            
        }
    }
}
