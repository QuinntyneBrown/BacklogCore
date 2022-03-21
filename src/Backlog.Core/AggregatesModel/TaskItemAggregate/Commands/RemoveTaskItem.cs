using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Backlog.Core;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Core
{
    public class RemoveTaskItem
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
                var taskItem = await _context.TaskItems.SingleAsync(x => x.TaskItemId == request.TaskItemId);

                _context.TaskItems.Remove(taskItem);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    TaskItem = taskItem.ToDto()
                };
            }

        }
    }
}
