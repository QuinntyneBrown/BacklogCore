using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Api.Models;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Api.Features
{
    public class CreateProfile
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Profile).NotNull();
                RuleFor(request => request.Profile).SetValidator(new ProfileValidator());
            }
        }

        public class Request: IRequest<Response>
        {
            public ProfileDto Profile { get; set; }
        }

        public class Response: ResponseBase
        {
            public ProfileDto Profile { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;
        
            public Handler(IBacklogDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var profile = new Profile(new(request.Profile.Firstname, request.Profile.Lastname));
                
                _context.Profiles.Add(profile);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    Profile = profile.ToDto()
                };
            }
            
        }
    }
}
