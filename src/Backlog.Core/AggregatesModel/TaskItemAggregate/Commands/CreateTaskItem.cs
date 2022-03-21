using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Core;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Core
{
    public class CreateTaskItem
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.TaskItem).NotNull();
                RuleFor(request => request.TaskItem).SetValidator(new TaskItemValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public TaskItemDto TaskItem { get; set; }
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
                var taskItem = new TaskItem(new());

                _context.TaskItems.Add(taskItem);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    TaskItem = taskItem.ToDto()
                };
            }

        }
    }
}
