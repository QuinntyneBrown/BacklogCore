using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Interfaces;
using Backlog.Api.Models;
using Backlog.Api.Core;

namespace Backlog.Api.Features
{
    public class UpdateStory
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
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                var story = await _context.Stories.FindAsync(request.Story.StoryId);

                story.Apply(new DomainEvents.UpdateStory(
                    request.Story.Name,
                    request.Story.Title,
                    request.Story.Description,
                    request.Story.AcceptanceCriteria,
                    request.Story.JiraUrl));

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Story = story.ToDto()
                };
            }
        }
    }
}
