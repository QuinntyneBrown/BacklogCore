using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;

public class GetTaskItemByIdRequest : IRequest<GetTaskItemByIdResponse>
{
    public Guid TaskItemId { get; set; }
}

public class GetTaskItemByIdResponse : ResponseBase
{
    public TaskItemDto? TaskItem { get; set; }
}

public class GetTaskItemByIdHandler : IRequestHandler<GetTaskItemByIdRequest, GetTaskItemByIdResponse>
{
    private readonly IBacklogDbContext _context;

    public GetTaskItemByIdHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetTaskItemByIdResponse> Handle(GetTaskItemByIdRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            TaskItem = (await _context.TaskItems.SingleOrDefaultAsync(x => x.TaskItemId == request.TaskItemId, cancellationToken))?.ToDto()
        };
    }
}