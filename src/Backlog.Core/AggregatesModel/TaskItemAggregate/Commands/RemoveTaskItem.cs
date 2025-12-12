using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class RemoveTaskItemRequest : IRequest<RemoveTaskItemResponse>
{
    public Guid TaskItemId { get; set; }
}

public class RemoveTaskItemResponse : ResponseBase
{
    public TaskItemDto? TaskItem { get; set; }
}

public class RemoveTaskItemHandler : IRequestHandler<RemoveTaskItemRequest, RemoveTaskItemResponse>
{
    private readonly IBacklogDbContext _context;

    public RemoveTaskItemHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<RemoveTaskItemResponse> Handle(RemoveTaskItemRequest request, CancellationToken cancellationToken)
    {
        var taskItem = await _context.TaskItems.SingleAsync(x => x.TaskItemId == request.TaskItemId, cancellationToken);

        _context.TaskItems.Remove(taskItem);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            TaskItem = taskItem.ToDto()
        };
    }

}