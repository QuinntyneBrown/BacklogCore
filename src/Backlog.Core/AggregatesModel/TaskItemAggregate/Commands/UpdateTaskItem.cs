using Backlog.SharedKernel;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class UpdateTaskItemValidator : AbstractValidator<UpdateTaskItemRequest>
    {
        public UpdateTaskItemValidator()
        {
            RuleFor(request => request.TaskItem).NotNull();
            RuleFor(request => request.TaskItem).SetValidator(new TaskItemValidator());
        }
    }

    public class UpdateTaskItemRequest : IRequest<UpdateTaskItemResponse>
    {
        public TaskItemDto? TaskItem { get; set; }
    }

    public class UpdateTaskItemResponse : ResponseBase
    {
        public TaskItemDto? TaskItem { get; set; }
    }

    public class UpdateTaskItemHandler : IRequestHandler<UpdateTaskItemRequest, UpdateTaskItemResponse>
    {
        private readonly IBacklogDbContext _context;

        public UpdateTaskItemHandler(IBacklogDbContext context)
            => _context = context;

        public async Task<UpdateTaskItemResponse> Handle(UpdateTaskItemRequest request, CancellationToken cancellationToken)
        {
            var taskItem = await _context.TaskItems.SingleAsync(x => x.TaskItemId == request.TaskItem.TaskItemId, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateTaskItemResponse()
            {
                TaskItem = taskItem.ToDto()
            };
        }
    }
}
