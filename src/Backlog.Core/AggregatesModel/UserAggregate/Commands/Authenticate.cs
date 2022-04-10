using Backlog.SharedKernel;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class AuthenticateValidator : AbstractValidator<AuthenticateRequest>
    {
        public AuthenticateValidator()
        {
            RuleFor(x => x.Username).NotNull();
            RuleFor(x => x.Password).NotNull();
        }
    }

    public record AuthenticateRequest(string Username, string Password) : IRequest<AuthenticateResponse>;

    public record AuthenticateResponse(string AccessToken, Guid UserId);

    public class AuthenticateHandler : IRequestHandler<AuthenticateRequest, AuthenticateResponse>
    {
        private readonly IBacklogDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IOrchestrationHandler _orchestrationHandler;

        public AuthenticateHandler(IBacklogDbContext context, IPasswordHasher passwordHasher, IOrchestrationHandler orchestrationHandler)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _orchestrationHandler = orchestrationHandler;
        }

        public async Task<AuthenticateResponse> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == request.Username);

            if (user == null)
                throw new Exception();

            if (!ValidateUser(user, _passwordHasher.HashPassword(user.Salt, request.Password)))
                throw new Exception();

            return await _orchestrationHandler.Handle<AuthenticateResponse>(new BuildToken(user.Username), (tcs) => async message =>
            {
                switch (message)
                {
                    case BuiltToken builtToken:
                        await _orchestrationHandler.Publish(new AuthenticatedUser(user.Username));
                        tcs.SetResult(new AuthenticateResponse(builtToken.AccessToken, builtToken.UserId));
                        break;
                }
            });
        }

        public bool ValidateUser(User user, string transformedPassword)
        {
            if (user == null || transformedPassword == null)
                return false;

            return user.Password == transformedPassword;
        }
    }
}
