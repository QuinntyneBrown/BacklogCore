using Backlog.Api.Extensions;
using Backlog.Api.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog.Api.Features
{
    public class SearchStories
    {
        public class Request : IRequest<Response>
        {
            public string Query { get; set; }
        }

        public class Response
        {
            public List<StoryDto> Stories { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;

            public Handler(IBacklogDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                try
                {
                    var nameResults = _context.Stories.Search("Name", request.Query);

                    var titleResults = _context.Stories.Search("Title", request.Query);

                    return new()
                    {
                        Stories = nameResults.Union(titleResults)
                        .Select(x => x.ToDto()).ToList()
                    };
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
