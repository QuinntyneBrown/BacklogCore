using Backlog.SharedKernel;
using Backlog.Testing;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Backlog.UnitTests.Core;
public class OrchestrationHandlerTests : TestBase
{
    [Fact]
    public async Task Handle()
    {
        var container = _serviceCollection
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<OrchestrationHandlerTests>())
            .AddSingleton<OrchestrationItemsCache>()
            .AddSingleton<IOrchestrationHandler, OrchestrationHandler>()
            .BuildServiceProvider();

        var sut = container.GetService<IOrchestrationHandler>();

        var startWith = new Step1();

        var result = await sut.Handle<bool>(startWith, (ctx) => @event =>
        {
            switch (@event)
            {
                case Step1Completed created:
                    ctx.SetResult(true);
                    break;
            }
        });

        Assert.True(result);
    }


    [Fact]
    public async Task Handle_Multiple()
    {
        var container = _serviceCollection
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<OrchestrationHandlerTests>())
            .AddSingleton<OrchestrationItemsCache>()
            .AddSingleton<IOrchestrationHandler, OrchestrationHandler>()
            .BuildServiceProvider();

        var sut = container.GetService<IOrchestrationHandler>();

        var startWith = new Step1();

        var result1 = await sut.Handle<bool>(startWith, (ctx) => @event =>
        {
            switch (@event)
            {
                case Step1Completed created:
                    ctx.SetResult(true);
                    break;
            }
        });

        var result2 = await sut.Handle<bool>(startWith, (ctx) => @event =>
        {
            switch (@event)
            {
                case Step1Completed created:
                    ctx.SetResult(true);
                    break;
            }
        });

        Assert.True(result1);
        Assert.True(result2);
    }

    public class Step1 : BaseDomainEvent { }

    public class Step1Completed : BaseDomainEvent { }

    public class Step2 : BaseDomainEvent { }

    public class Step2Completed : BaseDomainEvent { }

    public class Handler : INotificationHandler<Step1>
    {
        private readonly IOrchestrationHandler _orchestrationHandler;
        public Handler(IOrchestrationHandler orchestrationHandler)
        {
            _orchestrationHandler = orchestrationHandler;
        }
        public async Task Handle(Step1 notification, CancellationToken cancellationToken)
        {
            await _orchestrationHandler.Publish(new Step1Completed());
        }
    }
}