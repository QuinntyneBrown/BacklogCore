using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

using Backlog.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetTaskItemById
    {
        public class Request : IRequest<Response>
        {
            public Guid TaskItemId { get; set; }
        }

        public class Response : ResponseBase
        {
            public TaskItemDto TaskItem { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;

            public Handler(IBacklogDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new()
                {
                    TaskItem = (await _context.TaskItems.SingleOrDefaultAsync(x => x.TaskItemId == request.TaskItemId)).ToDto()
                };
            }

        }
    }
}
