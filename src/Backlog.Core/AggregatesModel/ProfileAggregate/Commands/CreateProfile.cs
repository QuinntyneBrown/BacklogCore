using Backlog.SharedKernel;
using FluentValidation;
using MediatR;


namespace Backlog.Core;
public class CreateProfileValidator : AbstractValidator<CreateProfileRequest>
    {
        public CreateProfileValidator()
        {
            RuleFor(request => request.Profile).NotNull();
            RuleFor(request => request.Profile).SetValidator(new ProfileValidator());
        }
    }

    public class CreateProfileRequest : IRequest<CreateProfileResponse>
    {
        public ProfileDto Profile { get; set; }
    }

    public class CreateProfileResponse : ResponseBase
    {
        public ProfileDto Profile { get; set; }

        public CreateProfileResponse(ProfileDto profile)
        {
            Profile = profile;
        }
    }

    public class CreateProfileHandler : IRequestHandler<CreateProfileRequest, CreateProfileResponse>
    {
        private readonly IBacklogDbContext _context;

        public CreateProfileHandler(IBacklogDbContext context)
            => _context = context;

        public async Task<CreateProfileResponse> Handle(CreateProfileRequest request, CancellationToken cancellationToken)
        {
            var profile = new Profile(new(request.Profile.Firstname, request.Profile.Lastname));

            _context.Profiles.Add(profile);

            await _context.SaveChangesAsync(cancellationToken);

            return new(profile.ToDto());
        }
    }