using Backlog.SharedKernel;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{

        public class UpdateProfileValidator : AbstractValidator<UpdateProfileRequest>
        {
            public UpdateProfileValidator()
            {
                RuleFor(request => request.Profile).NotNull();
                RuleFor(request => request.Profile).SetValidator(new ProfileValidator());
            }
        }

        public class UpdateProfileRequest : IRequest<UpdateProfileResponse>
        {
            public ProfileDto? Profile { get; set; }
        }

        public class UpdateProfileResponse : ResponseBase
        {
            public ProfileDto? Profile { get; set; }
        }

        public class UpdateProfileHandler : IRequestHandler<UpdateProfileRequest, UpdateProfileResponse>
        {
            private readonly IBacklogDbContext _context;

            public UpdateProfileHandler(IBacklogDbContext context)
                => _context = context;

            public async Task<UpdateProfileResponse> Handle(UpdateProfileRequest request, CancellationToken cancellationToken)
            {
                var profile = await _context.Profiles.SingleAsync(x => x.ProfileId == request.Profile.ProfileId);

                await _context.SaveChangesAsync(cancellationToken);

                return new ()
                {
                    Profile = profile.ToDto()
                };
            }
        }

}
