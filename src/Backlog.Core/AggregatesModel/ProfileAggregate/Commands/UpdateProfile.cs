using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

using Backlog.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class UpdateProfile
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Profile).NotNull();
                RuleFor(request => request.Profile).SetValidator(new ProfileValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public ProfileDto Profile { get; set; }
        }

        public class Response : ResponseBase
        {
            public ProfileDto Profile { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;

            public Handler(IBacklogDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var profile = await _context.Profiles.SingleAsync(x => x.ProfileId == request.Profile.ProfileId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Profile = profile.ToDto()
                };
            }

        }
    }
}
