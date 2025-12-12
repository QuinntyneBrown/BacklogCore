using Backlog.Api.Extensions;
using MediatR;

namespace Backlog.Core;

public class SearchStoriesRequest : IRequest<SearchStoriesResponse>
{
    public string? Query { get; set; }
}

public class SearchStoriesResponse
{
    public List<StoryDto>? Stories { get; set; }
}

public class SearchStoriesHandler : IRequestHandler<SearchStoriesRequest, SearchStoriesResponse>
{
    private readonly IBacklogDbContext _context;

    public SearchStoriesHandler(IBacklogDbContext context)
    {
        _context = context;
    }

    public async Task<SearchStoriesResponse> Handle(SearchStoriesRequest request, CancellationToken cancellationToken)
    {
        var nameResults = _context.Stories.Search("Name", request.Query);

        var titleResults = _context.Stories.Search("Title", request.Query);

        return new()
        {
            Stories = nameResults.Union(titleResults)
            .Select(x => x.ToDto()).ToList()
        };
    }
}