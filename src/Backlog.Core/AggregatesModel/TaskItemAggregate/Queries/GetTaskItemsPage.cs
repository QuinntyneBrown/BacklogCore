using Backlog.Api.Extensions;
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core;
public class GetTaskItemsPageRequest : IRequest<GetTaskItemsPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
}

public class GetTaskItemsPageResponse : ResponseBase
{
    public int Length { get; set; }
    public List<TaskItemDto>? Entities { get; set; }
}

public class GetTaskItemsPageHandler : IRequestHandler<GetTaskItemsPageRequest, GetTaskItemsPageResponse>
{
    private readonly IBacklogDbContext _context;

    public GetTaskItemsPageHandler(IBacklogDbContext context)
        => _context = context;

    public async Task<GetTaskItemsPageResponse> Handle(GetTaskItemsPageRequest request, CancellationToken cancellationToken)
    {
        var query = from taskItem in _context.TaskItems
                    select taskItem;

        var length = await _context.TaskItems.CountAsync(cancellationToken);

        var taskItems = await query.Page(request.Index, request.PageSize)
            .Select(x => x.ToDto()).ToListAsync();

        return new()
        {
            Length = length,
            Entities = taskItems
        };
    }

}
}
