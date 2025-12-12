using Backlog.Core;
using Backlog.Core.Users;
using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Coop.Api.Features;

public class UserEventHandler :
    INotificationHandler<CreateUser>,
    INotificationHandler<BuildToken>
{
    private readonly IBacklogDbContext _context;
    private readonly IOrchestrationHandler _orchestrationHandler;
    private readonly ITokenBuilder _tokenBuilder;

    public UserEventHandler(IBacklogDbContext context, IOrchestrationHandler messageHandlerContext, ITokenBuilder tokenBuilder)
    {
        _context = context;
        _orchestrationHandler = messageHandlerContext;
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
            .AddClaim(new System.Security.Claims.Claim(SharedKernelConstants.ClaimTypes.UserId, $"{user.UserId}"))
            .AddClaim(new System.Security.Claims.Claim(SharedKernelConstants.ClaimTypes.Username, $"{user.Username}"));

        await _orchestrationHandler.PublishBuiltTokenEvent(user.UserId, _tokenBuilder.Build());
    }
}