
using Backlog.SharedKernel;
using Backlog.Core.Users;
using Backlog.SharedKernel;
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Coop.Api.Features
{
    using Messages = Backlog.Core;

    public class UserEventHandler :
        INotificationHandler<Messages.CreateUser>,
        INotificationHandler<BuildToken>
    {
        private readonly IBacklogDbContext _context;
        private readonly IOrchestrationHandler _orchestrationHandler;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenBuilder _tokenBuilder;

        public UserEventHandler(IBacklogDbContext context, IOrchestrationHandler messageHandlerContext, IPasswordHasher passwordHasher, ITokenBuilder tokenBuilder)
        {
            _context = context;
            _orchestrationHandler = messageHandlerContext;
            _passwordHasher = passwordHasher;
            _tokenBuilder = tokenBuilder;
        }


        public async Task Handle(CreateUser notification, CancellationToken cancellationToken)
        {
            var user = new User(notification);

            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            await _orchestrationHandler.Publish(new CreatedUser(user.UserId));
        }

        public async Task Handle(BuildToken notification, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .SingleAsync(x => x.Username == notification.Username);

            _tokenBuilder
                .AddUsername(user.Username)
                .AddClaim(new System.Security.Claims.Claim(Constants.ClaimTypes.UserId, $"{user.UserId}"))
                .AddClaim(new System.Security.Claims.Claim(Constants.ClaimTypes.Username, $"{user.Username}"));

            await _orchestrationHandler.PublishBuiltTokenEvent(user.UserId, _tokenBuilder.Build());
        }
    }
}
