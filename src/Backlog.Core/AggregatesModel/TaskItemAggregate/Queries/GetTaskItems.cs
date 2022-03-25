using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetTaskItemsRequest : IRequest<GetTaskItemsResponse> { }

    public class GetTaskItemsResponse : ResponseBase
    {
        public List<TaskItemDto>? TaskItems { get; set; }
    }

    public class GetTaskItemsHandler : IRequestHandler<GetTaskItemsRequest, GetTaskItemsResponse>
    {
        private readonly IBacklogDbContext _context;

        public GetTaskItemsHandler(IBacklogDbContext context)
            => _context = context;

        public async Task<GetTaskItemsResponse> Handle(GetTaskItemsRequest request, CancellationToken cancellationToken)
        {
            return new()
            {
                TaskItems = await _context.TaskItems.Select(x => x.ToDto()).ToListAsync(cancellationToken)
            };
        }

    }
}
