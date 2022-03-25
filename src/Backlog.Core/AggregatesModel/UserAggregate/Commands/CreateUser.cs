using Backlog.SharedKernel;
using Backlog.SharedKernel;
using FluentValidation;
using MediatR;

namespace Backlog.Core
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(request => request.User).NotNull();
            RuleFor(request => request.User).SetValidator(new UserValidator());
        }
    }

    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public UserDto? User { get; set; }
    }

    public class CreateUserResponse : ResponseBase
    {
        public UserDto? User { get; set; }
    }

    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IBacklogDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserHandler(IBacklogDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var @event = new CreateUser(request.User.Username, request.User.Password, _passwordHasher);

            var user = new User(@event);

            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                User = user.ToDto()
            };
        }

    }
}
