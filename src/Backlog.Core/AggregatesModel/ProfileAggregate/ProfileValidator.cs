using FluentValidation;

namespace Backlog.Core
{
    public class ProfileValidator : AbstractValidator<ProfileDto> {
        public ProfileValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().NotNull();
            RuleFor(x => x.Lastname).NotEmpty().NotNull();
        }
    }
}
