using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Core;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Core
{
    public class CreateStory
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Story).NotNull();
                RuleFor(request => request.Story).SetValidator(new StoryValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public StoryDto Story { get; set; }
        }

        public class Response : ResponseBase
        {
            public StoryDto Story { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;

            public Handler(IBacklogDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var story = new Story(new(
                    request.Story.Name,
                    request.Story.Title,
                    request.Story.Description,
                    request.Story.AcceptanceCriteria,
                    request.Story.JiraUrl,
                    request.Story.Effort));

                _context.Stories.Add(story);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Story = story.ToDto()
                };
            }

        }
    }
}
