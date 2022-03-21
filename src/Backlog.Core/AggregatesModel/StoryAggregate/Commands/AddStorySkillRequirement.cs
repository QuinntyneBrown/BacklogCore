using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Interfaces;
using Backlog.Core;
using Backlog.Api.Core;
using System;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class AddStorySkillRequirement
    {
        public class Request : IRequest<Response>
        {
            public Guid StoryId { get; set; }
            public string Technology { get; set; }
            public string CompetencyLevel { get; set; }
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

                var story = await _context.Stories
                    .Include(x => x.SkillRequirements)
                    .SingleAsync(x => x.StoryId == request.StoryId);

                var skillRequirement = new SkillRequirement(request.Technology, request.CompetencyLevel);

                story.Apply(new DomainEvents.AddSkillRequirement(skillRequirement));

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Story = story.ToDto()
                };
            }
        }
    }
}
