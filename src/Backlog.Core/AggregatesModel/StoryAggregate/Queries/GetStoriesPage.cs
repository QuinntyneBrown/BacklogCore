using Backlog.Api.Extensions;
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetStoriesPageRequest : IRequest<GetStoriesPageResponse>
    {
        public int PageSize { get; set; }
        public int Index { get; set; }
    }

    public class GetStoriesPageResponse : ResponseBase
    {
        public int Length { get; set; }
        public List<StoryDto>? Entities { get; set; }
    }

    public class GetStoriesPageHandler : IRequestHandler<GetStoriesPageRequest, GetStoriesPageResponse>
    {
        private readonly IBacklogDbContext _context;

        public GetStoriesPageHandler(IBacklogDbContext context)
            => _context = context;

        public async Task<GetStoriesPageResponse> Handle(GetStoriesPageRequest request, CancellationToken cancellationToken)
        {
            var query = from story in _context.Stories
                        select story;

            var length = await _context.Stories.CountAsync(cancellationToken: cancellationToken);

            var stories = await query.Page(request.Index, request.PageSize)
                .Select(x => x.ToDto()).ToListAsync();

            return new()
            {
                Length = length,
                Entities = stories
            };
        }

    }
}
