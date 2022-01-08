using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Backlog.Api.Models;
using Backlog.Api.DomainEvents;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Backlog.Api.Features
{
    public class Authenticate
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.Username).NotNull();
                RuleFor(x => x.Password).NotNull();
            }
        }

        public record Request(string Username, string Password) : IRequest<Response>;

        public record Response(string AccessToken, Guid UserId);

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;
            private readonly IPasswordHasher _passwordHasher;
            private readonly IOrchestrationHandler _orchestrationHandler;

            public Handler(IBacklogDbContext context, IPasswordHasher passwordHasher, IOrchestrationHandler orchestrationHandler)
            {
                _context = context;
                _passwordHasher = passwordHasher;
                _orchestrationHandler = orchestrationHandler;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var user = await _context.Users
                    .SingleOrDefaultAsync(x => x.Username == request.Username);

                if (user == null)
                    throw new Exception();

                if (!ValidateUser(user, _passwordHasher.HashPassword(user.Salt, request.Password)))
                    throw new Exception();

                return await _orchestrationHandler.Handle<Response>(new BuildToken(user.Username), (tcs) => async message =>
                 {
                     switch (message)
                     {
                         case BuiltToken builtToken:
                             await _orchestrationHandler.Publish(new AuthenticatedUser(user.Username));
                             tcs.SetResult(new Response(builtToken.AccessToken, builtToken.UserId));
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
}
