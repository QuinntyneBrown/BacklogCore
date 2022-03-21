using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetUserById
    {
        public class Request: IRequest<Response>
        {
            public Guid UserId { get; set; }
        }

        public class Response: ResponseBase
        {
            public UserDto User { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;
        
            public Handler(IBacklogDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    User = (await _context.Users.SingleOrDefaultAsync(x => x.UserId == request.UserId)).ToDto()
                };
            }
            
        }
    }
}
